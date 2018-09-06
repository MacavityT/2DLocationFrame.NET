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
            this.splitUpContainerTitle = new System.Windows.Forms.SplitContainer();
            this.splitContainerStatusShow = new System.Windows.Forms.SplitContainer();
            this.label_Title = new System.Windows.Forms.Label();
            this.buttonTriggerLocationRPC = new System.Windows.Forms.Button();
            this.groupBoxTest = new System.Windows.Forms.GroupBox();
            this.listViewRecord = new System.Windows.Forms.ListView();
            this.buttonTriggerDetectionRPC = new System.Windows.Forms.Button();
            this.checkBoxCameraDetection = new System.Windows.Forms.CheckBox();
            this.checkBoxCameraAcquisition = new System.Windows.Forms.CheckBox();
            this.aqDisplayDectection = new AqVision.Controls.AqDisplay();
            this.tableLayoutPanelShowPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.labelLocationScore = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.buttonRun = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanelAqDisplayControls = new System.Windows.Forms.TableLayoutPanel();
            this.menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitUpContainerTitle)).BeginInit();
            this.splitUpContainerTitle.Panel1.SuspendLayout();
            this.splitUpContainerTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerStatusShow)).BeginInit();
            this.splitContainerStatusShow.Panel1.SuspendLayout();
            this.splitContainerStatusShow.Panel2.SuspendLayout();
            this.splitContainerStatusShow.SuspendLayout();
            this.groupBoxTest.SuspendLayout();
            this.tableLayoutPanelShowPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanelAqDisplayControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // aqDisplayLocation
            // 
            this.aqDisplayLocation.AutoScroll = true;
            this.aqDisplayLocation.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.aqDisplayLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aqDisplayLocation.Image = null;
            this.aqDisplayLocation.Location = new System.Drawing.Point(3, 2);
            this.aqDisplayLocation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.aqDisplayLocation.Name = "aqDisplayLocation";
            this.aqDisplayLocation.ScrollBar = false;
            this.aqDisplayLocation.Size = new System.Drawing.Size(263, 419);
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
            this.menuStripMain.Size = new System.Drawing.Size(1344, 28);
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
            // splitUpContainerTitle
            // 
            this.splitUpContainerTitle.BackColor = System.Drawing.SystemColors.Control;
            this.splitUpContainerTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitUpContainerTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitUpContainerTitle.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitUpContainerTitle.Location = new System.Drawing.Point(0, 0);
            this.splitUpContainerTitle.Name = "splitUpContainerTitle";
            // 
            // splitUpContainerTitle.Panel1
            // 
            this.splitUpContainerTitle.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitUpContainerTitle.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.splitUpContainerTitle.Panel1.Controls.Add(this.splitContainerStatusShow);
            this.splitUpContainerTitle.Panel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            // 
            // splitUpContainerTitle.Panel2
            // 
            this.splitUpContainerTitle.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitUpContainerTitle_Panel2_Paint);
            this.splitUpContainerTitle.Size = new System.Drawing.Size(1344, 661);
            this.splitUpContainerTitle.SplitterDistance = 1225;
            this.splitUpContainerTitle.TabIndex = 13;
            this.splitUpContainerTitle.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitUpContainerTitle_SplitterMoved);
            // 
            // splitContainerStatusShow
            // 
            this.splitContainerStatusShow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerStatusShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerStatusShow.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerStatusShow.Location = new System.Drawing.Point(0, 0);
            this.splitContainerStatusShow.Name = "splitContainerStatusShow";
            this.splitContainerStatusShow.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerStatusShow.Panel1
            // 
            this.splitContainerStatusShow.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.splitContainerStatusShow.Panel1.Controls.Add(this.label_Title);
            this.splitContainerStatusShow.Panel1.Controls.Add(this.buttonTriggerLocationRPC);
            this.splitContainerStatusShow.Panel1.Controls.Add(this.groupBoxTest);
            this.splitContainerStatusShow.Panel1.Controls.Add(this.buttonTriggerDetectionRPC);
            this.splitContainerStatusShow.Panel1.Controls.Add(this.checkBoxCameraDetection);
            this.splitContainerStatusShow.Panel1.Controls.Add(this.checkBoxCameraAcquisition);
            this.splitContainerStatusShow.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainerStatusShow.Panel2
            // 
            this.splitContainerStatusShow.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerStatusShow.Panel2.Controls.Add(this.tableLayoutPanelShowPanel);
            this.splitContainerStatusShow.Panel2.Controls.Add(this.tableLayoutPanelAqDisplayControls);
            this.splitContainerStatusShow.Panel2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.splitContainerStatusShow.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainerStatusShow.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainerStatusShow.Size = new System.Drawing.Size(1225, 661);
            this.splitContainerStatusShow.SplitterDistance = 105;
            this.splitContainerStatusShow.TabIndex = 13;
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("SimSun", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Title.Location = new System.Drawing.Point(536, 40);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(625, 60);
            this.label_Title.TabIndex = 0;
            this.label_Title.Text = "三通管定位及缺陷检测";
            this.label_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonTriggerLocationRPC
            // 
            this.buttonTriggerLocationRPC.Location = new System.Drawing.Point(296, 61);
            this.buttonTriggerLocationRPC.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTriggerLocationRPC.Name = "buttonTriggerLocationRPC";
            this.buttonTriggerLocationRPC.Size = new System.Drawing.Size(156, 31);
            this.buttonTriggerLocationRPC.TabIndex = 11;
            this.buttonTriggerLocationRPC.Text = "触发定位RPC";
            this.buttonTriggerLocationRPC.UseVisualStyleBackColor = true;
            this.buttonTriggerLocationRPC.Click += new System.EventHandler(this.buttonTriggerLocationRPC_Click);
            // 
            // groupBoxTest
            // 
            this.groupBoxTest.Controls.Add(this.listViewRecord);
            this.groupBoxTest.Location = new System.Drawing.Point(3, 45);
            this.groupBoxTest.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxTest.Name = "groupBoxTest";
            this.groupBoxTest.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxTest.Size = new System.Drawing.Size(95, 41);
            this.groupBoxTest.TabIndex = 12;
            this.groupBoxTest.TabStop = false;
            this.groupBoxTest.Text = "测试模式";
            this.groupBoxTest.Visible = false;
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
            // buttonTriggerDetectionRPC
            // 
            this.buttonTriggerDetectionRPC.Location = new System.Drawing.Point(296, 19);
            this.buttonTriggerDetectionRPC.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTriggerDetectionRPC.Name = "buttonTriggerDetectionRPC";
            this.buttonTriggerDetectionRPC.Size = new System.Drawing.Size(156, 31);
            this.buttonTriggerDetectionRPC.TabIndex = 11;
            this.buttonTriggerDetectionRPC.Text = "触发检测RPC";
            this.buttonTriggerDetectionRPC.UseVisualStyleBackColor = true;
            this.buttonTriggerDetectionRPC.Click += new System.EventHandler(this.buttonTriggerDetectionRPC_Click);
            // 
            // checkBoxCameraDetection
            // 
            this.checkBoxCameraDetection.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxCameraDetection.BackColor = System.Drawing.SystemColors.Control;
            this.checkBoxCameraDetection.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBoxCameraDetection.Image = ((System.Drawing.Image)(resources.GetObject("checkBoxCameraDetection.Image")));
            this.checkBoxCameraDetection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBoxCameraDetection.Location = new System.Drawing.Point(82, 61);
            this.checkBoxCameraDetection.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxCameraDetection.Name = "checkBoxCameraDetection";
            this.checkBoxCameraDetection.Size = new System.Drawing.Size(180, 31);
            this.checkBoxCameraDetection.TabIndex = 10;
            this.checkBoxCameraDetection.Text = "开启检测实时采集";
            this.checkBoxCameraDetection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxCameraDetection.UseVisualStyleBackColor = false;
            this.checkBoxCameraDetection.CheckedChanged += new System.EventHandler(this.checkBoxCameraDetection_CheckedChanged);
            // 
            // checkBoxCameraAcquisition
            // 
            this.checkBoxCameraAcquisition.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxCameraAcquisition.BackColor = System.Drawing.SystemColors.Control;
            this.checkBoxCameraAcquisition.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBoxCameraAcquisition.Image = ((System.Drawing.Image)(resources.GetObject("checkBoxCameraAcquisition.Image")));
            this.checkBoxCameraAcquisition.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBoxCameraAcquisition.Location = new System.Drawing.Point(82, 19);
            this.checkBoxCameraAcquisition.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxCameraAcquisition.Name = "checkBoxCameraAcquisition";
            this.checkBoxCameraAcquisition.Size = new System.Drawing.Size(180, 31);
            this.checkBoxCameraAcquisition.TabIndex = 6;
            this.checkBoxCameraAcquisition.Text = "开启定位实时采集";
            this.checkBoxCameraAcquisition.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxCameraAcquisition.UseVisualStyleBackColor = false;
            this.checkBoxCameraAcquisition.CheckedChanged += new System.EventHandler(this.checkBoxCameraAcquisition_CheckedChanged);
            // 
            // aqDisplayDectection
            // 
            this.aqDisplayDectection.AutoScroll = true;
            this.aqDisplayDectection.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.aqDisplayDectection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aqDisplayDectection.Image = null;
            this.aqDisplayDectection.Location = new System.Drawing.Point(272, 2);
            this.aqDisplayDectection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.aqDisplayDectection.Name = "aqDisplayDectection";
            this.aqDisplayDectection.ScrollBar = false;
            this.aqDisplayDectection.Size = new System.Drawing.Size(264, 419);
            this.aqDisplayDectection.TabIndex = 1;
            // 
            // tableLayoutPanelShowPanel
            // 
            this.tableLayoutPanelShowPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelShowPanel.ColumnCount = 1;
            this.tableLayoutPanelShowPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelShowPanel.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanelShowPanel.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanelShowPanel.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanelShowPanel.Controls.Add(this.panel6, 0, 3);
            this.tableLayoutPanelShowPanel.Controls.Add(this.panel7, 0, 4);
            this.tableLayoutPanelShowPanel.Location = new System.Drawing.Point(948, 55);
            this.tableLayoutPanelShowPanel.Name = "tableLayoutPanelShowPanel";
            this.tableLayoutPanelShowPanel.RowCount = 5;
            this.tableLayoutPanelShowPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelShowPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelShowPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelShowPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelShowPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelShowPanel.Size = new System.Drawing.Size(102, 339);
            this.tableLayoutPanelShowPanel.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(94, 35);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(20, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "定位结果";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(36, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 30);
            this.label8.TabIndex = 4;
            this.label8.Text = "极好";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.labelLocationScore);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(94, 35);
            this.panel2.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("SimSun", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(20, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 24);
            this.label7.TabIndex = 4;
            this.label7.Text = "定位得分";
            // 
            // labelLocationScore
            // 
            this.labelLocationScore.AutoSize = true;
            this.labelLocationScore.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLocationScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelLocationScore.Location = new System.Drawing.Point(49, 43);
            this.labelLocationScore.Name = "labelLocationScore";
            this.labelLocationScore.Size = new System.Drawing.Size(45, 30);
            this.labelLocationScore.TabIndex = 4;
            this.labelLocationScore.Text = "95";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(4, 88);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(94, 35);
            this.panel3.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SimSun", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(20, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "检测结果";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(36, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 30);
            this.label3.TabIndex = 4;
            this.label3.Text = "不良";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(4, 130);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(94, 35);
            this.panel6.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(49, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 30);
            this.label6.TabIndex = 4;
            this.label6.Text = "10";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("SimSun", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(20, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "不良个数";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.buttonRun);
            this.panel7.Controls.Add(this.buttonStop);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(4, 172);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(94, 163);
            this.panel7.TabIndex = 4;
            // 
            // buttonRun
            // 
            this.buttonRun.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonRun.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonRun.Image = global::IntegrationTesting.Properties.Resources.Run;
            this.buttonRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRun.Location = new System.Drawing.Point(0, 31);
            this.buttonRun.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(94, 66);
            this.buttonRun.TabIndex = 3;
            this.buttonRun.Text = "运行";
            this.buttonRun.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonStop.Enabled = false;
            this.buttonStop.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonStop.Image = global::IntegrationTesting.Properties.Resources.Stop;
            this.buttonStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonStop.Location = new System.Drawing.Point(0, 97);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(94, 66);
            this.buttonStop.TabIndex = 3;
            this.buttonStop.Text = "停止";
            this.buttonStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 718);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1344, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitUpContainerTitle);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            this.splitContainer1.Panel2MinSize = 2;
            this.splitContainer1.Size = new System.Drawing.Size(1344, 690);
            this.splitContainer1.SplitterDistance = 661;
            this.splitContainer1.TabIndex = 15;
            // 
            // tableLayoutPanelAqDisplayControls
            // 
            this.tableLayoutPanelAqDisplayControls.ColumnCount = 2;
            this.tableLayoutPanelAqDisplayControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelAqDisplayControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelAqDisplayControls.Controls.Add(this.aqDisplayLocation, 0, 0);
            this.tableLayoutPanelAqDisplayControls.Controls.Add(this.aqDisplayDectection, 1, 0);
            this.tableLayoutPanelAqDisplayControls.Location = new System.Drawing.Point(328, 36);
            this.tableLayoutPanelAqDisplayControls.Name = "tableLayoutPanelAqDisplayControls";
            this.tableLayoutPanelAqDisplayControls.RowCount = 1;
            this.tableLayoutPanelAqDisplayControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelAqDisplayControls.Size = new System.Drawing.Size(539, 423);
            this.tableLayoutPanelAqDisplayControls.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 740);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "三通管定位及缺陷检测";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.splitUpContainerTitle.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitUpContainerTitle)).EndInit();
            this.splitUpContainerTitle.ResumeLayout(false);
            this.splitContainerStatusShow.Panel1.ResumeLayout(false);
            this.splitContainerStatusShow.Panel1.PerformLayout();
            this.splitContainerStatusShow.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerStatusShow)).EndInit();
            this.splitContainerStatusShow.ResumeLayout(false);
            this.groupBoxTest.ResumeLayout(false);
            this.tableLayoutPanelShowPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanelAqDisplayControls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AqVision.Controls.AqDisplay aqDisplayLocation;
        private System.Windows.Forms.CheckBox checkBoxCameraAcquisition;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSetParameter;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSetAcqusition;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSetCalibration;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSetLocation;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSetDectection;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSetRobotConnect;
        private AqVision.Controls.AqDisplay aqDisplayDectection;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemLog;
        private System.Windows.Forms.CheckBox checkBoxCameraDetection;
        private System.Windows.Forms.ListView listViewRecord;
        private System.Windows.Forms.Button buttonTriggerLocationRPC;
        private System.Windows.Forms.GroupBox groupBoxTest;
        private System.Windows.Forms.Button buttonTriggerDetectionRPC;
        private System.Windows.Forms.SplitContainer splitUpContainerTitle;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.SplitContainer splitContainerStatusShow;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelShowPanel;
        private System.Windows.Forms.Label labelLocationScore;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAqDisplayControls;
    }
}

