using System;
using System.Windows.Forms;
using Aws.Core.Models;

namespace Aws.ControlPanel.Controls
{
    public partial class AwsRegionControl : UserControl
    {
        private RegionDetails regionDetails;
        public RegionDetails RegionDetails
        {
            get { return regionDetails; }
            set
            {
                regionDetails = value;
                if (value != null)
                {
                    RegionIdLabel.Text = value.Name;
                    RunningInstancesLabel.Text = value.RunningInstancesCount.ToString();
                    PendingInstancesLabel.Text = value.PendingInstancesCount.ToString();
                }
                else
                {
                    RegionIdLabel.Text = "-";
                    RunningInstancesLabel.Text = "-";
                    PendingInstancesLabel.Text = "-";
                }
            }
        }

        public AwsRegionLocations RegionLocation { get; set; }

        public AwsRegionControl()
        {
            InitializeComponent();
            //AwsRegion = new Region();
        }

        private void RegionIdLabel_Click(object sender, EventArgs e)
        {
            if (regionDetails != null)
            {
                OnRegionIdLabelClicked(regionDetails.Region);
            }
        }

        private void AddInstanceButton_Click(object sender, EventArgs e)
        {
            OnAddInstanceButtonClicked(regionDetails.Region);
        }

        private void StopInstanceButton_Click(object sender, EventArgs e)
        {
            OnRemoveInstanceButtonClicked(regionDetails.Region);
        }

        public event EventHandler<AwsRegionLocations> RegionIdLabelClicked;
        protected virtual void OnRegionIdLabelClicked(AwsRegionLocations e)
        {
            var handler = RegionIdLabelClicked;
            if (handler != null) handler(this, e);
        }

        public event EventHandler<AwsRegionLocations> AddInstanceButtonClicked;
        protected virtual void OnAddInstanceButtonClicked(AwsRegionLocations e)
        {
            var handler = AddInstanceButtonClicked;
            if (handler != null) handler(this, e);
        }

        public event EventHandler<AwsRegionLocations> RemoveInstanceButtonClicked;
        protected virtual void OnRemoveInstanceButtonClicked(AwsRegionLocations e)
        {
            var handler = RemoveInstanceButtonClicked;
            if (handler != null) handler(this, e);
        }
    }
}
