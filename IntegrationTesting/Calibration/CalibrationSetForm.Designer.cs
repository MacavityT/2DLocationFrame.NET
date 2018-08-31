namespace IntegrationTesting
{
    partial class CalibrationSetForm
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
            this.listViewParameterSet = new System.Windows.Forms.ListView();
            this.comboBoxModeList = new System.Windows.Forms.ComboBox();
            this.labelResultImageX = new System.Windows.Forms.Label();
            this.textBoxImageX = new System.Windows.Forms.TextBox();
            this.labelResultImageY = new System.Windows.Forms.Label();
            this.textBoxImageY = new System.Windows.Forms.TextBox();
            this.labelRobotPosX = new System.Windows.Forms.Label();
            this.textBoxRobotPosX = new System.Windows.Forms.TextBox();
            this.labelRobotPosY = new System.Windows.Forms.Label();
            this.textBoxRobotPosY = new System.Windows.Forms.TextBox();
            this.labelRobotPosRz = new System.Windows.Forms.Label();
            this.textBoxRobotPosRz = new System.Windows.Forms.TextBox();
            this.labelResultImageA = new System.Windows.Forms.Label();
            this.textBoxImageA = new System.Windows.Forms.TextBox();
            this.labelCatchRobotX = new System.Windows.Forms.Label();
            this.textBoxCatchRobotX = new System.Windows.Forms.TextBox();
            this.labelCatchRobotY = new System.Windows.Forms.Label();
            this.textBoxCatchRobotY = new System.Windows.Forms.TextBox();
            this.labelCatchRobotRz = new System.Windows.Forms.Label();
            this.textBoxCatchRobotRz = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonNewLine = new System.Windows.Forms.Button();
            this.buttonDeleteLine = new System.Windows.Forms.Button();
            this.buttonCalibration = new System.Windows.Forms.Button();
            this.buttonSetCatchSet = new System.Windows.Forms.Button();
            this.buttonGetResult = new System.Windows.Forms.Button();
            this.buttonSaveResult = new System.Windows.Forms.Button();
            this.buttonLoadResult = new System.Windows.Forms.Button();
            this.labelCameraX = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxCameraX = new System.Windows.Forms.TextBox();
            this.textBoxCameraY = new System.Windows.Forms.TextBox();
            this.textBoxRobotX = new System.Windows.Forms.TextBox();
            this.textBoxRobotY = new System.Windows.Forms.TextBox();
            this.textBoxRobotRz = new System.Windows.Forms.TextBox();
            this.buttonUpdateLine = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelSingleInput = new System.Windows.Forms.Panel();
            this.panelBatchInput = new System.Windows.Forms.Panel();
            this.textBoxWorldCoordianteFilePath = new System.Windows.Forms.TextBox();
            this.textBoxCalibrateImagPath = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.buttonSelectWorldPos = new System.Windows.Forms.Button();
            this.buttonSelectCalPic = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonSingleInput = new System.Windows.Forms.RadioButton();
            this.radioButtonBatchInput = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panelSingleInput.SuspendLayout();
            this.panelBatchInput.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewParameterSet
            // 
            this.listViewParameterSet.FullRowSelect = true;
            this.listViewParameterSet.GridLines = true;
            this.listViewParameterSet.Location = new System.Drawing.Point(9, 239);
            this.listViewParameterSet.Margin = new System.Windows.Forms.Padding(4);
            this.listViewParameterSet.Name = "listViewParameterSet";
            this.listViewParameterSet.Size = new System.Drawing.Size(694, 251);
            this.listViewParameterSet.TabIndex = 0;
            this.listViewParameterSet.UseCompatibleStateImageBehavior = false;
            this.listViewParameterSet.View = System.Windows.Forms.View.Details;
            this.listViewParameterSet.SelectedIndexChanged += new System.EventHandler(this.listViewParameterSet_SelectedIndexChanged);
            // 
            // comboBoxModeList
            // 
            this.comboBoxModeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxModeList.FormattingEnabled = true;
            this.comboBoxModeList.Location = new System.Drawing.Point(9, 498);
            this.comboBoxModeList.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxModeList.Name = "comboBoxModeList";
            this.comboBoxModeList.Size = new System.Drawing.Size(691, 23);
            this.comboBoxModeList.TabIndex = 1;
            this.comboBoxModeList.SelectedIndexChanged += new System.EventHandler(this.comboBoxModeList_SelectedIndexChanged);
            // 
            // labelResultImageX
            // 
            this.labelResultImageX.AutoSize = true;
            this.labelResultImageX.Location = new System.Drawing.Point(3, 19);
            this.labelResultImageX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelResultImageX.Name = "labelResultImageX";
            this.labelResultImageX.Size = new System.Drawing.Size(127, 15);
            this.labelResultImageX.TabIndex = 2;
            this.labelResultImageX.Text = "Result Image X:";
            // 
            // textBoxImageX
            // 
            this.textBoxImageX.Location = new System.Drawing.Point(132, 12);
            this.textBoxImageX.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxImageX.Name = "textBoxImageX";
            this.textBoxImageX.Size = new System.Drawing.Size(271, 25);
            this.textBoxImageX.TabIndex = 3;
            this.textBoxImageX.Text = "100";
            // 
            // labelResultImageY
            // 
            this.labelResultImageY.AutoSize = true;
            this.labelResultImageY.Location = new System.Drawing.Point(3, 52);
            this.labelResultImageY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelResultImageY.Name = "labelResultImageY";
            this.labelResultImageY.Size = new System.Drawing.Size(127, 15);
            this.labelResultImageY.TabIndex = 2;
            this.labelResultImageY.Text = "Result Image Y:";
            // 
            // textBoxImageY
            // 
            this.textBoxImageY.Location = new System.Drawing.Point(132, 46);
            this.textBoxImageY.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxImageY.Name = "textBoxImageY";
            this.textBoxImageY.Size = new System.Drawing.Size(271, 25);
            this.textBoxImageY.TabIndex = 3;
            this.textBoxImageY.Text = "100";
            // 
            // labelRobotPosX
            // 
            this.labelRobotPosX.AutoSize = true;
            this.labelRobotPosX.Location = new System.Drawing.Point(3, 120);
            this.labelRobotPosX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRobotPosX.Name = "labelRobotPosX";
            this.labelRobotPosX.Size = new System.Drawing.Size(103, 15);
            this.labelRobotPosX.TabIndex = 2;
            this.labelRobotPosX.Text = "Robot Pos X:";
            // 
            // textBoxRobotPosX
            // 
            this.textBoxRobotPosX.Location = new System.Drawing.Point(132, 114);
            this.textBoxRobotPosX.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxRobotPosX.Name = "textBoxRobotPosX";
            this.textBoxRobotPosX.Size = new System.Drawing.Size(271, 25);
            this.textBoxRobotPosX.TabIndex = 3;
            this.textBoxRobotPosX.Text = "100";
            // 
            // labelRobotPosY
            // 
            this.labelRobotPosY.AutoSize = true;
            this.labelRobotPosY.Location = new System.Drawing.Point(3, 154);
            this.labelRobotPosY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRobotPosY.Name = "labelRobotPosY";
            this.labelRobotPosY.Size = new System.Drawing.Size(103, 15);
            this.labelRobotPosY.TabIndex = 2;
            this.labelRobotPosY.Text = "Robot Pos Y:";
            // 
            // textBoxRobotPosY
            // 
            this.textBoxRobotPosY.Location = new System.Drawing.Point(132, 148);
            this.textBoxRobotPosY.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxRobotPosY.Name = "textBoxRobotPosY";
            this.textBoxRobotPosY.Size = new System.Drawing.Size(271, 25);
            this.textBoxRobotPosY.TabIndex = 3;
            this.textBoxRobotPosY.Text = "100";
            // 
            // labelRobotPosRz
            // 
            this.labelRobotPosRz.AutoSize = true;
            this.labelRobotPosRz.Location = new System.Drawing.Point(3, 188);
            this.labelRobotPosRz.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRobotPosRz.Name = "labelRobotPosRz";
            this.labelRobotPosRz.Size = new System.Drawing.Size(111, 15);
            this.labelRobotPosRz.TabIndex = 2;
            this.labelRobotPosRz.Text = "Robot Pos Rz:";
            // 
            // textBoxRobotPosRz
            // 
            this.textBoxRobotPosRz.Location = new System.Drawing.Point(132, 181);
            this.textBoxRobotPosRz.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxRobotPosRz.Name = "textBoxRobotPosRz";
            this.textBoxRobotPosRz.Size = new System.Drawing.Size(271, 25);
            this.textBoxRobotPosRz.TabIndex = 3;
            this.textBoxRobotPosRz.Text = "100";
            // 
            // labelResultImageA
            // 
            this.labelResultImageA.AutoSize = true;
            this.labelResultImageA.Location = new System.Drawing.Point(3, 85);
            this.labelResultImageA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelResultImageA.Name = "labelResultImageA";
            this.labelResultImageA.Size = new System.Drawing.Size(127, 15);
            this.labelResultImageA.TabIndex = 2;
            this.labelResultImageA.Text = "Result Image A:";
            // 
            // textBoxImageA
            // 
            this.textBoxImageA.Location = new System.Drawing.Point(132, 79);
            this.textBoxImageA.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxImageA.Name = "textBoxImageA";
            this.textBoxImageA.Size = new System.Drawing.Size(271, 25);
            this.textBoxImageA.TabIndex = 3;
            this.textBoxImageA.Text = "100";
            // 
            // labelCatchRobotX
            // 
            this.labelCatchRobotX.AutoSize = true;
            this.labelCatchRobotX.Location = new System.Drawing.Point(3, 221);
            this.labelCatchRobotX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCatchRobotX.Name = "labelCatchRobotX";
            this.labelCatchRobotX.Size = new System.Drawing.Size(119, 15);
            this.labelCatchRobotX.TabIndex = 2;
            this.labelCatchRobotX.Text = "Catch Robot X:";
            // 
            // textBoxCatchRobotX
            // 
            this.textBoxCatchRobotX.Location = new System.Drawing.Point(132, 215);
            this.textBoxCatchRobotX.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxCatchRobotX.Name = "textBoxCatchRobotX";
            this.textBoxCatchRobotX.Size = new System.Drawing.Size(271, 25);
            this.textBoxCatchRobotX.TabIndex = 3;
            this.textBoxCatchRobotX.Text = "100";
            // 
            // labelCatchRobotY
            // 
            this.labelCatchRobotY.AutoSize = true;
            this.labelCatchRobotY.Location = new System.Drawing.Point(3, 255);
            this.labelCatchRobotY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCatchRobotY.Name = "labelCatchRobotY";
            this.labelCatchRobotY.Size = new System.Drawing.Size(119, 15);
            this.labelCatchRobotY.TabIndex = 2;
            this.labelCatchRobotY.Text = "Catch Robot Y:";
            // 
            // textBoxCatchRobotY
            // 
            this.textBoxCatchRobotY.Location = new System.Drawing.Point(132, 249);
            this.textBoxCatchRobotY.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxCatchRobotY.Name = "textBoxCatchRobotY";
            this.textBoxCatchRobotY.Size = new System.Drawing.Size(271, 25);
            this.textBoxCatchRobotY.TabIndex = 3;
            this.textBoxCatchRobotY.Text = "100";
            // 
            // labelCatchRobotRz
            // 
            this.labelCatchRobotRz.AutoSize = true;
            this.labelCatchRobotRz.Location = new System.Drawing.Point(5, 289);
            this.labelCatchRobotRz.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCatchRobotRz.Name = "labelCatchRobotRz";
            this.labelCatchRobotRz.Size = new System.Drawing.Size(127, 15);
            this.labelCatchRobotRz.TabIndex = 2;
            this.labelCatchRobotRz.Text = "Catch Robot Rz:";
            // 
            // textBoxCatchRobotRz
            // 
            this.textBoxCatchRobotRz.Location = new System.Drawing.Point(132, 282);
            this.textBoxCatchRobotRz.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxCatchRobotRz.Name = "textBoxCatchRobotRz";
            this.textBoxCatchRobotRz.Size = new System.Drawing.Size(271, 25);
            this.textBoxCatchRobotRz.TabIndex = 3;
            this.textBoxCatchRobotRz.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(412, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pixel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(412, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pixel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(412, 120);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "mm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(412, 154);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "mm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(412, 188);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "deg";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(412, 85);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "deg";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(412, 221);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "mm";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(412, 255);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "mm";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(412, 289);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 15);
            this.label9.TabIndex = 2;
            this.label9.Text = "deg";
            // 
            // buttonNewLine
            // 
            this.buttonNewLine.Location = new System.Drawing.Point(524, 33);
            this.buttonNewLine.Margin = new System.Windows.Forms.Padding(4);
            this.buttonNewLine.Name = "buttonNewLine";
            this.buttonNewLine.Size = new System.Drawing.Size(123, 32);
            this.buttonNewLine.TabIndex = 4;
            this.buttonNewLine.Text = "新建行";
            this.buttonNewLine.UseVisualStyleBackColor = true;
            this.buttonNewLine.Click += new System.EventHandler(this.buttonNewLine_Click);
            // 
            // buttonDeleteLine
            // 
            this.buttonDeleteLine.Location = new System.Drawing.Point(464, 48);
            this.buttonDeleteLine.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDeleteLine.Name = "buttonDeleteLine";
            this.buttonDeleteLine.Size = new System.Drawing.Size(231, 32);
            this.buttonDeleteLine.TabIndex = 4;
            this.buttonDeleteLine.Text = "删除行";
            this.buttonDeleteLine.UseVisualStyleBackColor = true;
            this.buttonDeleteLine.Click += new System.EventHandler(this.buttonDeleteLine_Click);
            // 
            // buttonCalibration
            // 
            this.buttonCalibration.Location = new System.Drawing.Point(464, 122);
            this.buttonCalibration.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCalibration.Name = "buttonCalibration";
            this.buttonCalibration.Size = new System.Drawing.Size(231, 32);
            this.buttonCalibration.TabIndex = 4;
            this.buttonCalibration.Text = "计算标定结果";
            this.buttonCalibration.UseVisualStyleBackColor = true;
            this.buttonCalibration.Click += new System.EventHandler(this.buttonCalibration_Click);
            // 
            // buttonSetCatchSet
            // 
            this.buttonSetCatchSet.Location = new System.Drawing.Point(464, 160);
            this.buttonSetCatchSet.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSetCatchSet.Name = "buttonSetCatchSet";
            this.buttonSetCatchSet.Size = new System.Drawing.Size(231, 32);
            this.buttonSetCatchSet.TabIndex = 4;
            this.buttonSetCatchSet.Text = "设置抓取点";
            this.buttonSetCatchSet.UseVisualStyleBackColor = true;
            this.buttonSetCatchSet.Click += new System.EventHandler(this.buttonSetCatchSet_Click);
            // 
            // buttonGetResult
            // 
            this.buttonGetResult.Location = new System.Drawing.Point(464, 198);
            this.buttonGetResult.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGetResult.Name = "buttonGetResult";
            this.buttonGetResult.Size = new System.Drawing.Size(231, 32);
            this.buttonGetResult.TabIndex = 4;
            this.buttonGetResult.Text = "获取坐标";
            this.buttonGetResult.UseVisualStyleBackColor = true;
            this.buttonGetResult.Click += new System.EventHandler(this.buttonGetResult_Click);
            // 
            // buttonSaveResult
            // 
            this.buttonSaveResult.Location = new System.Drawing.Point(464, 235);
            this.buttonSaveResult.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSaveResult.Name = "buttonSaveResult";
            this.buttonSaveResult.Size = new System.Drawing.Size(231, 32);
            this.buttonSaveResult.TabIndex = 4;
            this.buttonSaveResult.Text = "保存标定结果";
            this.buttonSaveResult.UseVisualStyleBackColor = true;
            this.buttonSaveResult.Click += new System.EventHandler(this.buttonSaveResult_Click);
            // 
            // buttonLoadResult
            // 
            this.buttonLoadResult.Location = new System.Drawing.Point(464, 272);
            this.buttonLoadResult.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLoadResult.Name = "buttonLoadResult";
            this.buttonLoadResult.Size = new System.Drawing.Size(231, 32);
            this.buttonLoadResult.TabIndex = 4;
            this.buttonLoadResult.Text = "加载标定结果";
            this.buttonLoadResult.UseVisualStyleBackColor = true;
            this.buttonLoadResult.Click += new System.EventHandler(this.buttonLoadResult_Click);
            // 
            // labelCameraX
            // 
            this.labelCameraX.AutoSize = true;
            this.labelCameraX.Location = new System.Drawing.Point(17, 8);
            this.labelCameraX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCameraX.Name = "labelCameraX";
            this.labelCameraX.Size = new System.Drawing.Size(71, 15);
            this.labelCameraX.TabIndex = 2;
            this.labelCameraX.Text = "Camera X";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(126, 8);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 15);
            this.label10.TabIndex = 2;
            this.label10.Text = "Camera Y";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(235, 8);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 15);
            this.label12.TabIndex = 2;
            this.label12.Text = "Robot X";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(336, 8);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 15);
            this.label11.TabIndex = 2;
            this.label11.Text = "Robot Y";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(437, 8);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 15);
            this.label13.TabIndex = 2;
            this.label13.Text = "Robot Rz";
            // 
            // textBoxCameraX
            // 
            this.textBoxCameraX.Location = new System.Drawing.Point(10, 37);
            this.textBoxCameraX.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxCameraX.Name = "textBoxCameraX";
            this.textBoxCameraX.Size = new System.Drawing.Size(85, 25);
            this.textBoxCameraX.TabIndex = 5;
            this.textBoxCameraX.Text = "0";
            // 
            // textBoxCameraY
            // 
            this.textBoxCameraY.Location = new System.Drawing.Point(115, 37);
            this.textBoxCameraY.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxCameraY.Name = "textBoxCameraY";
            this.textBoxCameraY.Size = new System.Drawing.Size(85, 25);
            this.textBoxCameraY.TabIndex = 5;
            this.textBoxCameraY.Text = "0";
            // 
            // textBoxRobotX
            // 
            this.textBoxRobotX.Location = new System.Drawing.Point(220, 37);
            this.textBoxRobotX.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxRobotX.Name = "textBoxRobotX";
            this.textBoxRobotX.Size = new System.Drawing.Size(85, 25);
            this.textBoxRobotX.TabIndex = 5;
            this.textBoxRobotX.Text = "0";
            // 
            // textBoxRobotY
            // 
            this.textBoxRobotY.Location = new System.Drawing.Point(325, 37);
            this.textBoxRobotY.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxRobotY.Name = "textBoxRobotY";
            this.textBoxRobotY.Size = new System.Drawing.Size(85, 25);
            this.textBoxRobotY.TabIndex = 5;
            this.textBoxRobotY.Text = "0";
            // 
            // textBoxRobotRz
            // 
            this.textBoxRobotRz.Location = new System.Drawing.Point(430, 37);
            this.textBoxRobotRz.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxRobotRz.Name = "textBoxRobotRz";
            this.textBoxRobotRz.Size = new System.Drawing.Size(85, 25);
            this.textBoxRobotRz.TabIndex = 5;
            this.textBoxRobotRz.Text = "0";
            // 
            // buttonUpdateLine
            // 
            this.buttonUpdateLine.Location = new System.Drawing.Point(464, 85);
            this.buttonUpdateLine.Margin = new System.Windows.Forms.Padding(4);
            this.buttonUpdateLine.Name = "buttonUpdateLine";
            this.buttonUpdateLine.Size = new System.Drawing.Size(231, 32);
            this.buttonUpdateLine.TabIndex = 4;
            this.buttonUpdateLine.Text = "更新行";
            this.buttonUpdateLine.UseVisualStyleBackColor = true;
            this.buttonUpdateLine.Click += new System.EventHandler(this.buttonUpdateLine_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxImageA);
            this.panel1.Controls.Add(this.labelResultImageX);
            this.panel1.Controls.Add(this.textBoxImageX);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labelResultImageY);
            this.panel1.Controls.Add(this.textBoxImageY);
            this.panel1.Controls.Add(this.buttonLoadResult);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.buttonSaveResult);
            this.panel1.Controls.Add(this.labelRobotPosX);
            this.panel1.Controls.Add(this.buttonGetResult);
            this.panel1.Controls.Add(this.textBoxRobotPosX);
            this.panel1.Controls.Add(this.buttonSetCatchSet);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.buttonCalibration);
            this.panel1.Controls.Add(this.labelRobotPosY);
            this.panel1.Controls.Add(this.buttonUpdateLine);
            this.panel1.Controls.Add(this.textBoxRobotPosY);
            this.panel1.Controls.Add(this.buttonDeleteLine);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.labelRobotPosRz);
            this.panel1.Controls.Add(this.textBoxCatchRobotRz);
            this.panel1.Controls.Add(this.textBoxRobotPosRz);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.labelCatchRobotRz);
            this.panel1.Controls.Add(this.labelResultImageA);
            this.panel1.Controls.Add(this.textBoxCatchRobotY);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.labelCatchRobotX);
            this.panel1.Controls.Add(this.labelCatchRobotY);
            this.panel1.Controls.Add(this.textBoxCatchRobotX);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(6, 530);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(695, 320);
            this.panel1.TabIndex = 6;
            // 
            // panelSingleInput
            // 
            this.panelSingleInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSingleInput.Controls.Add(this.textBoxCameraX);
            this.panelSingleInput.Controls.Add(this.labelCameraX);
            this.panelSingleInput.Controls.Add(this.textBoxRobotRz);
            this.panelSingleInput.Controls.Add(this.textBoxCameraY);
            this.panelSingleInput.Controls.Add(this.buttonNewLine);
            this.panelSingleInput.Controls.Add(this.textBoxRobotY);
            this.panelSingleInput.Controls.Add(this.label10);
            this.panelSingleInput.Controls.Add(this.textBoxRobotX);
            this.panelSingleInput.Controls.Add(this.label12);
            this.panelSingleInput.Controls.Add(this.label11);
            this.panelSingleInput.Controls.Add(this.label13);
            this.panelSingleInput.Location = new System.Drawing.Point(40, 51);
            this.panelSingleInput.Name = "panelSingleInput";
            this.panelSingleInput.Size = new System.Drawing.Size(651, 68);
            this.panelSingleInput.TabIndex = 7;
            // 
            // panelBatchInput
            // 
            this.panelBatchInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBatchInput.Controls.Add(this.textBoxWorldCoordianteFilePath);
            this.panelBatchInput.Controls.Add(this.textBoxCalibrateImagPath);
            this.panelBatchInput.Controls.Add(this.label15);
            this.panelBatchInput.Controls.Add(this.label14);
            this.panelBatchInput.Controls.Add(this.buttonSelectWorldPos);
            this.panelBatchInput.Controls.Add(this.buttonSelectCalPic);
            this.panelBatchInput.Location = new System.Drawing.Point(40, 153);
            this.panelBatchInput.Name = "panelBatchInput";
            this.panelBatchInput.Size = new System.Drawing.Size(651, 74);
            this.panelBatchInput.TabIndex = 8;
            // 
            // textBoxWorldCoordianteFilePath
            // 
            this.textBoxWorldCoordianteFilePath.Enabled = false;
            this.textBoxWorldCoordianteFilePath.Location = new System.Drawing.Point(159, 42);
            this.textBoxWorldCoordianteFilePath.Name = "textBoxWorldCoordianteFilePath";
            this.textBoxWorldCoordianteFilePath.Size = new System.Drawing.Size(358, 25);
            this.textBoxWorldCoordianteFilePath.TabIndex = 1;
            // 
            // textBoxCalibrateImagPath
            // 
            this.textBoxCalibrateImagPath.Enabled = false;
            this.textBoxCalibrateImagPath.Location = new System.Drawing.Point(159, 7);
            this.textBoxCalibrateImagPath.Name = "textBoxCalibrateImagPath";
            this.textBoxCalibrateImagPath.Size = new System.Drawing.Size(358, 25);
            this.textBoxCalibrateImagPath.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(4, 48);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(157, 15);
            this.label15.TabIndex = 0;
            this.label15.Text = "选择世界坐标文件路径";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(127, 15);
            this.label14.TabIndex = 0;
            this.label14.Text = "选择标定图片路径";
            // 
            // buttonSelectWorldPos
            // 
            this.buttonSelectWorldPos.Location = new System.Drawing.Point(524, 38);
            this.buttonSelectWorldPos.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSelectWorldPos.Name = "buttonSelectWorldPos";
            this.buttonSelectWorldPos.Size = new System.Drawing.Size(123, 32);
            this.buttonSelectWorldPos.TabIndex = 4;
            this.buttonSelectWorldPos.Text = "选择";
            this.buttonSelectWorldPos.UseVisualStyleBackColor = true;
            this.buttonSelectWorldPos.Click += new System.EventHandler(this.buttonSelectWorldPos_Click);
            // 
            // buttonSelectCalPic
            // 
            this.buttonSelectCalPic.Enabled = false;
            this.buttonSelectCalPic.Location = new System.Drawing.Point(524, 4);
            this.buttonSelectCalPic.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSelectCalPic.Name = "buttonSelectCalPic";
            this.buttonSelectCalPic.Size = new System.Drawing.Size(123, 32);
            this.buttonSelectCalPic.TabIndex = 4;
            this.buttonSelectCalPic.Text = "选择";
            this.buttonSelectCalPic.UseVisualStyleBackColor = true;
            this.buttonSelectCalPic.Click += new System.EventHandler(this.buttonSelectCalPic_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonSingleInput);
            this.groupBox1.Controls.Add(this.radioButtonBatchInput);
            this.groupBox1.Controls.Add(this.panelSingleInput);
            this.groupBox1.Controls.Add(this.panelBatchInput);
            this.groupBox1.Location = new System.Drawing.Point(9, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(695, 235);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据输入";
            // 
            // radioButtonSingleInput
            // 
            this.radioButtonSingleInput.AutoSize = true;
            this.radioButtonSingleInput.Location = new System.Drawing.Point(3, 30);
            this.radioButtonSingleInput.Name = "radioButtonSingleInput";
            this.radioButtonSingleInput.Size = new System.Drawing.Size(88, 19);
            this.radioButtonSingleInput.TabIndex = 9;
            this.radioButtonSingleInput.Text = "单行输入";
            this.radioButtonSingleInput.UseVisualStyleBackColor = true;
            this.radioButtonSingleInput.CheckedChanged += new System.EventHandler(this.radioButtonSingleInput_CheckedChanged);
            // 
            // radioButtonBatchInput
            // 
            this.radioButtonBatchInput.AutoSize = true;
            this.radioButtonBatchInput.Checked = true;
            this.radioButtonBatchInput.Location = new System.Drawing.Point(3, 132);
            this.radioButtonBatchInput.Name = "radioButtonBatchInput";
            this.radioButtonBatchInput.Size = new System.Drawing.Size(88, 19);
            this.radioButtonBatchInput.TabIndex = 9;
            this.radioButtonBatchInput.TabStop = true;
            this.radioButtonBatchInput.Text = "批量输入";
            this.radioButtonBatchInput.UseVisualStyleBackColor = true;
            this.radioButtonBatchInput.CheckedChanged += new System.EventHandler(this.radioButtonBatchInput_CheckedChanged);
            // 
            // CalibrationSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 903);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.comboBoxModeList);
            this.Controls.Add(this.listViewParameterSet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CalibrationSetForm";
            this.Text = "标定参数设置";
            this.Load += new System.EventHandler(this.CalibrationSetForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelSingleInput.ResumeLayout(false);
            this.panelSingleInput.PerformLayout();
            this.panelBatchInput.ResumeLayout(false);
            this.panelBatchInput.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewParameterSet;
        private System.Windows.Forms.ComboBox comboBoxModeList;
        private System.Windows.Forms.Label labelResultImageX;
        private System.Windows.Forms.TextBox textBoxImageX;
        private System.Windows.Forms.Label labelResultImageY;
        private System.Windows.Forms.TextBox textBoxImageY;
        private System.Windows.Forms.Label labelRobotPosX;
        private System.Windows.Forms.TextBox textBoxRobotPosX;
        private System.Windows.Forms.Label labelRobotPosY;
        private System.Windows.Forms.TextBox textBoxRobotPosY;
        private System.Windows.Forms.Label labelRobotPosRz;
        private System.Windows.Forms.TextBox textBoxRobotPosRz;
        private System.Windows.Forms.Label labelResultImageA;
        private System.Windows.Forms.TextBox textBoxImageA;
        private System.Windows.Forms.Label labelCatchRobotX;
        private System.Windows.Forms.TextBox textBoxCatchRobotX;
        private System.Windows.Forms.Label labelCatchRobotY;
        private System.Windows.Forms.TextBox textBoxCatchRobotY;
        private System.Windows.Forms.Label labelCatchRobotRz;
        private System.Windows.Forms.TextBox textBoxCatchRobotRz;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonNewLine;
        private System.Windows.Forms.Button buttonDeleteLine;
        private System.Windows.Forms.Button buttonCalibration;
        private System.Windows.Forms.Button buttonSetCatchSet;
        private System.Windows.Forms.Button buttonGetResult;
        private System.Windows.Forms.Button buttonSaveResult;
        private System.Windows.Forms.Button buttonLoadResult;
        private System.Windows.Forms.Label labelCameraX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxCameraX;
        private System.Windows.Forms.TextBox textBoxCameraY;
        private System.Windows.Forms.TextBox textBoxRobotX;
        private System.Windows.Forms.TextBox textBoxRobotY;
        private System.Windows.Forms.TextBox textBoxRobotRz;
        private System.Windows.Forms.Button buttonUpdateLine;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelSingleInput;
        private System.Windows.Forms.Panel panelBatchInput;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxWorldCoordianteFilePath;
        private System.Windows.Forms.TextBox textBoxCalibrateImagPath;
        private System.Windows.Forms.Button buttonSelectCalPic;
        private System.Windows.Forms.Button buttonSelectWorldPos;
        private System.Windows.Forms.RadioButton radioButtonBatchInput;
        private System.Windows.Forms.RadioButton radioButtonSingleInput;
    }
}