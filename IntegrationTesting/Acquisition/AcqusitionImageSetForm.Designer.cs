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
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 32);
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
            this.comboBoxCameraBrandLocation.Size = new System.Drawing.Size(157, 20);
            this.comboBoxCameraBrandLocation.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Camera Name";
            // 
            // textBoxCameraNameLocation
            // 
            this.textBoxCameraNameLocation.Location = new System.Drawing.Point(113, 69);
            this.textBoxCameraNameLocation.Name = "textBoxCameraNameLocation";
            this.textBoxCameraNameLocation.Size = new System.Drawing.Size(157, 21);
            this.textBoxCameraNameLocation.TabIndex = 2;
            this.textBoxCameraNameLocation.Text = "Aqrose_L";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Exposure Time";
            // 
            // textBoxExposureTimeLocation
            // 
            this.textBoxExposureTimeLocation.Location = new System.Drawing.Point(113, 112);
            this.textBoxExposureTimeLocation.Name = "textBoxExposureTimeLocation";
            this.textBoxExposureTimeLocation.Size = new System.Drawing.Size(157, 21);
            this.textBoxExposureTimeLocation.TabIndex = 3;
            this.textBoxExposureTimeLocation.Text = "50000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(277, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "ms";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(354, 199);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(196, 199);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(298, 146);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "定位相机";
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
            this.groupBox2.Location = new System.Drawing.Point(325, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(298, 146);
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
            this.comboBoxCameraBrandDetection.Size = new System.Drawing.Size(157, 20);
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
            this.label6.Location = new System.Drawing.Point(21, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "Camera Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(277, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "ms";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "Exposure Time";
            // 
            // textBoxExposureTimeDetection
            // 
            this.textBoxExposureTimeDetection.Location = new System.Drawing.Point(113, 112);
            this.textBoxExposureTimeDetection.Name = "textBoxExposureTimeDetection";
            this.textBoxExposureTimeDetection.Size = new System.Drawing.Size(157, 21);
            this.textBoxExposureTimeDetection.TabIndex = 3;
            this.textBoxExposureTimeDetection.Text = "50000";
            // 
            // textBoxCameraNameDetection
            // 
            this.textBoxCameraNameDetection.Location = new System.Drawing.Point(113, 69);
            this.textBoxCameraNameDetection.Name = "textBoxCameraNameDetection";
            this.textBoxCameraNameDetection.Size = new System.Drawing.Size(157, 21);
            this.textBoxCameraNameDetection.TabIndex = 2;
            this.textBoxCameraNameDetection.Text = "Aqrose_D";
            // 
            // AcqusitionImageSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 220);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Name = "AcqusitionImageSet";
            this.Text = "AcqusitionImageSet";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
    }
}