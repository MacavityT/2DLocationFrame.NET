namespace IntegrationTesting
{
    partial class FormShow
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
            this.buttonContinuousAcquisition = new System.Windows.Forms.Button();
            this.buttonAddRectangleRegion = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1_Test = new System.Windows.Forms.Button();
            this.buttonStopAcquisition = new System.Windows.Forms.Button();
            this.buttonCloseCamera = new System.Windows.Forms.Button();
            this.buttonRun = new System.Windows.Forms.Button();
            this.buttonTraining = new System.Windows.Forms.Button();
            this.listViewRecord = new System.Windows.Forms.ListView();
            this.groupBox2.SuspendLayout();
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
            this.btn_LoadBitmap.Location = new System.Drawing.Point(4, 430);
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
            this.button3.Location = new System.Drawing.Point(6, 554);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 34);
            this.button3.TabIndex = 4;
            this.button3.Text = "移除所有图形";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            // 
            // buttonAddLine
            // 
            this.buttonAddLine.Location = new System.Drawing.Point(6, 478);
            this.buttonAddLine.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddLine.Name = "buttonAddLine";
            this.buttonAddLine.Size = new System.Drawing.Size(92, 34);
            this.buttonAddLine.TabIndex = 2;
            this.buttonAddLine.Text = "添加直线";
            this.buttonAddLine.UseVisualStyleBackColor = true;
            this.buttonAddLine.Visible = false;
            this.buttonAddLine.Click += new System.EventHandler(this.buttonAddLine_Click);
            // 
            // buttonAddCircle
            // 
            this.buttonAddCircle.Location = new System.Drawing.Point(6, 516);
            this.buttonAddCircle.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddCircle.Name = "buttonAddCircle";
            this.buttonAddCircle.Size = new System.Drawing.Size(92, 34);
            this.buttonAddCircle.TabIndex = 3;
            this.buttonAddCircle.Text = "添加圆形";
            this.buttonAddCircle.UseVisualStyleBackColor = true;
            this.buttonAddCircle.Visible = false;
            this.buttonAddCircle.Click += new System.EventHandler(this.buttonAddCircle_Click);
            // 
            // buttonContinuousAcquisition
            // 
            this.buttonContinuousAcquisition.Location = new System.Drawing.Point(5, 19);
            this.buttonContinuousAcquisition.Margin = new System.Windows.Forms.Padding(2);
            this.buttonContinuousAcquisition.Name = "buttonContinuousAcquisition";
            this.buttonContinuousAcquisition.Size = new System.Drawing.Size(94, 34);
            this.buttonContinuousAcquisition.TabIndex = 1;
            this.buttonContinuousAcquisition.Text = "连续采集";
            this.buttonContinuousAcquisition.UseVisualStyleBackColor = true;
            this.buttonContinuousAcquisition.Click += new System.EventHandler(this.buttonAcquisition_Click);
            // 
            // buttonAddRectangleRegion
            // 
            this.buttonAddRectangleRegion.Location = new System.Drawing.Point(6, 128);
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
            this.groupBox2.Controls.Add(this.btn_LoadBitmap);
            this.groupBox2.Controls.Add(this.button1_Test);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.buttonStopAcquisition);
            this.groupBox2.Controls.Add(this.buttonContinuousAcquisition);
            this.groupBox2.Controls.Add(this.buttonAddLine);
            this.groupBox2.Controls.Add(this.buttonCloseCamera);
            this.groupBox2.Controls.Add(this.buttonRun);
            this.groupBox2.Controls.Add(this.buttonTraining);
            this.groupBox2.Controls.Add(this.buttonAddCircle);
            this.groupBox2.Controls.Add(this.buttonAddRectangleRegion);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(877, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(105, 696);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // button1_Test
            // 
            this.button1_Test.Location = new System.Drawing.Point(8, 606);
            this.button1_Test.Margin = new System.Windows.Forms.Padding(2);
            this.button1_Test.Name = "button1_Test";
            this.button1_Test.Size = new System.Drawing.Size(92, 34);
            this.button1_Test.TabIndex = 4;
            this.button1_Test.Text = "test";
            this.button1_Test.UseVisualStyleBackColor = true;
            this.button1_Test.Visible = false;
            this.button1_Test.Click += new System.EventHandler(this.button1_Test_Click);
            // 
            // buttonStopAcquisition
            // 
            this.buttonStopAcquisition.Location = new System.Drawing.Point(6, 73);
            this.buttonStopAcquisition.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStopAcquisition.Name = "buttonStopAcquisition";
            this.buttonStopAcquisition.Size = new System.Drawing.Size(94, 34);
            this.buttonStopAcquisition.TabIndex = 1;
            this.buttonStopAcquisition.Text = "停止采集";
            this.buttonStopAcquisition.UseVisualStyleBackColor = true;
            this.buttonStopAcquisition.Click += new System.EventHandler(this.buttonStopAcquisition_Click);
            // 
            // buttonCloseCamera
            // 
            this.buttonCloseCamera.Location = new System.Drawing.Point(8, 300);
            this.buttonCloseCamera.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCloseCamera.Name = "buttonCloseCamera";
            this.buttonCloseCamera.Size = new System.Drawing.Size(92, 34);
            this.buttonCloseCamera.TabIndex = 3;
            this.buttonCloseCamera.Text = "关闭相机";
            this.buttonCloseCamera.UseVisualStyleBackColor = true;
            this.buttonCloseCamera.Click += new System.EventHandler(this.buttonCloseCamera_Click);
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(7, 238);
            this.buttonRun.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(92, 34);
            this.buttonRun.TabIndex = 3;
            this.buttonRun.Text = "运行";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // buttonTraining
            // 
            this.buttonTraining.Location = new System.Drawing.Point(8, 182);
            this.buttonTraining.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTraining.Name = "buttonTraining";
            this.buttonTraining.Size = new System.Drawing.Size(92, 34);
            this.buttonTraining.TabIndex = 3;
            this.buttonTraining.Text = "训练";
            this.buttonTraining.UseVisualStyleBackColor = true;
            this.buttonTraining.Click += new System.EventHandler(this.buttonTraining_Click);
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
            // FormShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 696);
            this.Controls.Add(this.listViewRecord);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.aqDisplay1);
            this.Name = "FormShow";
            this.Text = "FormShow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AqVision.Controls.AqDisplay aqDisplay1;
        private System.Windows.Forms.Button btn_LoadBitmap;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonAddLine;
        private System.Windows.Forms.Button buttonAddCircle;
        private System.Windows.Forms.Button buttonAddRectangleRegion;
        private System.Windows.Forms.Button buttonContinuousAcquisition;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonStopAcquisition;
        private System.Windows.Forms.Button buttonTraining;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.ListView listViewRecord;
        private System.Windows.Forms.Button buttonCloseCamera;
        private System.Windows.Forms.Button button1_Test;
    }
}

