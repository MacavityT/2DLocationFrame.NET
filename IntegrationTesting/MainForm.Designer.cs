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
            this.splitDownResultShow = new System.Windows.Forms.SplitContainer();
            this.splitUpContainerTitle = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainerAqDisplayControls = new System.Windows.Forms.SplitContainer();
            this.aqDisplayDectection = new AqVision.Controls.AqDisplay();
            this.splitContainerDisplayShow = new System.Windows.Forms.SplitContainer();
            this.buttonStop = new System.Windows.Forms.Button();
            this.groupBoxTest = new System.Windows.Forms.GroupBox();
            this.listViewRecord = new System.Windows.Forms.ListView();
            this.checkBoxCameraAcquisition = new System.Windows.Forms.CheckBox();
            this.checkBoxCameraDetection = new System.Windows.Forms.CheckBox();
            this.buttonTriggerDetectionRPC = new System.Windows.Forms.Button();
            this.buttonTriggerLocationRPC = new System.Windows.Forms.Button();
            this.splitContainerMainStatus = new System.Windows.Forms.SplitContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitDownResultShow)).BeginInit();
            this.splitDownResultShow.Panel1.SuspendLayout();
            this.splitDownResultShow.Panel2.SuspendLayout();
            this.splitDownResultShow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitUpContainerTitle)).BeginInit();
            this.splitUpContainerTitle.Panel1.SuspendLayout();
            this.splitUpContainerTitle.Panel2.SuspendLayout();
            this.splitUpContainerTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAqDisplayControls)).BeginInit();
            this.splitContainerAqDisplayControls.Panel1.SuspendLayout();
            this.splitContainerAqDisplayControls.Panel2.SuspendLayout();
            this.splitContainerAqDisplayControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDisplayShow)).BeginInit();
            this.splitContainerDisplayShow.Panel1.SuspendLayout();
            this.splitContainerDisplayShow.Panel2.SuspendLayout();
            this.splitContainerDisplayShow.SuspendLayout();
            this.groupBoxTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMainStatus)).BeginInit();
            this.splitContainerMainStatus.Panel1.SuspendLayout();
            this.splitContainerMainStatus.Panel2.SuspendLayout();
            this.splitContainerMainStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonRun
            // 
            this.buttonRun.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonRun.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonRun.Image = global::IntegrationTesting.Properties.Resources.Run;
            this.buttonRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRun.Location = new System.Drawing.Point(0, 0);
            this.buttonRun.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(113, 53);
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
            this.aqDisplayLocation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.aqDisplayLocation.Name = "aqDisplayLocation";
            this.aqDisplayLocation.ScrollBar = false;
            this.aqDisplayLocation.Size = new System.Drawing.Size(955, 824);
            this.aqDisplayLocation.TabIndex = 0;
            // 
            // menuStripMain
            // 
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemSetParameter,
            this.ToolStripMenuItemHelp});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStripMain.Size = new System.Drawing.Size(1902, 28);
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
            this.ToolStripMenuItemSetParameter.Size = new System.Drawing.Size(81, 24);
            this.ToolStripMenuItemSetParameter.Text = "参数设置";
            // 
            // ToolStripMenuItemSetAcqusition
            // 
            this.ToolStripMenuItemSetAcqusition.Name = "ToolStripMenuItemSetAcqusition";
            this.ToolStripMenuItemSetAcqusition.Size = new System.Drawing.Size(189, 26);
            this.ToolStripMenuItemSetAcqusition.Text = "取像设置";
            this.ToolStripMenuItemSetAcqusition.Click += new System.EventHandler(this.ToolStripMenuItemSetAcqusition_Click);
            // 
            // ToolStripMenuItemSetCalibration
            // 
            this.ToolStripMenuItemSetCalibration.Name = "ToolStripMenuItemSetCalibration";
            this.ToolStripMenuItemSetCalibration.Size = new System.Drawing.Size(189, 26);
            this.ToolStripMenuItemSetCalibration.Text = "标定设置";
            this.ToolStripMenuItemSetCalibration.Click += new System.EventHandler(this.ToolStripMenuItemSetCalibration_Click);
            // 
            // ToolStripMenuItemSetLocation
            // 
            this.ToolStripMenuItemSetLocation.Name = "ToolStripMenuItemSetLocation";
            this.ToolStripMenuItemSetLocation.Size = new System.Drawing.Size(189, 26);
            this.ToolStripMenuItemSetLocation.Text = "定位设置";
            this.ToolStripMenuItemSetLocation.Click += new System.EventHandler(this.ToolStripMenuItemSetLocation_Click);
            // 
            // ToolStripMenuItemSetDectection
            // 
            this.ToolStripMenuItemSetDectection.Name = "ToolStripMenuItemSetDectection";
            this.ToolStripMenuItemSetDectection.Size = new System.Drawing.Size(189, 26);
            this.ToolStripMenuItemSetDectection.Text = "检测设置";
            this.ToolStripMenuItemSetDectection.Click += new System.EventHandler(this.ToolStripMenuItemSetDectection_Click);
            // 
            // ToolStripMenuItemSetRobotConnect
            // 
            this.ToolStripMenuItemSetRobotConnect.Name = "ToolStripMenuItemSetRobotConnect";
            this.ToolStripMenuItemSetRobotConnect.Size = new System.Drawing.Size(189, 26);
            this.ToolStripMenuItemSetRobotConnect.Text = "机器人通讯设置";
            this.ToolStripMenuItemSetRobotConnect.Click += new System.EventHandler(this.ToolStripMenuItemSetRobotConnect_Click);
            // 
            // ToolStripMenuItemHelp
            // 
            this.ToolStripMenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemLog});
            this.ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            this.ToolStripMenuItemHelp.Size = new System.Drawing.Size(51, 24);
            this.ToolStripMenuItemHelp.Text = "帮助";
            // 
            // ToolStripMenuItemLog
            // 
            this.ToolStripMenuItemLog.Name = "ToolStripMenuItemLog";
            this.ToolStripMenuItemLog.Size = new System.Drawing.Size(144, 26);
            this.ToolStripMenuItemLog.Text = "日志信息";
            // 
            // splitDownResultShow
            // 
            this.splitDownResultShow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitDownResultShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitDownResultShow.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitDownResultShow.Location = new System.Drawing.Point(0, 0);
            this.splitDownResultShow.Margin = new System.Windows.Forms.Padding(4);
            this.splitDownResultShow.Name = "splitDownResultShow";
            this.splitDownResultShow.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitDownResultShow.Panel1
            // 
            this.splitDownResultShow.Panel1.Controls.Add(this.splitUpContainerTitle);
            // 
            // splitDownResultShow.Panel2
            // 
            this.splitDownResultShow.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitDownResultShow.Panel2.Controls.Add(this.splitContainerDisplayShow);
            this.splitDownResultShow.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitDownResultShow.Size = new System.Drawing.Size(1902, 970);
            this.splitDownResultShow.SplitterDistance = 910;
            this.splitDownResultShow.SplitterWidth = 5;
            this.splitDownResultShow.TabIndex = 10;
            // 
            // splitUpContainerTitle
            // 
            this.splitUpContainerTitle.BackColor = System.Drawing.SystemColors.Control;
            this.splitUpContainerTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitUpContainerTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitUpContainerTitle.Location = new System.Drawing.Point(0, 0);
            this.splitUpContainerTitle.Name = "splitUpContainerTitle";
            this.splitUpContainerTitle.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitUpContainerTitle.Panel1
            // 
            this.splitUpContainerTitle.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.splitUpContainerTitle.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.splitUpContainerTitle.Panel1.Controls.Add(this.label2);
            this.splitUpContainerTitle.Panel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            // 
            // splitUpContainerTitle.Panel2
            // 
            this.splitUpContainerTitle.Panel2.Controls.Add(this.splitContainerAqDisplayControls);
            this.splitUpContainerTitle.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitUpContainerTitle_Panel2_Paint);
            this.splitUpContainerTitle.Size = new System.Drawing.Size(1902, 910);
            this.splitUpContainerTitle.SplitterDistance = 80;
            this.splitUpContainerTitle.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(580, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(625, 60);
            this.label2.TabIndex = 0;
            this.label2.Text = "三通管定位及缺陷检测";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainerAqDisplayControls
            // 
            this.splitContainerAqDisplayControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerAqDisplayControls.Location = new System.Drawing.Point(0, 0);
            this.splitContainerAqDisplayControls.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainerAqDisplayControls.Name = "splitContainerAqDisplayControls";
            // 
            // splitContainerAqDisplayControls.Panel1
            // 
            this.splitContainerAqDisplayControls.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerAqDisplayControls.Panel1.Controls.Add(this.aqDisplayLocation);
            // 
            // splitContainerAqDisplayControls.Panel2
            // 
            this.splitContainerAqDisplayControls.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerAqDisplayControls.Panel2.Controls.Add(this.aqDisplayDectection);
            this.splitContainerAqDisplayControls.Size = new System.Drawing.Size(1900, 824);
            this.splitContainerAqDisplayControls.SplitterDistance = 955;
            this.splitContainerAqDisplayControls.SplitterWidth = 5;
            this.splitContainerAqDisplayControls.TabIndex = 0;
            // 
            // aqDisplayDectection
            // 
            this.aqDisplayDectection.AutoScroll = true;
            this.aqDisplayDectection.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.aqDisplayDectection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aqDisplayDectection.Image = null;
            this.aqDisplayDectection.Location = new System.Drawing.Point(0, 0);
            this.aqDisplayDectection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.aqDisplayDectection.Name = "aqDisplayDectection";
            this.aqDisplayDectection.ScrollBar = false;
            this.aqDisplayDectection.Size = new System.Drawing.Size(940, 824);
            this.aqDisplayDectection.TabIndex = 1;
            // 
            // splitContainerDisplayShow
            // 
            this.splitContainerDisplayShow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerDisplayShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerDisplayShow.Location = new System.Drawing.Point(0, 0);
            this.splitContainerDisplayShow.Name = "splitContainerDisplayShow";
            // 
            // splitContainerDisplayShow.Panel1
            // 
            this.splitContainerDisplayShow.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainerDisplayShow.Panel1.Controls.Add(this.buttonStop);
            this.splitContainerDisplayShow.Panel1.Controls.Add(this.groupBoxTest);
            this.splitContainerDisplayShow.Panel1.Controls.Add(this.checkBoxCameraAcquisition);
            this.splitContainerDisplayShow.Panel1.Controls.Add(this.checkBoxCameraDetection);
            // 
            // splitContainerDisplayShow.Panel2
            // 
            this.splitContainerDisplayShow.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainerDisplayShow.Panel2.Controls.Add(this.buttonRun);
            this.splitContainerDisplayShow.Panel2.Controls.Add(this.buttonTriggerDetectionRPC);
            this.splitContainerDisplayShow.Panel2.Controls.Add(this.buttonTriggerLocationRPC);
            this.splitContainerDisplayShow.Panel2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.splitContainerDisplayShow.Size = new System.Drawing.Size(1902, 55);
            this.splitContainerDisplayShow.SplitterDistance = 957;
            this.splitContainerDisplayShow.TabIndex = 13;
            // 
            // buttonStop
            // 
            this.buttonStop.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonStop.Enabled = false;
            this.buttonStop.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonStop.Image = global::IntegrationTesting.Properties.Resources.Stop;
            this.buttonStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonStop.Location = new System.Drawing.Point(840, 0);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(115, 53);
            this.buttonStop.TabIndex = 3;
            this.buttonStop.Text = "停止";
            this.buttonStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // groupBoxTest
            // 
            this.groupBoxTest.Controls.Add(this.listViewRecord);
            this.groupBoxTest.Location = new System.Drawing.Point(427, 2);
            this.groupBoxTest.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxTest.Name = "groupBoxTest";
            this.groupBoxTest.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxTest.Size = new System.Drawing.Size(162, 47);
            this.groupBoxTest.TabIndex = 12;
            this.groupBoxTest.TabStop = false;
            this.groupBoxTest.Text = "测试模式";
            // 
            // listViewRecord
            // 
            this.listViewRecord.FullRowSelect = true;
            this.listViewRecord.GridLines = true;
            this.listViewRecord.LabelEdit = true;
            this.listViewRecord.Location = new System.Drawing.Point(35, 16);
            this.listViewRecord.Margin = new System.Windows.Forms.Padding(4);
            this.listViewRecord.MultiSelect = false;
            this.listViewRecord.Name = "listViewRecord";
            this.listViewRecord.Size = new System.Drawing.Size(52, 23);
            this.listViewRecord.TabIndex = 9;
            this.listViewRecord.UseCompatibleStateImageBehavior = false;
            this.listViewRecord.View = System.Windows.Forms.View.Details;
            // 
            // checkBoxCameraAcquisition
            // 
            this.checkBoxCameraAcquisition.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxCameraAcquisition.BackColor = System.Drawing.SystemColors.Control;
            this.checkBoxCameraAcquisition.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBoxCameraAcquisition.Image = ((System.Drawing.Image)(resources.GetObject("checkBoxCameraAcquisition.Image")));
            this.checkBoxCameraAcquisition.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBoxCameraAcquisition.Location = new System.Drawing.Point(30, 2);
            this.checkBoxCameraAcquisition.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxCameraAcquisition.Name = "checkBoxCameraAcquisition";
            this.checkBoxCameraAcquisition.Size = new System.Drawing.Size(156, 43);
            this.checkBoxCameraAcquisition.TabIndex = 6;
            this.checkBoxCameraAcquisition.Text = "开启定位实时采集";
            this.checkBoxCameraAcquisition.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxCameraAcquisition.UseVisualStyleBackColor = false;
            this.checkBoxCameraAcquisition.CheckedChanged += new System.EventHandler(this.checkBoxCameraAcquisition_CheckedChanged);
            // 
            // checkBoxCameraDetection
            // 
            this.checkBoxCameraDetection.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxCameraDetection.BackColor = System.Drawing.SystemColors.Control;
            this.checkBoxCameraDetection.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBoxCameraDetection.Image = ((System.Drawing.Image)(resources.GetObject("checkBoxCameraDetection.Image")));
            this.checkBoxCameraDetection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBoxCameraDetection.Location = new System.Drawing.Point(194, 3);
            this.checkBoxCameraDetection.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxCameraDetection.Name = "checkBoxCameraDetection";
            this.checkBoxCameraDetection.Size = new System.Drawing.Size(156, 43);
            this.checkBoxCameraDetection.TabIndex = 10;
            this.checkBoxCameraDetection.Text = "开启检测实时采集";
            this.checkBoxCameraDetection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxCameraDetection.UseVisualStyleBackColor = false;
            this.checkBoxCameraDetection.CheckedChanged += new System.EventHandler(this.checkBoxCameraDetection_CheckedChanged);
            // 
            // buttonTriggerDetectionRPC
            // 
            this.buttonTriggerDetectionRPC.Location = new System.Drawing.Point(268, 3);
            this.buttonTriggerDetectionRPC.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTriggerDetectionRPC.Name = "buttonTriggerDetectionRPC";
            this.buttonTriggerDetectionRPC.Size = new System.Drawing.Size(131, 31);
            this.buttonTriggerDetectionRPC.TabIndex = 11;
            this.buttonTriggerDetectionRPC.Text = "触发检测RPC";
            this.buttonTriggerDetectionRPC.UseVisualStyleBackColor = true;
            this.buttonTriggerDetectionRPC.Click += new System.EventHandler(this.buttonTriggerDetectionRPC_Click);
            // 
            // buttonTriggerLocationRPC
            // 
            this.buttonTriggerLocationRPC.Location = new System.Drawing.Point(129, 4);
            this.buttonTriggerLocationRPC.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTriggerLocationRPC.Name = "buttonTriggerLocationRPC";
            this.buttonTriggerLocationRPC.Size = new System.Drawing.Size(131, 31);
            this.buttonTriggerLocationRPC.TabIndex = 11;
            this.buttonTriggerLocationRPC.Text = "触发定位RPC";
            this.buttonTriggerLocationRPC.UseVisualStyleBackColor = true;
            this.buttonTriggerLocationRPC.Click += new System.EventHandler(this.buttonTriggerLocationRPC_Click);
            // 
            // splitContainerMainStatus
            // 
            this.splitContainerMainStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMainStatus.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerMainStatus.Location = new System.Drawing.Point(0, 28);
            this.splitContainerMainStatus.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainerMainStatus.Name = "splitContainerMainStatus";
            this.splitContainerMainStatus.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMainStatus.Panel1
            // 
            this.splitContainerMainStatus.Panel1.Controls.Add(this.splitDownResultShow);
            // 
            // splitContainerMainStatus.Panel2
            // 
            this.splitContainerMainStatus.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainerMainStatus.Size = new System.Drawing.Size(1902, 1005);
            this.splitContainerMainStatus.SplitterDistance = 970;
            this.splitContainerMainStatus.SplitterWidth = 5;
            this.splitContainerMainStatus.TabIndex = 12;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 8);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1902, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.splitContainerMainStatus);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Aqrose-2D定位检测";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.splitDownResultShow.Panel1.ResumeLayout(false);
            this.splitDownResultShow.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitDownResultShow)).EndInit();
            this.splitDownResultShow.ResumeLayout(false);
            this.splitUpContainerTitle.Panel1.ResumeLayout(false);
            this.splitUpContainerTitle.Panel1.PerformLayout();
            this.splitUpContainerTitle.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitUpContainerTitle)).EndInit();
            this.splitUpContainerTitle.ResumeLayout(false);
            this.splitContainerAqDisplayControls.Panel1.ResumeLayout(false);
            this.splitContainerAqDisplayControls.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAqDisplayControls)).EndInit();
            this.splitContainerAqDisplayControls.ResumeLayout(false);
            this.splitContainerDisplayShow.Panel1.ResumeLayout(false);
            this.splitContainerDisplayShow.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDisplayShow)).EndInit();
            this.splitContainerDisplayShow.ResumeLayout(false);
            this.groupBoxTest.ResumeLayout(false);
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
        private System.Windows.Forms.SplitContainer splitDownResultShow;
        private System.Windows.Forms.SplitContainer splitContainerAqDisplayControls;
        private AqVision.Controls.AqDisplay aqDisplayDectection;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemLog;
        private System.Windows.Forms.CheckBox checkBoxCameraDetection;
        private System.Windows.Forms.ListView listViewRecord;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.SplitContainer splitContainerMainStatus;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button buttonTriggerLocationRPC;
        private System.Windows.Forms.GroupBox groupBoxTest;
        private System.Windows.Forms.Button buttonTriggerDetectionRPC;
        private System.Windows.Forms.SplitContainer splitUpContainerTitle;
        private System.Windows.Forms.SplitContainer splitContainerDisplayShow;
        private System.Windows.Forms.Label label2;
    }
}

