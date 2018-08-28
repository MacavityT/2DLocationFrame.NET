namespace IntegrationTesting
{
    partial class AcqusitionImageSet
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCameraBrandLocation = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCameraNameLocation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxExposureTimeLocation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxCameraBrandDetection = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxExposureTimeDetection = new System.Windows.Forms.TextBox();
            this.textBoxCameraNameDetection = new System.Windows.Forms.TextBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.panelLocal = new System.Windows.Forms.Panel();
            this.textBoxLocationDirectory = new System.Windows.Forms.TextBox();
            this.buttonDetectionDirectory = new System.Windows.Forms.Button();
            this.textBoxDetectionDirectory = new System.Windows.Forms.TextBox();
            this.buttonLocationDirectory = new System.Windows.Forms.Button();
            this.panelCamera = new System.Windows.Forms.Panel();
            this.radioButtonCamera = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.panelLocal.SuspendLayout();
            this.panelCamera.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "相机品牌";
            // 
            // comboBoxCameraBrandLocation
            // 
            this.comboBoxCameraBrandLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCameraBrandLocation.FormattingEnabled = true;
            this.comboBoxCameraBrandLocation.Items.AddRange(new object[] {
            "DaHeng",
            "Balser"});
            this.comboBoxCameraBrandLocation.Location = new System.Drawing.Point(113, 29);
            this.comboBoxCameraBrandLocation.Name = "comboBoxCameraBrandLocation";
            this.comboBoxCameraBrandLocation.Size = new System.Drawing.Size(74, 20);
            this.comboBoxCameraBrandLocation.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Camera Name";
            // 
            // textBoxCameraNameLocation
            // 
            this.textBoxCameraNameLocation.Location = new System.Drawing.Point(113, 58);
            this.textBoxCameraNameLocation.Name = "textBoxCameraNameLocation";
            this.textBoxCameraNameLocation.Size = new System.Drawing.Size(74, 21);
            this.textBoxCameraNameLocation.TabIndex = 2;
            this.textBoxCameraNameLocation.Text = "Aqrose_L";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Exposure Time";
            // 
            // textBoxExposureTimeLocation
            // 
            this.textBoxExposureTimeLocation.Location = new System.Drawing.Point(113, 82);
            this.textBoxExposureTimeLocation.Name = "textBoxExposureTimeLocation";
            this.textBoxExposureTimeLocation.Size = new System.Drawing.Size(74, 21);
            this.textBoxExposureTimeLocation.TabIndex = 3;
            this.textBoxExposureTimeLocation.Text = "5000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(193, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "ms";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(347, 462);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(189, 462);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxCameraBrandLocation);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxExposureTimeLocation);
            this.groupBox1.Controls.Add(this.textBoxCameraNameLocation);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 117);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "定位";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxCameraBrandDetection);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBoxExposureTimeDetection);
            this.groupBox2.Controls.Add(this.textBoxCameraNameDetection);
            this.groupBox2.Location = new System.Drawing.Point(226, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 117);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "检测相机";
            // 
            // comboBoxCameraBrandDetection
            // 
            this.comboBoxCameraBrandDetection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCameraBrandDetection.FormattingEnabled = true;
            this.comboBoxCameraBrandDetection.Items.AddRange(new object[] {
            "DaHeng",
            "Balser"});
            this.comboBoxCameraBrandDetection.Location = new System.Drawing.Point(113, 29);
            this.comboBoxCameraBrandDetection.Name = "comboBoxCameraBrandDetection";
            this.comboBoxCameraBrandDetection.Size = new System.Drawing.Size(80, 20);
            this.comboBoxCameraBrandDetection.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "相机品牌";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "Camera Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(199, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "ms";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "Exposure Time";
            // 
            // textBoxExposureTimeDetection
            // 
            this.textBoxExposureTimeDetection.Location = new System.Drawing.Point(113, 82);
            this.textBoxExposureTimeDetection.Name = "textBoxExposureTimeDetection";
            this.textBoxExposureTimeDetection.Size = new System.Drawing.Size(80, 21);
            this.textBoxExposureTimeDetection.TabIndex = 3;
            this.textBoxExposureTimeDetection.Text = "5000";
            // 
            // textBoxCameraNameDetection
            // 
            this.textBoxCameraNameDetection.Location = new System.Drawing.Point(113, 58);
            this.textBoxCameraNameDetection.Name = "textBoxCameraNameDetection";
            this.textBoxCameraNameDetection.Size = new System.Drawing.Size(80, 21);
            this.textBoxCameraNameDetection.TabIndex = 2;
            this.textBoxCameraNameDetection.Text = "Aqrose_D";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.panel1);
            this.groupBox.Controls.Add(this.panelLocal);
            this.groupBox.Controls.Add(this.panelCamera);
            this.groupBox.Controls.Add(this.radioButtonCamera);
            this.groupBox.Controls.Add(this.radioButton2);
            this.groupBox.Controls.Add(this.radioButton1);
            this.groupBox.Location = new System.Drawing.Point(12, 2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(521, 454);
            this.groupBox.TabIndex = 7;
            this.groupBox.TabStop = false;
            // 
            // panelLocal
            // 
            this.panelLocal.Controls.Add(this.textBoxLocationDirectory);
            this.panelLocal.Controls.Add(this.buttonDetectionDirectory);
            this.panelLocal.Controls.Add(this.textBoxDetectionDirectory);
            this.panelLocal.Controls.Add(this.buttonLocationDirectory);
            this.panelLocal.Location = new System.Drawing.Point(57, 211);
            this.panelLocal.Name = "panelLocal";
            this.panelLocal.Size = new System.Drawing.Size(458, 93);
            this.panelLocal.TabIndex = 8;
            // 
            // textBoxLocationDirectory
            // 
            this.textBoxLocationDirectory.Location = new System.Drawing.Point(3, 18);
            this.textBoxLocationDirectory.Name = "textBoxLocationDirectory";
            this.textBoxLocationDirectory.Size = new System.Drawing.Size(370, 21);
            this.textBoxLocationDirectory.TabIndex = 9;
            // 
            // buttonDetectionDirectory
            // 
            this.buttonDetectionDirectory.Location = new System.Drawing.Point(378, 56);
            this.buttonDetectionDirectory.Name = "buttonDetectionDirectory";
            this.buttonDetectionDirectory.Size = new System.Drawing.Size(75, 34);
            this.buttonDetectionDirectory.TabIndex = 10;
            this.buttonDetectionDirectory.Text = "检测文件";
            this.buttonDetectionDirectory.UseVisualStyleBackColor = true;
            // 
            // textBoxDetectionDirectory
            // 
            this.textBoxDetectionDirectory.Location = new System.Drawing.Point(2, 63);
            this.textBoxDetectionDirectory.Name = "textBoxDetectionDirectory";
            this.textBoxDetectionDirectory.Size = new System.Drawing.Size(370, 21);
            this.textBoxDetectionDirectory.TabIndex = 9;
            // 
            // buttonLocationDirectory
            // 
            this.buttonLocationDirectory.Location = new System.Drawing.Point(379, 11);
            this.buttonLocationDirectory.Name = "buttonLocationDirectory";
            this.buttonLocationDirectory.Size = new System.Drawing.Size(75, 34);
            this.buttonLocationDirectory.TabIndex = 10;
            this.buttonLocationDirectory.Text = "定位文件";
            this.buttonLocationDirectory.UseVisualStyleBackColor = true;
            // 
            // panelCamera
            // 
            this.panelCamera.Controls.Add(this.groupBox1);
            this.panelCamera.Controls.Add(this.groupBox2);
            this.panelCamera.Location = new System.Drawing.Point(62, 40);
            this.panelCamera.Name = "panelCamera";
            this.panelCamera.Size = new System.Drawing.Size(452, 128);
            this.panelCamera.TabIndex = 8;
            // 
            // radioButtonCamera
            // 
            this.radioButtonCamera.AutoSize = true;
            this.radioButtonCamera.Location = new System.Drawing.Point(13, 20);
            this.radioButtonCamera.Name = "radioButtonCamera";
            this.radioButtonCamera.Size = new System.Drawing.Size(47, 16);
            this.radioButtonCamera.TabIndex = 8;
            this.radioButtonCamera.TabStop = true;
            this.radioButtonCamera.Text = "相机";
            this.radioButtonCamera.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(13, 191);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 16);
            this.radioButton1.TabIndex = 8;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "文件";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(13, 321);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 16);
            this.radioButton2.TabIndex = 8;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "文件夹";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(57, 343);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(458, 93);
            this.panel1.TabIndex = 8;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(370, 21);
            this.textBox1.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(378, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 10;
            this.button1.Text = "检测文件夹";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(2, 63);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(370, 21);
            this.textBox2.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(379, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 34);
            this.button2.TabIndex = 10;
            this.button2.Text = "定位文件夹";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // AcqusitionImageSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 484);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Name = "AcqusitionImageSet";
            this.Text = "取像参数设置";
            this.Load += new System.EventHandler(this.AcqusitionImageSet_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.panelLocal.ResumeLayout(false);
            this.panelLocal.PerformLayout();
            this.panelCamera.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxCameraBrandLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCameraNameLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxExposureTimeLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxCameraBrandDetection;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxExposureTimeDetection;
        private System.Windows.Forms.TextBox textBoxCameraNameDetection;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButtonCamera;
        private System.Windows.Forms.Button buttonLocationDirectory;
        private System.Windows.Forms.TextBox textBoxLocationDirectory;
        private System.Windows.Forms.Button buttonDetectionDirectory;
        private System.Windows.Forms.TextBox textBoxDetectionDirectory;
        private System.Windows.Forms.Panel panelLocal;
        private System.Windows.Forms.Panel panelCamera;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}