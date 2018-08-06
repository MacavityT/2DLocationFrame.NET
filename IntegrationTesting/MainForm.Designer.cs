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
            this.aqDisplay1 = new AqVision.Controls.AqDisplay();
            this.btn_LoadBitmap = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonAddLine = new System.Windows.Forms.Button();
            this.buttonAddCircle = new System.Windows.Forms.Button();
            this.buttonAddRectangleRegion = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxCameraAcquisition = new System.Windows.Forms.CheckBox();
            this.buttonTemplateManagement = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonTemplateSet = new System.Windows.Forms.Button();
            this.buttonCalibration = new System.Windows.Forms.Button();
            this.buttonTraining = new System.Windows.Forms.Button();
            this.buttonCloseCamera = new System.Windows.Forms.Button();
            this.buttonAcquisitionModule = new System.Windows.Forms.Button();
            this.buttonRun = new System.Windows.Forms.Button();
            this.listViewRecord = new System.Windows.Forms.ListView();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // aqDisplay1
            // 
            this.aqDisplay1.AutoScroll = true;
            this.aqDisplay1.Image = null;
            this.aqDisplay1.Location = new System.Drawing.Point(0, 0);
            this.aqDisplay1.Margin = new System.Windows.Forms.Padding(2);
            this.aqDisplay1.Name = "aqDisplay1";
            this.aqDisplay1.Size = new System.Drawing.Size(868, 569);
            this.aqDisplay1.TabIndex = 0;
            // 
            // btn_LoadBitmap
            // 
            this.btn_LoadBitmap.Location = new System.Drawing.Point(2, 139);
            this.btn_LoadBitmap.Margin = new System.Windows.Forms.Padding(2);
            this.btn_LoadBitmap.Name = "btn_LoadBitmap";
            this.btn_LoadBitmap.Size = new System.Drawing.Size(92, 34);
            this.btn_LoadBitmap.TabIndex = 1;
            this.btn_LoadBitmap.Text = "加载图片";
            this.btn_LoadBitmap.UseVisualStyleBackColor = true;
            this.btn_LoadBitmap.Click += new System.EventHandler(this.btn_LoadBitmap_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 253);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 34);
            this.button3.TabIndex = 4;
            this.button3.Text = "移除所有图形";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // buttonAddLine
            // 
            this.buttonAddLine.Location = new System.Drawing.Point(3, 177);
            this.buttonAddLine.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddLine.Name = "buttonAddLine";
            this.buttonAddLine.Size = new System.Drawing.Size(92, 34);
            this.buttonAddLine.TabIndex = 2;
            this.buttonAddLine.Text = "添加直线";
            this.buttonAddLine.UseVisualStyleBackColor = true;
            this.buttonAddLine.Click += new System.EventHandler(this.buttonAddLine_Click);
            // 
            // buttonAddCircle
            // 
            this.buttonAddCircle.Location = new System.Drawing.Point(3, 215);
            this.buttonAddCircle.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddCircle.Name = "buttonAddCircle";
            this.buttonAddCircle.Size = new System.Drawing.Size(92, 34);
            this.buttonAddCircle.TabIndex = 3;
            this.buttonAddCircle.Text = "添加圆形";
            this.buttonAddCircle.UseVisualStyleBackColor = true;
            this.buttonAddCircle.Click += new System.EventHandler(this.buttonAddCircle_Click);
            // 
            // buttonAddRectangleRegion
            // 
            this.buttonAddRectangleRegion.Location = new System.Drawing.Point(5, 25);
            this.buttonAddRectangleRegion.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddRectangleRegion.Name = "buttonAddRectangleRegion";
            this.buttonAddRectangleRegion.Size = new System.Drawing.Size(92, 34);
            this.buttonAddRectangleRegion.TabIndex = 3;
            this.buttonAddRectangleRegion.Text = "添加示教区";
            this.buttonAddRectangleRegion.UseVisualStyleBackColor = true;
            this.buttonAddRectangleRegion.Click += new System.EventHandler(this.buttonAddRectangle_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxCameraAcquisition);
            this.groupBox2.Controls.Add(this.buttonTemplateManagement);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.buttonRun);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(879, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(103, 696);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // checkBoxCameraAcquisition
            // 
            this.checkBoxCameraAcquisition.AutoSize = true;
            this.checkBoxCameraAcquisition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.checkBoxCameraAcquisition.Location = new System.Drawing.Point(18, 20);
            this.checkBoxCameraAcquisition.Name = "checkBoxCameraAcquisition";
            this.checkBoxCameraAcquisition.Size = new System.Drawing.Size(72, 16);
            this.checkBoxCameraAcquisition.TabIndex = 6;
            this.checkBoxCameraAcquisition.Text = "连续采集";
            this.checkBoxCameraAcquisition.UseVisualStyleBackColor = false;
            this.checkBoxCameraAcquisition.CheckedChanged += new System.EventHandler(this.checkBoxCameraAcquisition_CheckedChanged);
            // 
            // buttonTemplateManagement
            // 
            this.buttonTemplateManagement.Location = new System.Drawing.Point(1, 97);
            this.buttonTemplateManagement.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTemplateManagement.Name = "buttonTemplateManagement";
            this.buttonTemplateManagement.Size = new System.Drawing.Size(92, 34);
            this.buttonTemplateManagement.TabIndex = 4;
            this.buttonTemplateManagement.Text = "模板设置";
            this.buttonTemplateManagement.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonTemplateSet);
            this.groupBox1.Controls.Add(this.btn_LoadBitmap);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.buttonAddRectangleRegion);
            this.groupBox1.Controls.Add(this.buttonCalibration);
            this.groupBox1.Controls.Add(this.buttonTraining);
            this.groupBox1.Controls.Add(this.buttonCloseCamera);
            this.groupBox1.Controls.Add(this.buttonAcquisitionModule);
            this.groupBox1.Controls.Add(this.buttonAddCircle);
            this.groupBox1.Controls.Add(this.buttonAddLine);
            this.groupBox1.Location = new System.Drawing.Point(2, 278);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(98, 400);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "测试";
            // 
            // buttonTemplateSet
            // 
            this.buttonTemplateSet.Location = new System.Drawing.Point(1, 367);
            this.buttonTemplateSet.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTemplateSet.Name = "buttonTemplateSet";
            this.buttonTemplateSet.Size = new System.Drawing.Size(92, 34);
            this.buttonTemplateSet.TabIndex = 4;
            this.buttonTemplateSet.Text = "模板制作";
            this.buttonTemplateSet.UseVisualStyleBackColor = true;
            this.buttonTemplateSet.Click += new System.EventHandler(this.buttonTemplateSet_Click);
            // 
            // buttonCalibration
            // 
            this.buttonCalibration.Location = new System.Drawing.Point(2, 329);
            this.buttonCalibration.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCalibration.Name = "buttonCalibration";
            this.buttonCalibration.Size = new System.Drawing.Size(92, 34);
            this.buttonCalibration.TabIndex = 4;
            this.buttonCalibration.Text = "标定";
            this.buttonCalibration.UseVisualStyleBackColor = true;
            this.buttonCalibration.Click += new System.EventHandler(this.buttonCalibration_Click);
            // 
            // buttonTraining
            // 
            this.buttonTraining.Location = new System.Drawing.Point(3, 63);
            this.buttonTraining.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTraining.Name = "buttonTraining";
            this.buttonTraining.Size = new System.Drawing.Size(92, 34);
            this.buttonTraining.TabIndex = 3;
            this.buttonTraining.Text = "训练";
            this.buttonTraining.UseVisualStyleBackColor = true;
            this.buttonTraining.Click += new System.EventHandler(this.buttonTraining_Click);
            // 
            // buttonCloseCamera
            // 
            this.buttonCloseCamera.Location = new System.Drawing.Point(3, 101);
            this.buttonCloseCamera.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCloseCamera.Name = "buttonCloseCamera";
            this.buttonCloseCamera.Size = new System.Drawing.Size(92, 34);
            this.buttonCloseCamera.TabIndex = 3;
            this.buttonCloseCamera.Text = "关闭相机";
            this.buttonCloseCamera.UseVisualStyleBackColor = true;
            this.buttonCloseCamera.Click += new System.EventHandler(this.buttonCloseCamera_Click);
            // 
            // buttonAcquisitionModule
            // 
            this.buttonAcquisitionModule.Location = new System.Drawing.Point(3, 291);
            this.buttonAcquisitionModule.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAcquisitionModule.Name = "buttonAcquisitionModule";
            this.buttonAcquisitionModule.Size = new System.Drawing.Size(92, 34);
            this.buttonAcquisitionModule.TabIndex = 4;
            this.buttonAcquisitionModule.Text = "取像";
            this.buttonAcquisitionModule.UseVisualStyleBackColor = true;
            this.buttonAcquisitionModule.Click += new System.EventHandler(this.buttonAcquisitionModule_Click);
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(4, 51);
            this.buttonRun.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(90, 41);
            this.buttonRun.TabIndex = 3;
            this.buttonRun.Text = "运行";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // listViewRecord
            // 
            this.listViewRecord.FullRowSelect = true;
            this.listViewRecord.GridLines = true;
            this.listViewRecord.LabelEdit = true;
            this.listViewRecord.Location = new System.Drawing.Point(0, 574);
            this.listViewRecord.MultiSelect = false;
            this.listViewRecord.Name = "listViewRecord";
            this.listViewRecord.Size = new System.Drawing.Size(873, 107);
            this.listViewRecord.TabIndex = 8;
            this.listViewRecord.UseCompatibleStateImageBehavior = false;
            this.listViewRecord.View = System.Windows.Forms.View.Details;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 696);
            this.Controls.Add(this.listViewRecord);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.aqDisplay1);
            this.Name = "MainForm";
            this.Text = "FormShow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AqVision.Controls.AqDisplay aqDisplay1;
        private System.Windows.Forms.Button btn_LoadBitmap;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonAddLine;
        private System.Windows.Forms.Button buttonAddCircle;
        private System.Windows.Forms.Button buttonAddRectangleRegion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonTraining;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.ListView listViewRecord;
        private System.Windows.Forms.Button buttonCloseCamera;
        private System.Windows.Forms.Button buttonAcquisitionModule;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxCameraAcquisition;
        private System.Windows.Forms.Button buttonCalibration;
        private System.Windows.Forms.Button buttonTemplateManagement;
        private System.Windows.Forms.Button buttonTemplateSet;
    }
}

