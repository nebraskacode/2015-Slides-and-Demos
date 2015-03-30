using Aws.ControlPanel.Controls;

namespace Aws.ControlPanel
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.WorldTabPage = new System.Windows.Forms.TabPage();
            this.WorldBackgroundPanel = new System.Windows.Forms.Panel();
            this.UpdateAllWorkersButton = new System.Windows.Forms.Button();
            this.SaEastRegion = new Aws.ControlPanel.Controls.AwsRegionControl();
            this.AsiaSoutheast2Region = new Aws.ControlPanel.Controls.AwsRegionControl();
            this.AsiaSoutheast1Region = new Aws.ControlPanel.Controls.AwsRegionControl();
            this.AsiaNortheastRegion = new Aws.ControlPanel.Controls.AwsRegionControl();
            this.EuWestRegion = new Aws.ControlPanel.Controls.AwsRegionControl();
            this.UsWest1Region = new Aws.ControlPanel.Controls.AwsRegionControl();
            this.UsWest2Region = new Aws.ControlPanel.Controls.AwsRegionControl();
            this.UsEastRegion = new Aws.ControlPanel.Controls.AwsRegionControl();
            this.WorldRefreshButton = new System.Windows.Forms.Button();
            this.RegionDetailsTabPage = new System.Windows.Forms.TabPage();
            this.UpdateWorkersInRegionButton = new System.Windows.Forms.Button();
            this.RegionRefreshButton = new System.Windows.Forms.Button();
            this.RegionNameLabel = new System.Windows.Forms.Label();
            this.InstancesInRegionListView = new System.Windows.Forms.ListView();
            this.instanceID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.instanceStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.publicIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.workerStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.workerVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.currentLoad = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.QueueReadTimer = new System.Windows.Forms.Timer(this.components);
            this.QueueTextBox = new System.Windows.Forms.RichTextBox();
            this.MainTabControl.SuspendLayout();
            this.WorldTabPage.SuspendLayout();
            this.WorldBackgroundPanel.SuspendLayout();
            this.RegionDetailsTabPage.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.WorldTabPage);
            this.MainTabControl.Controls.Add(this.RegionDetailsTabPage);
            this.MainTabControl.Controls.Add(this.tabPage1);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Location = new System.Drawing.Point(0, 0);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(784, 561);
            this.MainTabControl.TabIndex = 5;
            // 
            // WorldTabPage
            // 
            this.WorldTabPage.Controls.Add(this.WorldBackgroundPanel);
            this.WorldTabPage.Location = new System.Drawing.Point(4, 22);
            this.WorldTabPage.Name = "WorldTabPage";
            this.WorldTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.WorldTabPage.Size = new System.Drawing.Size(776, 535);
            this.WorldTabPage.TabIndex = 0;
            this.WorldTabPage.Text = "World View";
            this.WorldTabPage.UseVisualStyleBackColor = true;
            // 
            // WorldBackgroundPanel
            // 
            this.WorldBackgroundPanel.BackgroundImage = global::Aws.ControlPanel.Properties.Resources.World;
            this.WorldBackgroundPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.WorldBackgroundPanel.Controls.Add(this.UpdateAllWorkersButton);
            this.WorldBackgroundPanel.Controls.Add(this.SaEastRegion);
            this.WorldBackgroundPanel.Controls.Add(this.AsiaSoutheast2Region);
            this.WorldBackgroundPanel.Controls.Add(this.AsiaSoutheast1Region);
            this.WorldBackgroundPanel.Controls.Add(this.AsiaNortheastRegion);
            this.WorldBackgroundPanel.Controls.Add(this.EuWestRegion);
            this.WorldBackgroundPanel.Controls.Add(this.UsWest1Region);
            this.WorldBackgroundPanel.Controls.Add(this.UsWest2Region);
            this.WorldBackgroundPanel.Controls.Add(this.UsEastRegion);
            this.WorldBackgroundPanel.Controls.Add(this.WorldRefreshButton);
            this.WorldBackgroundPanel.Location = new System.Drawing.Point(-4, 0);
            this.WorldBackgroundPanel.Name = "WorldBackgroundPanel";
            this.WorldBackgroundPanel.Size = new System.Drawing.Size(780, 541);
            this.WorldBackgroundPanel.TabIndex = 3;
            // 
            // UpdateAllWorkersButton
            // 
            this.UpdateAllWorkersButton.Location = new System.Drawing.Point(524, 6);
            this.UpdateAllWorkersButton.Name = "UpdateAllWorkersButton";
            this.UpdateAllWorkersButton.Size = new System.Drawing.Size(118, 23);
            this.UpdateAllWorkersButton.TabIndex = 9;
            this.UpdateAllWorkersButton.Text = "Update All Workers...";
            this.UpdateAllWorkersButton.UseVisualStyleBackColor = true;
            this.UpdateAllWorkersButton.Click += new System.EventHandler(this.UpdateAllWorkersButton_Click);
            // 
            // SaEastRegion
            // 
            this.SaEastRegion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SaEastRegion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SaEastRegion.Location = new System.Drawing.Point(237, 261);
            this.SaEastRegion.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.SaEastRegion.Name = "SaEastRegion";
            this.SaEastRegion.RegionDetails = null;
            this.SaEastRegion.RegionLocation = Aws.Core.Models.AwsRegionLocations.UsEast;
            this.SaEastRegion.Size = new System.Drawing.Size(88, 102);
            this.SaEastRegion.TabIndex = 7;
            // 
            // AsiaSoutheast2Region
            // 
            this.AsiaSoutheast2Region.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AsiaSoutheast2Region.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AsiaSoutheast2Region.Location = new System.Drawing.Point(660, 275);
            this.AsiaSoutheast2Region.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.AsiaSoutheast2Region.Name = "AsiaSoutheast2Region";
            this.AsiaSoutheast2Region.RegionDetails = null;
            this.AsiaSoutheast2Region.RegionLocation = Aws.Core.Models.AwsRegionLocations.UsEast;
            this.AsiaSoutheast2Region.Size = new System.Drawing.Size(88, 102);
            this.AsiaSoutheast2Region.TabIndex = 6;
            // 
            // AsiaSoutheast1Region
            // 
            this.AsiaSoutheast1Region.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AsiaSoutheast1Region.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AsiaSoutheast1Region.Location = new System.Drawing.Point(555, 199);
            this.AsiaSoutheast1Region.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.AsiaSoutheast1Region.Name = "AsiaSoutheast1Region";
            this.AsiaSoutheast1Region.RegionDetails = null;
            this.AsiaSoutheast1Region.RegionLocation = Aws.Core.Models.AwsRegionLocations.UsEast;
            this.AsiaSoutheast1Region.Size = new System.Drawing.Size(88, 102);
            this.AsiaSoutheast1Region.TabIndex = 5;
            // 
            // AsiaNortheastRegion
            // 
            this.AsiaNortheastRegion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AsiaNortheastRegion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AsiaNortheastRegion.Location = new System.Drawing.Point(648, 111);
            this.AsiaNortheastRegion.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.AsiaNortheastRegion.Name = "AsiaNortheastRegion";
            this.AsiaNortheastRegion.RegionDetails = null;
            this.AsiaNortheastRegion.RegionLocation = Aws.Core.Models.AwsRegionLocations.UsEast;
            this.AsiaNortheastRegion.Size = new System.Drawing.Size(88, 102);
            this.AsiaNortheastRegion.TabIndex = 4;
            // 
            // EuWestRegion
            // 
            this.EuWestRegion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EuWestRegion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EuWestRegion.Location = new System.Drawing.Point(331, 56);
            this.EuWestRegion.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.EuWestRegion.Name = "EuWestRegion";
            this.EuWestRegion.RegionDetails = null;
            this.EuWestRegion.RegionLocation = Aws.Core.Models.AwsRegionLocations.UsEast;
            this.EuWestRegion.Size = new System.Drawing.Size(88, 102);
            this.EuWestRegion.TabIndex = 3;
            // 
            // UsWest1Region
            // 
            this.UsWest1Region.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UsWest1Region.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UsWest1Region.Location = new System.Drawing.Point(88, 146);
            this.UsWest1Region.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.UsWest1Region.Name = "UsWest1Region";
            this.UsWest1Region.RegionDetails = null;
            this.UsWest1Region.RegionLocation = Aws.Core.Models.AwsRegionLocations.UsEast;
            this.UsWest1Region.Size = new System.Drawing.Size(88, 102);
            this.UsWest1Region.TabIndex = 2;
            // 
            // UsWest2Region
            // 
            this.UsWest2Region.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UsWest2Region.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UsWest2Region.Location = new System.Drawing.Point(60, 38);
            this.UsWest2Region.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.UsWest2Region.Name = "UsWest2Region";
            this.UsWest2Region.RegionDetails = null;
            this.UsWest2Region.RegionLocation = Aws.Core.Models.AwsRegionLocations.UsEast;
            this.UsWest2Region.Size = new System.Drawing.Size(88, 102);
            this.UsWest2Region.TabIndex = 1;
            // 
            // UsEastRegion
            // 
            this.UsEastRegion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UsEastRegion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UsEastRegion.Location = new System.Drawing.Point(194, 91);
            this.UsEastRegion.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.UsEastRegion.Name = "UsEastRegion";
            this.UsEastRegion.RegionDetails = null;
            this.UsEastRegion.RegionLocation = Aws.Core.Models.AwsRegionLocations.UsEast;
            this.UsEastRegion.Size = new System.Drawing.Size(88, 102);
            this.UsEastRegion.TabIndex = 0;
            // 
            // WorldRefreshButton
            // 
            this.WorldRefreshButton.Location = new System.Drawing.Point(648, 6);
            this.WorldRefreshButton.Name = "WorldRefreshButton";
            this.WorldRefreshButton.Size = new System.Drawing.Size(124, 23);
            this.WorldRefreshButton.TabIndex = 8;
            this.WorldRefreshButton.Text = "Refresh All Instances";
            this.WorldRefreshButton.UseVisualStyleBackColor = true;
            this.WorldRefreshButton.Click += new System.EventHandler(this.WorldRefreshButton_Click);
            // 
            // RegionDetailsTabPage
            // 
            this.RegionDetailsTabPage.Controls.Add(this.UpdateWorkersInRegionButton);
            this.RegionDetailsTabPage.Controls.Add(this.RegionRefreshButton);
            this.RegionDetailsTabPage.Controls.Add(this.RegionNameLabel);
            this.RegionDetailsTabPage.Controls.Add(this.InstancesInRegionListView);
            this.RegionDetailsTabPage.Location = new System.Drawing.Point(4, 22);
            this.RegionDetailsTabPage.Name = "RegionDetailsTabPage";
            this.RegionDetailsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.RegionDetailsTabPage.Size = new System.Drawing.Size(776, 535);
            this.RegionDetailsTabPage.TabIndex = 1;
            this.RegionDetailsTabPage.Text = "Region Details";
            this.RegionDetailsTabPage.UseVisualStyleBackColor = true;
            // 
            // UpdateWorkersInRegionButton
            // 
            this.UpdateWorkersInRegionButton.Location = new System.Drawing.Point(509, 5);
            this.UpdateWorkersInRegionButton.Name = "UpdateWorkersInRegionButton";
            this.UpdateWorkersInRegionButton.Size = new System.Drawing.Size(154, 23);
            this.UpdateWorkersInRegionButton.TabIndex = 10;
            this.UpdateWorkersInRegionButton.Text = "Update Workers in Region...";
            this.UpdateWorkersInRegionButton.UseVisualStyleBackColor = true;
            this.UpdateWorkersInRegionButton.Click += new System.EventHandler(this.UpdateWorkersInRegionButton_Click);
            // 
            // RegionRefreshButton
            // 
            this.RegionRefreshButton.Location = new System.Drawing.Point(669, 5);
            this.RegionRefreshButton.Name = "RegionRefreshButton";
            this.RegionRefreshButton.Size = new System.Drawing.Size(99, 23);
            this.RegionRefreshButton.TabIndex = 9;
            this.RegionRefreshButton.Text = "Refresh Workers";
            this.RegionRefreshButton.UseVisualStyleBackColor = true;
            this.RegionRefreshButton.Click += new System.EventHandler(this.RegionRefreshButton_Click);
            // 
            // RegionNameLabel
            // 
            this.RegionNameLabel.AutoSize = true;
            this.RegionNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegionNameLabel.Location = new System.Drawing.Point(6, 7);
            this.RegionNameLabel.Name = "RegionNameLabel";
            this.RegionNameLabel.Size = new System.Drawing.Size(94, 24);
            this.RegionNameLabel.TabIndex = 3;
            this.RegionNameLabel.Text = "region-id";
            // 
            // InstancesInRegionListView
            // 
            this.InstancesInRegionListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.instanceID,
            this.instanceStatus,
            this.publicIP,
            this.workerStatus,
            this.workerVersion,
            this.currentLoad});
            this.InstancesInRegionListView.FullRowSelect = true;
            this.InstancesInRegionListView.Location = new System.Drawing.Point(10, 34);
            this.InstancesInRegionListView.Name = "InstancesInRegionListView";
            this.InstancesInRegionListView.Size = new System.Drawing.Size(760, 493);
            this.InstancesInRegionListView.TabIndex = 1;
            this.InstancesInRegionListView.UseCompatibleStateImageBehavior = false;
            this.InstancesInRegionListView.View = System.Windows.Forms.View.Details;
            // 
            // instanceID
            // 
            this.instanceID.Text = "Instance ID";
            this.instanceID.Width = 100;
            // 
            // instanceStatus
            // 
            this.instanceStatus.Text = "Instance Status";
            this.instanceStatus.Width = 100;
            // 
            // publicIP
            // 
            this.publicIP.Text = "Public IP";
            this.publicIP.Width = 100;
            // 
            // workerStatus
            // 
            this.workerStatus.Text = "Worker Status";
            this.workerStatus.Width = 100;
            // 
            // workerVersion
            // 
            this.workerVersion.Text = "Worker Version";
            this.workerVersion.Width = 100;
            // 
            // currentLoad
            // 
            this.currentLoad.Text = "Current Load";
            this.currentLoad.Width = 100;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.QueueTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(776, 535);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "QueueView";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // QueueReadTimer
            // 
            this.QueueReadTimer.Enabled = true;
            this.QueueReadTimer.Interval = 5000;
            this.QueueReadTimer.Tick += new System.EventHandler(this.QueueReadTimer_Tick);
            // 
            // QueueTextBox
            // 
            this.QueueTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QueueTextBox.Location = new System.Drawing.Point(0, 0);
            this.QueueTextBox.Name = "QueueTextBox";
            this.QueueTextBox.Size = new System.Drawing.Size(776, 535);
            this.QueueTextBox.TabIndex = 0;
            this.QueueTextBox.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.MainTabControl);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AWS Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainTabControl.ResumeLayout(false);
            this.WorldTabPage.ResumeLayout(false);
            this.WorldBackgroundPanel.ResumeLayout(false);
            this.RegionDetailsTabPage.ResumeLayout(false);
            this.RegionDetailsTabPage.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage WorldTabPage;
        private System.Windows.Forms.Panel WorldBackgroundPanel;
        private System.Windows.Forms.TabPage RegionDetailsTabPage;
        private AwsRegionControl UsEastRegion;
        private AwsRegionControl SaEastRegion;
        private AwsRegionControl AsiaSoutheast2Region;
        private AwsRegionControl AsiaSoutheast1Region;
        private AwsRegionControl AsiaNortheastRegion;
        private AwsRegionControl EuWestRegion;
        private AwsRegionControl UsWest1Region;
        private AwsRegionControl UsWest2Region;
        private System.Windows.Forms.Button WorldRefreshButton;
        private System.Windows.Forms.Label RegionNameLabel;
        private System.Windows.Forms.ListView InstancesInRegionListView;
        private System.Windows.Forms.ColumnHeader instanceID;
        private System.Windows.Forms.ColumnHeader publicIP;
        private System.Windows.Forms.ColumnHeader workerVersion;
        private System.Windows.Forms.ColumnHeader currentLoad;
        private System.Windows.Forms.ColumnHeader instanceStatus;
        private System.Windows.Forms.ColumnHeader workerStatus;
        private System.Windows.Forms.Button RegionRefreshButton;
        private System.Windows.Forms.Button UpdateWorkersInRegionButton;
        private System.Windows.Forms.Button UpdateAllWorkersButton;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Timer QueueReadTimer;
        private System.Windows.Forms.RichTextBox QueueTextBox;

    }
}

