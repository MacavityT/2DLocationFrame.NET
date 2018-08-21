namespace IntegrationTesting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonRun = new System.Windows.Forms.Button();
            this.aqDisplayLocation = new AqVision.Controls.AqDisplay();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemSetParameter = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemSetAcqusition = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemSetCalibration = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemSetLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemSetDectection = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemSetRobotConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemLog = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerhorizontal = new System.Windows.Forms.SplitContainer();
            this.splitContainerVertical = new System.Windows.Forms.SplitContainer();
            this.aqDisplayDectection = new AqVision.Controls.AqDisplay();
            this.checkBoxCameraDetection = new System.Windows.Forms.CheckBox();
            this.listViewRecord = new System.Windows.Forms.ListView();
            this.buttonStop = new System.Windows.Forms.Button();
            this.checkBoxCameraAcquisition = new System.Windows.Forms.CheckBox();
            this.splitContainerMainStatus = new System.Windows.Forms.SplitContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerhorizontal)).BeginInit();
            this.splitContainerhorizontal.Panel1.SuspendLayout();
            this.splitContainerhorizontal.Panel2.SuspendLayout();
            this.splitContainerhorizontal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVertical)).BeginInit();
            this.splitContainerVertical.Panel1.SuspendLayout();
            this.splitContainerVertical.Panel2.SuspendLayout();
            this.splitContainerVertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMainStatus)).BeginInit();
            this.splitContainerMainStatus.Panel1.SuspendLayout();
            this.splitContainerMainStatus.Panel2.SuspendLayout();
            this.splitContainerMainStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonRun
            // 
            this.buttonRun.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonRun.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonRun.Image = global::IntegrationTesting.Properties.Resources.Run;
            this.buttonRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRun.Location = new System.Drawing.Point(0, 554);
            this.buttonRun.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(123, 58);
            this.buttonRun.TabIndex = 3;
            this.buttonRun.Text = "运行";
            this.buttonRun.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // aqDisplayLocation
            // 
            this.aqDisplayLocation.AutoScroll = true;
            this.aqDisplayLocation.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.aqDisplayLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aqDisplayLocation.Image = null;
            this.aqDisplayLocation.Location = new System.Drawing.Point(0, 0);
            this.aqDisplayLocation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.aqDisplayLocation.Name = "aqDisplayLocation";
            this.aqDisplayLocation.ScrollBar = false;
            this.aqDisplayLocation.Size = new System.Drawing.Size(304, 612);
            this.aqDisplayLocation.TabIndex = 0;
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemSetParameter,
            this.ToolStripMenuItemHelp});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(857, 25);
            this.menuStripMain.TabIndex = 9;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // ToolStripMenuItemSetParameter
            // 
            this.ToolStripMenuItemSetParameter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemSetAcqusition,
            this.ToolStripMenuItemSetCalibration,
            this.ToolStripMenuItemSetLocation,
            this.ToolStripMenuItemSetDectection,
            this.ToolStripMenuItemSetRobotConnect});
            this.ToolStripMenuItemSetParameter.Name = "ToolStripMenuItemSetParameter";
            this.ToolStripMenuItemSetParameter.Size = new System.Drawing.Size(68, 21);
            this.ToolStripMenuItemSetParameter.Text = "参数设置";
            // 
            // ToolStripMenuItemSetAcqusition
            // 
            this.ToolStripMenuItemSetAcqusition.Name = "ToolStripMenuItemSetAcqusition";
            this.ToolStripMenuItemSetAcqusition.Size = new System.Drawing.Size(160, 22);
            this.ToolStripMenuItemSetAcqusition.Text = "取像设置";
            this.ToolStripMenuItemSetAcqusition.Click += new System.EventHandler(this.ToolStripMenuItemSetAcqusition_Click);
            // 
            // ToolStripMenuItemSetCalibration
            // 
            this.ToolStripMenuItemSetCalibration.Name = "ToolStripMenuItemSetCalibration";
            this.ToolStripMenuItemSetCalibration.Size = new System.Drawing.Size(160, 22);
            this.ToolStripMenuItemSetCalibration.Text = "标定设置";
            this.ToolStripMenuItemSetCalibration.Click += new System.EventHandler(this.ToolStripMenuItemSetCalibration_Click);
            // 
            // ToolStripMenuItemSetLocation
            // 
            this.ToolStripMenuItemSetLocation.Name = "ToolStripMenuItemSetLocation";
            this.ToolStripMenuItemSetLocation.Size = new System.Drawing.Size(160, 22);
            this.ToolStripMenuItemSetLocation.Text = "定位设置";
            this.ToolStripMenuItemSetLocation.Click += new System.EventHandler(this.ToolStripMenuItemSetLocation_Click);
            // 
            // ToolStripMenuItemSetDectection
            // 
            this.ToolStripMenuItemSetDectection.Name = "ToolStripMenuItemSetDectection";
            this.ToolStripMenuItemSetDectection.Size = new System.Drawing.Size(160, 22);
            this.ToolStripMenuItemSetDectection.Text = "检测设置";
            this.ToolStripMenuItemSetDectection.Click += new System.EventHandler(this.ToolStripMenuItemSetDectection_Click);
            // 
            // ToolStripMenuItemSetRobotConnect
            // 
            this.ToolStripMenuItemSetRobotConnect.Name = "ToolStripMenuItemSetRobotConnect";
            this.ToolStripMenuItemSetRobotConnect.Size = new System.Drawing.Size(160, 22);
            this.ToolStripMenuItemSetRobotConnect.Text = "机器人通讯设置";
            this.ToolStripMenuItemSetRobotConnect.Click += new System.EventHandler(this.ToolStripMenuItemSetRobotConnect_Click);
            // 
            // ToolStripMenuItemHelp
            // 
            this.ToolStripMenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemLog});
            this.ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            this.ToolStripMenuItemHelp.Size = new System.Drawing.Size(44, 21);
            this.ToolStripMenuItemHelp.Text = "帮助";
            // 
            // ToolStripMenuItemLog
            // 
            this.ToolStripMenuItemLog.Name = "ToolStripMenuItemLog";
            this.ToolStripMenuItemLog.Size = new System.Drawing.Size(124, 22);
            this.ToolStripMenuItemLog.Text = "日志信息";
            // 
            // splitContainerhorizontal
            // 
            this.splitContainerhorizontal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerhorizontal.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerhorizontal.Location = new System.Drawing.Point(0, 0);
            this.splitContainerhorizontal.Name = "splitContainerhorizontal";
            // 
            // splitContainerhorizontal.Panel1
            // 
            this.splitContainerhorizontal.Panel1.Controls.Add(this.splitContainerVertical);
            // 
            // splitContainerhorizontal.Panel2
            // 
            this.splitContainerhorizontal.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerhorizontal.Panel2.Controls.Add(this.checkBoxCameraDetection);
            this.splitContainerhorizontal.Panel2.Controls.Add(this.listViewRecord);
            this.splitContainerhorizontal.Panel2.Controls.Add(this.buttonStop);
            this.splitContainerhorizontal.Panel2.Controls.Add(this.buttonRun);
            this.splitContainerhorizontal.Panel2.Controls.Add(this.checkBoxCameraAcquisition);
            this.splitContainerhorizontal.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainerhorizontal.Size = new System.Drawing.Size(857, 612);
            this.splitContainerhorizontal.SplitterDistance = 730;
            this.splitContainerhorizontal.TabIndex = 10;
            // 
            // splitContainerVertical
            // 
            this.splitContainerVertical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerVertical.Location = new System.Drawing.Point(0, 0);
            this.splitContainerVertical.Name = "splitContainerVertical";
            // 
            // splitContainerVertical.Panel1
            // 
            this.splitContainerVertical.Panel1.Controls.Add(this.aqDisplayLocation);
            // 
            // splitContainerVertical.Panel2
            // 
            this.splitContainerVertical.Panel2.Controls.Add(this.aqDisplayDectection);
            this.splitContainerVertical.Size = new System.Drawing.Size(730, 612);
            this.splitContainerVertical.SplitterDistance = 304;
            this.splitContainerVertical.TabIndex = 0;
            // 
            // aqDisplayDectection
            // 
            this.aqDisplayDectection.AutoScroll = true;
            this.aqDisplayDectection.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.aqDisplayDectection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aqDisplayDectection.Image = null;
            this.aqDisplayDectection.Location = new System.Drawing.Point(0, 0);
            this.aqDisplayDectection.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.aqDisplayDectection.Name = "aqDisplayDectection";
            this.aqDisplayDectection.ScrollBar = false;
            this.aqDisplayDectection.Size = new System.Drawing.Size(422, 612);
            this.aqDisplayDectection.TabIndex = 1;
            // 
            // checkBoxCameraDetection
            // 
            this.checkBoxCameraDetection.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxCameraDetection.BackColor = System.Drawing.SystemColors.Control;
            this.checkBoxCameraDetection.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBoxCameraDetection.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBoxCameraDetection.Image = ((System.Drawing.Image)(resources.GetObject("checkBoxCameraDetection.Image")));
            this.checkBoxCameraDetection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBoxCameraDetection.Location = new System.Drawing.Point(0, 32);
            this.checkBoxCameraDetection.Name = "checkBoxCameraDetection";
            this.checkBoxCameraDetection.Size = new System.Drawing.Size(123, 32);
            this.checkBoxCameraDetection.TabIndex = 10;
            this.checkBoxCameraDetection.Text = "开启检测实时采集";
            this.checkBoxCameraDetection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxCameraDetection.UseVisualStyleBackColor = false;
            this.checkBoxCameraDetection.CheckedChanged += new System.EventHandler(this.checkBoxCameraDetection_CheckedChanged);
            // 
            // listViewRecord
            // 
            this.listViewRecord.FullRowSelect = true;
            this.listViewRecord.GridLines = true;
            this.listViewRecord.LabelEdit = true;
            this.listViewRecord.Location = new System.Drawing.Point(0, 108);
            this.listViewRecord.MultiSelect = false;
            this.listViewRecord.Name = "listViewRecord";
            this.listViewRecord.Size = new System.Drawing.Size(111, 364);
            this.listViewRecord.TabIndex = 9;
            this.listViewRecord.UseCompatibleStateImageBehavior = false;
            this.listViewRecord.View = System.Windows.Forms.View.Details;
            // 
            // buttonStop
            // 
            this.buttonStop.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonStop.Enabled = false;
            this.buttonStop.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonStop.Image = global::IntegrationTesting.Properties.Resources.Stop;
            this.buttonStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonStop.Location = new System.Drawing.Point(0, 489);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(123, 65);
            this.buttonStop.TabIndex = 3;
            this.buttonStop.Text = "停止";
            this.buttonStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // checkBoxCameraAcquisition
            // 
            this.checkBoxCameraAcquisition.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxCameraAcquisition.BackColor = System.Drawing.SystemColors.Control;
            this.checkBoxCameraAcquisition.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBoxCameraAcquisition.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBoxCameraAcquisition.Image = ((System.Drawing.Image)(resources.GetObject("checkBoxCameraAcquisition.Image")));
            this.checkBoxCameraAcquisition.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBoxCameraAcquisition.Location = new System.Drawing.Point(0, 0);
            this.checkBoxCameraAcquisition.Name = "checkBoxCameraAcquisition";
            this.checkBoxCameraAcquisition.Size = new System.Drawing.Size(123, 32);
            this.checkBoxCameraAcquisition.TabIndex = 6;
            this.checkBoxCameraAcquisition.Text = "开启定位实时采集";
            this.checkBoxCameraAcquisition.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxCameraAcquisition.UseVisualStyleBackColor = false;
            this.checkBoxCameraAcquisition.CheckedChanged += new System.EventHandler(this.checkBoxCameraAcquisition_CheckedChanged);
            // 
            // splitContainerMainStatus
            // 
            this.splitContainerMainStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMainStatus.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerMainStatus.Location = new System.Drawing.Point(0, 25);
            this.splitContainerMainStatus.Name = "splitContainerMainStatus";
            this.splitContainerMainStatus.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMainStatus.Panel1
            // 
            this.splitContainerMainStatus.Panel1.Controls.Add(this.splitContainerhorizontal);
            // 
            // splitContainerMainStatus.Panel2
            // 
            this.splitContainerMainStatus.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainerMainStatus.Size = new System.Drawing.Size(857, 641);
            this.splitContainerMainStatus.SplitterDistance = 612;
            this.splitContainerMainStatus.TabIndex = 12;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 3);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(857, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 666);
            this.Controls.Add(this.splitContainerMainStatus);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "MainForm";
            this.Text = "FormShow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.splitContainerhorizontal.Panel1.ResumeLayout(false);
            this.splitContainerhorizontal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerhorizontal)).EndInit();
            this.splitContainerhorizontal.ResumeLayout(false);
            this.splitContainerVertical.Panel1.ResumeLayout(false);
            this.splitContainerVertical.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVertical)).EndInit();
            this.splitContainerVertical.ResumeLayout(false);
            this.splitContainerMainStatus.Panel1.ResumeLayout(false);
            this.splitContainerMainStatus.Panel2.ResumeLayout(false);
            this.splitContainerMainStatus.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMainStatus)).EndInit();
            this.splitContainerMainStatus.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AqVision.Controls.AqDisplay aqDisplayLocation;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.CheckBox checkBoxCameraAcquisition;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSetParameter;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSetAcqusition;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSetCalibration;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSetLocation;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSetDectection;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSetRobotConnect;
        private System.Windows.Forms.SplitContainer splitContainerhorizontal;
        private System.Windows.Forms.SplitContainer splitContainerVertical;
        private AqVision.Controls.AqDisplay aqDisplayDectection;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemLog;
        private System.Windows.Forms.CheckBox checkBoxCameraDetection;
        private System.Windows.Forms.ListView listViewRecord;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.SplitContainer splitContainerMainStatus;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}

