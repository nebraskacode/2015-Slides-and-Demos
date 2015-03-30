namespace Aws.ControlPanel.Controls
{
    partial class AwsRegionControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RegionIdLabel = new System.Windows.Forms.Label();
            this.RunningInstancesLabel = new System.Windows.Forms.Label();
            this.PendingInstancesLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AddInstanceButton = new System.Windows.Forms.Button();
            this.StopInstanceButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RegionIdLabel
            // 
            this.RegionIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegionIdLabel.ForeColor = System.Drawing.Color.White;
            this.RegionIdLabel.Location = new System.Drawing.Point(-1, 2);
            this.RegionIdLabel.Margin = new System.Windows.Forms.Padding(0);
            this.RegionIdLabel.Name = "RegionIdLabel";
            this.RegionIdLabel.Size = new System.Drawing.Size(90, 20);
            this.RegionIdLabel.TabIndex = 0;
            this.RegionIdLabel.Text = "-";
            this.RegionIdLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RegionIdLabel.Click += new System.EventHandler(this.RegionIdLabel_Click);
            // 
            // RunningInstancesLabel
            // 
            this.RunningInstancesLabel.AutoSize = true;
            this.RunningInstancesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunningInstancesLabel.ForeColor = System.Drawing.Color.Lime;
            this.RunningInstancesLabel.Location = new System.Drawing.Point(52, 23);
            this.RunningInstancesLabel.Name = "RunningInstancesLabel";
            this.RunningInstancesLabel.Size = new System.Drawing.Size(15, 20);
            this.RunningInstancesLabel.TabIndex = 1;
            this.RunningInstancesLabel.Text = "-";
            // 
            // PendingInstancesLabel
            // 
            this.PendingInstancesLabel.AutoSize = true;
            this.PendingInstancesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PendingInstancesLabel.ForeColor = System.Drawing.Color.Yellow;
            this.PendingInstancesLabel.Location = new System.Drawing.Point(52, 46);
            this.PendingInstancesLabel.Name = "PendingInstancesLabel";
            this.PendingInstancesLabel.Size = new System.Drawing.Size(15, 20);
            this.PendingInstancesLabel.TabIndex = 2;
            this.PendingInstancesLabel.Text = "-";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Aws.ControlPanel.Controls.Properties.Resources.servers;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(12, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(32, 32);
            this.panel1.TabIndex = 3;
            // 
            // AddInstanceButton
            // 
            this.AddInstanceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddInstanceButton.Location = new System.Drawing.Point(46, 69);
            this.AddInstanceButton.Margin = new System.Windows.Forms.Padding(0);
            this.AddInstanceButton.Name = "AddInstanceButton";
            this.AddInstanceButton.Size = new System.Drawing.Size(31, 23);
            this.AddInstanceButton.TabIndex = 4;
            this.AddInstanceButton.Text = "+";
            this.AddInstanceButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.AddInstanceButton.UseVisualStyleBackColor = true;
            this.AddInstanceButton.Click += new System.EventHandler(this.AddInstanceButton_Click);
            // 
            // StopInstanceButton
            // 
            this.StopInstanceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopInstanceButton.Location = new System.Drawing.Point(9, 69);
            this.StopInstanceButton.Margin = new System.Windows.Forms.Padding(0);
            this.StopInstanceButton.Name = "StopInstanceButton";
            this.StopInstanceButton.Size = new System.Drawing.Size(31, 23);
            this.StopInstanceButton.TabIndex = 5;
            this.StopInstanceButton.Text = "-";
            this.StopInstanceButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.StopInstanceButton.UseVisualStyleBackColor = true;
            this.StopInstanceButton.Click += new System.EventHandler(this.StopInstanceButton_Click);
            // 
            // AwsRegionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.StopInstanceButton);
            this.Controls.Add(this.AddInstanceButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PendingInstancesLabel);
            this.Controls.Add(this.RunningInstancesLabel);
            this.Controls.Add(this.RegionIdLabel);
            this.Name = "AwsRegionControl";
            this.Size = new System.Drawing.Size(88, 102);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RegionIdLabel;
        private System.Windows.Forms.Label RunningInstancesLabel;
        private System.Windows.Forms.Label PendingInstancesLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button AddInstanceButton;
        private System.Windows.Forms.Button StopInstanceButton;
    }
}
