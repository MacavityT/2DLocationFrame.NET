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
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.OpendetectAcquistionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClosedetectAcquistionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.OpenLocationAcquistionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseLocationAcquistionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemLog = new System.Windows.Forms.ToolStripMenuItem();
            this.保存检测图片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存定位图片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label_Title = new System.Windows.Forms.Label();
            this.buttonTriggerLocationRPC = new System.Windows.Forms.Button();
            this.buttonTriggerDetectionRPC = new System.Windows.Forms.Button();
            this.tableLayoutPanelShowPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.labelLocationScore = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.listViewRecord = new System.Windows.Forms.ListView();
            this.buttonRun = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelLocationTimes = new System.Windows.Forms.ToolStripStatusLabel();
            this.labellocationCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelDetectTimes = new System.Windows.Forms.ToolStripStatusLabel();
            this.labeldetectionCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelRuningTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelRunningTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanelTitle = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelLeft = new System.Windows.Forms.TableLayoutPanel();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.checkBoxCameraAcquisition = new System.Windows.Forms.CheckBox();
            this.checkBoxCameraDetection = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanelAqDisplayControls = new System.Windows.Forms.TableLayoutPanel();
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.menuStripMain.SuspendLayout();
            this.tableLayoutPanelShowPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanelTitle.SuspendLayout();
            this.tableLayoutPanelLeft.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.tableLayoutPanelAqDisplayControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // aqDisplayLocation
            // 
            this.aqDisplayLocation.AutoScroll = true;
            this.aqDisplayLocation.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.aqDisplayLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aqDisplayLocation.Image = null;
            this.aqDisplayLocation.Location = new System.Drawing.Point(2, 2);
            this.aqDisplayLocation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.aqDisplayLocation.Name = "aqDisplayLocation";
            this.aqDisplayLocation.ScrollBar = false;
            this.aqDisplayLocation.Size = new System.Drawing.Size(1139, 922);
            this.aqDisplayLocation.TabIndex = 0;
            // 
            // menuStripMain
            // 
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemSetParameter,
            this.工具ToolStripMenuItem,
            this.ToolStripMenuItemHelp});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(1271, 25);
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
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.OpendetectAcquistionToolStripMenuItem,
            this.ClosedetectAcquistionToolStripMenuItem,
            this.toolStripSeparator2,
            this.OpenLocationAcquistionToolStripMenuItem,
            this.CloseLocationAcquistionToolStripMenuItem,
            this.toolStripSeparator3,
            this.toolStripSeparator4});
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.工具ToolStripMenuItem.Text = "工具";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // OpendetectAcquistionToolStripMenuItem
            // 
            this.OpendetectAcquistionToolStripMenuItem.Name = "OpendetectAcquistionToolStripMenuItem";
            this.OpendetectAcquistionToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.OpendetectAcquistionToolStripMenuItem.Text = "检测测试显示";
            this.OpendetectAcquistionToolStripMenuItem.Click += new System.EventHandler(this.开启检测实时采集ToolStripMenuItem_Click);
            // 
            // ClosedetectAcquistionToolStripMenuItem
            // 
            this.ClosedetectAcquistionToolStripMenuItem.Checked = true;
            this.ClosedetectAcquistionToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ClosedetectAcquistionToolStripMenuItem.Name = "ClosedetectAcquistionToolStripMenuItem";
            this.ClosedetectAcquistionToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.ClosedetectAcquistionToolStripMenuItem.Text = "检测测试隐藏";
            this.ClosedetectAcquistionToolStripMenuItem.Click += new System.EventHandler(this.关闭检测实时采集ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(145, 6);
            // 
            // OpenLocationAcquistionToolStripMenuItem
            // 
            this.OpenLocationAcquistionToolStripMenuItem.Enabled = false;
            this.OpenLocationAcquistionToolStripMenuItem.Name = "OpenLocationAcquistionToolStripMenuItem";
            this.OpenLocationAcquistionToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.OpenLocationAcquistionToolStripMenuItem.Text = "定位测试显示";
            this.OpenLocationAcquistionToolStripMenuItem.Click += new System.EventHandler(this.开启定位实时采集ToolStripMenuItem_Click);
            // 
            // CloseLocationAcquistionToolStripMenuItem
            // 
            this.CloseLocationAcquistionToolStripMenuItem.Checked = true;
            this.CloseLocationAcquistionToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CloseLocationAcquistionToolStripMenuItem.Enabled = false;
            this.CloseLocationAcquistionToolStripMenuItem.Name = "CloseLocationAcquistionToolStripMenuItem";
            this.CloseLocationAcquistionToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.CloseLocationAcquistionToolStripMenuItem.Text = "定位测试隐藏";
            this.CloseLocationAcquistionToolStripMenuItem.Click += new System.EventHandler(this.关闭定位实时采集ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(145, 6);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(145, 6);
            // 
            // ToolStripMenuItemHelp
            // 
            this.ToolStripMenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemLog,
            this.保存检测图片ToolStripMenuItem,
            this.保存定位图片ToolStripMenuItem});
            this.ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            this.ToolStripMenuItemHelp.Size = new System.Drawing.Size(44, 21);
            this.ToolStripMenuItemHelp.Text = "帮助";
            // 
            // ToolStripMenuItemLog
            // 
            this.ToolStripMenuItemLog.Name = "ToolStripMenuItemLog";
            this.ToolStripMenuItemLog.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItemLog.Text = "日志信息";
            // 
            // 保存检测图片ToolStripMenuItem
            // 
            this.保存检测图片ToolStripMenuItem.Name = "保存检测图片ToolStripMenuItem";
            this.保存检测图片ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.保存检测图片ToolStripMenuItem.Text = "保存检测图片";
            this.保存检测图片ToolStripMenuItem.Click += new System.EventHandler(this.保存检测图片ToolStripMenuItem_Click);
            // 
            // 保存定位图片ToolStripMenuItem
            // 
            this.保存定位图片ToolStripMenuItem.Name = "保存定位图片ToolStripMenuItem";
            this.保存定位图片ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.保存定位图片ToolStripMenuItem.Text = "保存定位图片";
            this.保存定位图片ToolStripMenuItem.Click += new System.EventHandler(this.保存定位图片ToolStripMenuItem_Click);
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("SimSun", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Title.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label_Title.Location = new System.Drawing.Point(515, 20);
            this.label_Title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(116, 48);
            this.label_Title.TabIndex = 0;
            this.label_Title.Text = "测试";
            this.label_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonTriggerLocationRPC
            // 
            this.buttonTriggerLocationRPC.Location = new System.Drawing.Point(139, 8);
            this.buttonTriggerLocationRPC.Name = "buttonTriggerLocationRPC";
            this.buttonTriggerLocationRPC.Size = new System.Drawing.Size(90, 25);
            this.buttonTriggerLocationRPC.TabIndex = 11;
            this.buttonTriggerLocationRPC.Text = "触发定位RPC";
            this.buttonTriggerLocationRPC.UseVisualStyleBackColor = true;
            this.buttonTriggerLocationRPC.Visible = false;
            this.buttonTriggerLocationRPC.Click += new System.EventHandler(this.buttonTriggerLocationRPC_Click);
            // 
            // buttonTriggerDetectionRPC
            // 
            this.buttonTriggerDetectionRPC.Location = new System.Drawing.Point(138, 39);
            this.buttonTriggerDetectionRPC.Name = "buttonTriggerDetectionRPC";
            this.buttonTriggerDetectionRPC.Size = new System.Drawing.Size(90, 25);
            this.buttonTriggerDetectionRPC.TabIndex = 11;
            this.buttonTriggerDetectionRPC.Text = "触发检测RPC";
            this.buttonTriggerDetectionRPC.UseVisualStyleBackColor = true;
            this.buttonTriggerDetectionRPC.Visible = false;
            this.buttonTriggerDetectionRPC.Click += new System.EventHandler(this.buttonTriggerDetectionRPC_Click);
            // 
            // tableLayoutPanelShowPanel
            // 
            this.tableLayoutPanelShowPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelShowPanel.ColumnCount = 1;
            this.tableLayoutPanelShowPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelShowPanel.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanelShowPanel.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanelShowPanel.Controls.Add(this.panel7, 0, 4);
            this.tableLayoutPanelShowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelShowPanel.Location = new System.Drawing.Point(1153, 2);
            this.tableLayoutPanelShowPanel.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanelShowPanel.Name = "tableLayoutPanelShowPanel";
            this.tableLayoutPanelShowPanel.RowCount = 5;
            this.tableLayoutPanelShowPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.60972F));
            this.tableLayoutPanelShowPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.31156F));
            this.tableLayoutPanelShowPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.60972F));
            this.tableLayoutPanelShowPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.31156F));
            this.tableLayoutPanelShowPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.15745F));
            this.tableLayoutPanelShowPanel.Size = new System.Drawing.Size(116, 1010);
            this.tableLayoutPanelShowPanel.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(110, 132);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(13, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "定位结果";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Lime;
            this.label8.Location = new System.Drawing.Point(25, 40);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 24);
            this.label8.TabIndex = 4;
            this.label8.Text = "极好";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.labelLocationScore);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 140);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(110, 119);
            this.panel2.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("SimSun", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(13, 6);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 19);
            this.label7.TabIndex = 4;
            this.label7.Text = "定位得分";
            // 
            // labelLocationScore
            // 
            this.labelLocationScore.AutoSize = true;
            this.labelLocationScore.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLocationScore.ForeColor = System.Drawing.Color.Lime;
            this.labelLocationScore.Location = new System.Drawing.Point(12, 34);
            this.labelLocationScore.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLocationScore.Name = "labelLocationScore";
            this.labelLocationScore.Size = new System.Drawing.Size(88, 24);
            this.labelLocationScore.TabIndex = 4;
            this.labelLocationScore.Text = "95.321";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.listViewRecord);
            this.panel7.Controls.Add(this.buttonRun);
            this.panel7.Controls.Add(this.buttonStop);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(3, 525);
            this.panel7.Margin = new System.Windows.Forms.Padding(2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(110, 482);
            this.panel7.TabIndex = 4;
            // 
            // listViewRecord
            // 
            this.listViewRecord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewRecord.Location = new System.Drawing.Point(0, 0);
            this.listViewRecord.Name = "listViewRecord";
            this.listViewRecord.Size = new System.Drawing.Size(110, 360);
            this.listViewRecord.TabIndex = 4;
            this.listViewRecord.UseCompatibleStateImageBehavior = false;
            this.listViewRecord.View = System.Windows.Forms.View.Details;
            this.listViewRecord.Visible = false;
            // 
            // buttonRun
            // 
            this.buttonRun.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonRun.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonRun.Image = global::IntegrationTesting.Properties.Resources.Run;
            this.buttonRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRun.Location = new System.Drawing.Point(0, 360);
            this.buttonRun.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(110, 61);
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
            this.buttonStop.Location = new System.Drawing.Point(0, 421);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(110, 61);
            this.buttonStop.TabIndex = 3;
            this.buttonStop.Text = "停止";
            this.buttonStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelLocationTimes,
            this.labellocationCount,
            this.toolStripStatusLabelDetectTimes,
            this.labeldetectionCount,
            this.toolStripStatusLabelRuningTime,
            this.toolStripStatusLabelRunningTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1039);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1271, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelLocationTimes
            // 
            this.toolStripStatusLabelLocationTimes.Name = "toolStripStatusLabelLocationTimes";
            this.toolStripStatusLabelLocationTimes.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabelLocationTimes.Text = "定位次数：";
            // 
            // labellocationCount
            // 
            this.labellocationCount.Name = "labellocationCount";
            this.labellocationCount.Size = new System.Drawing.Size(15, 17);
            this.labellocationCount.Text = "0";
            // 
            // toolStripStatusLabelDetectTimes
            // 
            this.toolStripStatusLabelDetectTimes.Name = "toolStripStatusLabelDetectTimes";
            this.toolStripStatusLabelDetectTimes.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabelDetectTimes.Text = "检测次数：";
            // 
            // labeldetectionCount
            // 
            this.labeldetectionCount.Name = "labeldetectionCount";
            this.labeldetectionCount.Size = new System.Drawing.Size(15, 17);
            this.labeldetectionCount.Text = "0";
            // 
            // toolStripStatusLabelRuningTime
            // 
            this.toolStripStatusLabelRuningTime.Name = "toolStripStatusLabelRuningTime";
            this.toolStripStatusLabelRuningTime.Size = new System.Drawing.Size(80, 17);
            this.toolStripStatusLabelRuningTime.Text = "总运行时间：";
            // 
            // toolStripStatusLabelRunningTime
            // 
            this.toolStripStatusLabelRunningTime.Name = "toolStripStatusLabelRunningTime";
            this.toolStripStatusLabelRunningTime.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabelRunningTime.Text = "00:00:00";
            // 
            // tableLayoutPanelTitle
            // 
            this.tableLayoutPanelTitle.ColumnCount = 2;
            this.tableLayoutPanelTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanelTitle.Controls.Add(this.tableLayoutPanelShowPanel, 1, 0);
            this.tableLayoutPanelTitle.Controls.Add(this.tableLayoutPanelLeft, 0, 0);
            this.tableLayoutPanelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTitle.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanelTitle.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanelTitle.Name = "tableLayoutPanelTitle";
            this.tableLayoutPanelTitle.RowCount = 1;
            this.tableLayoutPanelTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTitle.Size = new System.Drawing.Size(1271, 1014);
            this.tableLayoutPanelTitle.TabIndex = 14;
            // 
            // tableLayoutPanelLeft
            // 
            this.tableLayoutPanelLeft.ColumnCount = 1;
            this.tableLayoutPanelLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLeft.Controls.Add(this.panelTitle, 0, 0);
            this.tableLayoutPanelLeft.Controls.Add(this.tableLayoutPanelAqDisplayControls, 0, 1);
            this.tableLayoutPanelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLeft.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanelLeft.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanelLeft.Name = "tableLayoutPanelLeft";
            this.tableLayoutPanelLeft.RowCount = 2;
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLeft.Size = new System.Drawing.Size(1147, 1010);
            this.tableLayoutPanelLeft.TabIndex = 14;
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTitle.Controls.Add(this.label_Title);
            this.panelTitle.Controls.Add(this.checkBoxCameraAcquisition);
            this.panelTitle.Controls.Add(this.buttonTriggerLocationRPC);
            this.panelTitle.Controls.Add(this.buttonTriggerDetectionRPC);
            this.panelTitle.Controls.Add(this.checkBoxCameraDetection);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelTitle.Location = new System.Drawing.Point(2, 2);
            this.panelTitle.Margin = new System.Windows.Forms.Padding(2);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(1143, 76);
            this.panelTitle.TabIndex = 0;
            // 
            // checkBoxCameraAcquisition
            // 
            this.checkBoxCameraAcquisition.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxCameraAcquisition.BackColor = System.Drawing.SystemColors.Control;
            this.checkBoxCameraAcquisition.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBoxCameraAcquisition.Image = ((System.Drawing.Image)(resources.GetObject("checkBoxCameraAcquisition.Image")));
            this.checkBoxCameraAcquisition.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBoxCameraAcquisition.Location = new System.Drawing.Point(5, 8);
            this.checkBoxCameraAcquisition.Name = "checkBoxCameraAcquisition";
            this.checkBoxCameraAcquisition.Size = new System.Drawing.Size(131, 25);
            this.checkBoxCameraAcquisition.TabIndex = 6;
            this.checkBoxCameraAcquisition.Text = "开启定位实时采集";
            this.checkBoxCameraAcquisition.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxCameraAcquisition.UseVisualStyleBackColor = false;
            this.checkBoxCameraAcquisition.Visible = false;
            this.checkBoxCameraAcquisition.CheckedChanged += new System.EventHandler(this.checkBoxCameraAcquisition_CheckedChanged);
            // 
            // checkBoxCameraDetection
            // 
            this.checkBoxCameraDetection.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxCameraDetection.BackColor = System.Drawing.SystemColors.Control;
            this.checkBoxCameraDetection.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBoxCameraDetection.Image = ((System.Drawing.Image)(resources.GetObject("checkBoxCameraDetection.Image")));
            this.checkBoxCameraDetection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBoxCameraDetection.Location = new System.Drawing.Point(4, 38);
            this.checkBoxCameraDetection.Name = "checkBoxCameraDetection";
            this.checkBoxCameraDetection.Size = new System.Drawing.Size(131, 25);
            this.checkBoxCameraDetection.TabIndex = 10;
            this.checkBoxCameraDetection.Text = "开启检测实时采集";
            this.checkBoxCameraDetection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxCameraDetection.UseVisualStyleBackColor = false;
            this.checkBoxCameraDetection.Visible = false;
            this.checkBoxCameraDetection.CheckedChanged += new System.EventHandler(this.checkBoxCameraDetection_CheckedChanged);
            // 
            // tableLayoutPanelAqDisplayControls
            // 
            this.tableLayoutPanelAqDisplayControls.ColumnCount = 1;
            this.tableLayoutPanelAqDisplayControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelAqDisplayControls.Controls.Add(this.aqDisplayLocation, 0, 0);
            this.tableLayoutPanelAqDisplayControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelAqDisplayControls.Location = new System.Drawing.Point(2, 82);
            this.tableLayoutPanelAqDisplayControls.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanelAqDisplayControls.Name = "tableLayoutPanelAqDisplayControls";
            this.tableLayoutPanelAqDisplayControls.RowCount = 1;
            this.tableLayoutPanelAqDisplayControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelAqDisplayControls.Size = new System.Drawing.Size(1143, 926);
            this.tableLayoutPanelAqDisplayControls.TabIndex = 1;
            // 
            // timerStatus
            // 
            this.timerStatus.Enabled = true;
            this.timerStatus.Interval = 1000;
            this.timerStatus.Tick += new System.EventHandler(this.timerStatus_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 1061);
            this.Controls.Add(this.tableLayoutPanelTitle);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "MainForm";
            this.Text = "测试";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.tableLayoutPanelShowPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanelTitle.ResumeLayout(false);
            this.tableLayoutPanelLeft.ResumeLayout(false);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemLog;
        private System.Windows.Forms.CheckBox checkBoxCameraDetection;
        private System.Windows.Forms.Button buttonTriggerLocationRPC;
        private System.Windows.Forms.Button buttonTriggerDetectionRPC;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelShowPanel;
        private System.Windows.Forms.Label labelLocationScore;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAqDisplayControls;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLeft;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpendetectAcquistionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenLocationAcquistionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ClosedetectAcquistionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem CloseLocationAcquistionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem 保存检测图片ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存定位图片ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLocationTimes;
        private System.Windows.Forms.ToolStripStatusLabel labellocationCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDetectTimes;
        private System.Windows.Forms.ToolStripStatusLabel labeldetectionCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRunningTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRuningTime;
        private System.Windows.Forms.Timer timerStatus;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ListView listViewRecord;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Button buttonStop;
    }
}

