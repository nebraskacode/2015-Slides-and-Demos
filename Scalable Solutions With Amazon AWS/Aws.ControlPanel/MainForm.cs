using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aws.ControlPanel.Controls;
using Aws.ControlPanel.Helpers;
using Aws.Core.Abstract;
using Aws.Core.Helpers;
using Aws.Core.Models;
using Aws.Core.WorkerCallers;

namespace Aws.ControlPanel
{
    public partial class MainForm : Form
    {
        private readonly IEc2Caller ec2Caller;
        private readonly ISqsCaller sqsCaller;
        private readonly WorkerCaller workerCaller;
        private readonly Dictionary<AwsRegionLocations, AwsRegionControl> controlRegionDictionary = new Dictionary<AwsRegionLocations, AwsRegionControl>();
        private bool canRefreshWorkers = true;
        private AwsRegionLocations currentRegionBeingViewed = AwsRegionLocations.UsEast;
        private InputBoxForm updateWorkersInputBox = new InputBoxForm("Which deployment should workers be updated to? example: worker.100.zip");

        public MainForm(IEc2Caller ec2Caller, ISqsCaller sqsCaller, WorkerCaller workerCaller)
        {
            this.ec2Caller = ec2Caller;
            this.sqsCaller = sqsCaller;
            this.workerCaller = workerCaller;
            InitializeComponent();

            Action<AwsRegionControl, AwsRegionLocations> setupRegions = (control, region) =>
            {
                control.RegionLocation = region;
                controlRegionDictionary.Add(region, control);
            };

            setupRegions(UsEastRegion, AwsRegionLocations.UsEast);
            setupRegions(UsWest1Region, AwsRegionLocations.UsWest1);
            setupRegions(UsWest2Region, AwsRegionLocations.UsWest2);
            setupRegions(SaEastRegion, AwsRegionLocations.SaEast);
            setupRegions(EuWestRegion, AwsRegionLocations.EuWest);
            setupRegions(AsiaNortheastRegion, AwsRegionLocations.ApNortheast);
            setupRegions(AsiaSoutheast1Region, AwsRegionLocations.ApSoutheast1);
            setupRegions(AsiaSoutheast2Region, AwsRegionLocations.ApSoutheast2);

            foreach (var control in controlRegionDictionary.Values)
            {
                control.RegionIdLabelClicked += (o, region) => ShowRegionDetails(region);
                control.AddInstanceButtonClicked += (o, region) => LaunchInstance(region);
                control.RemoveInstanceButtonClicked += (o, region) => TerminateInstance(region);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshInstances();
        }

        private void UpdateRegionControl(AwsRegionControl regionControl)
        {
            var region = regionControl.RegionLocation;
            regionControl.UIThread(() =>
            {
                regionControl.RegionDetails = null;
            });
            var regionData = ec2Caller.GetRegionData(region);
            regionControl.UIThread(() =>
            {
                regionControl.RegionDetails = regionData;
            });
        }

        private void ShowRegionDetails(AwsRegionLocations region)
        {
            currentRegionBeingViewed = region;
            MainTabControl.SelectTab(1);
            RegionNameLabel.Text = controlRegionDictionary[region].RegionDetails.Name;

            RefreshWorkers(region);
        }

        private void LaunchInstance(AwsRegionLocations region)
        {
            Task.Factory.StartNew(() => ec2Caller.LaunchInstance(region, launchedRegion =>
            {
                Thread.Sleep(1000);
                UpdateRegionControl(controlRegionDictionary[launchedRegion]);
            }));
        }

        private void TerminateInstance(AwsRegionLocations region)
        {
            Task.Factory.StartNew(() => ec2Caller.TerminateInstance(region, launchedRegion =>
            {
                Thread.Sleep(1000);
                UpdateRegionControl(controlRegionDictionary[launchedRegion]);
            }));
        }

        private void WorldRefreshButton_Click(object sender, EventArgs e)
        {
            RefreshInstances();
        }

        private void RegionRefreshButton_Click(object sender, EventArgs e)
        {
            RefreshWorkers(currentRegionBeingViewed);
        }

        private void RefreshInstances()
        {
            foreach (var control in controlRegionDictionary.Values)
            {
                Task.Factory.StartNew(() => { UpdateRegionControl(control); });
            }
        }

        private void RefreshWorkers(AwsRegionLocations region)
        {
            // Use canRefreshWorkers to ensure that we don't try to refresh workers while a refresh is in progress
            if (canRefreshWorkers)
            {
                canRefreshWorkers = false;

                var regionControl = controlRegionDictionary[region];
                var instances = regionControl.RegionDetails.Instances;

                // Go into the UI thread to clear out the current listview and re-add all the instances to it
                InstancesInRegionListView.UIThread(() =>
                {
                    InstancesInRegionListView.Items.Clear();
                    foreach (var instance in instances)
                    {
                        instance.WorkerInfo = null;
                        InstancesInRegionListView.Items.Add(instance.ToListViewItem());
                    }
                });

                var updateInstanceTasks = instances.Select(RefreshWorker);

                Task.WhenAll(updateInstanceTasks.ToArray())
                    .ContinueWith(t =>
                    {
                        // Once we're all done refreshing all of the workers allow the refresh to happen again
                        canRefreshWorkers = true;
                    });
            }
        }

        private Task RefreshWorker(InstanceInfo instance)
        {
            return Task.Factory.StartNew(() =>
            {
                workerCaller.RefreshWorkerInfo(instance);

                InstancesInRegionListView.UIThread(() =>
                {
                    InstancesInRegionListView.UpdateListViewRow(instance.InstanceId, row =>
                    {
                        row.UpdateListViewItem(instance.WorkerInfo);
                    });
                });
            });
        }

        private void UpdateWorkersInRegion(IEnumerable<AwsRegionLocations> regions)
        {
            if (updateWorkersInputBox.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    foreach (var region in regions)
                    {
                        var updateFile = string.Format("deployments/{0}", updateWorkersInputBox.Input);
                        foreach (var instance in controlRegionDictionary[region].RegionDetails.Instances)
                        {
                            var result = workerCaller.UpdateWorker(instance, updateFile);

                            InstancesInRegionListView.UIThread(() =>
                            {
                                InstancesInRegionListView.UpdateListViewRow(instance.InstanceId, row =>
                                {
                                    row.SubItems[3].Text = result ? "Update attempted" : "Update failed";
                                });
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error: " + ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateAllWorkersButton_Click(object sender, EventArgs e)
        {
            // Translate all regions in the AwsRegionLocations enum into an array
            var allExistingRegions = (EnumHelpers.GetAllValues<AwsRegionLocations>());

            UpdateWorkersInRegion(allExistingRegions);
        }

        private void UpdateWorkersInRegionButton_Click(object sender, EventArgs e)
        {
            UpdateWorkersInRegion(new[] { currentRegionBeingViewed });
        }

        private void QueueReadTimer_Tick(object sender, EventArgs e)
        {
            foreach (var message in sqsCaller.GetMessages())
            {
                SqsMessage localMessage = message;
                QueueTextBox.UIThread(() => 
                    QueueTextBox.AppendText(string.Format("[{0:hh:MM}] {1}\r\n", DateTime.Now, localMessage.Message)));
                sqsCaller.DeleteMessage(message.ReceiptHandle);
            }
        }
    }
}
