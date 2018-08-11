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
            this.comboBoxCameraBrand = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCameraName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxExposureTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Camera Brand";
            // 
            // comboBoxCameraBrand
            // 
            this.comboBoxCameraBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCameraBrand.FormattingEnabled = true;
            this.comboBoxCameraBrand.Items.AddRange(new object[] {
            "DaHeng",
            "Balser"});
            this.comboBoxCameraBrand.Location = new System.Drawing.Point(105, 22);
            this.comboBoxCameraBrand.Name = "comboBoxCameraBrand";
            this.comboBoxCameraBrand.Size = new System.Drawing.Size(157, 20);
            this.comboBoxCameraBrand.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Camera Name";
            // 
            // textBoxCameraName
            // 
            this.textBoxCameraName.Location = new System.Drawing.Point(105, 62);
            this.textBoxCameraName.Name = "textBoxCameraName";
            this.textBoxCameraName.Size = new System.Drawing.Size(157, 21);
            this.textBoxCameraName.TabIndex = 2;
            this.textBoxCameraName.Text = "Aqrose_T";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Exposure Time";
            // 
            // textBoxExposureTime
            // 
            this.textBoxExposureTime.Location = new System.Drawing.Point(105, 105);
            this.textBoxExposureTime.Name = "textBoxExposureTime";
            this.textBoxExposureTime.Size = new System.Drawing.Size(157, 21);
            this.textBoxExposureTime.TabIndex = 3;
            this.textBoxExposureTime.Text = "50000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(269, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "ms";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(187, 153);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(37, 153);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // AcqusitionImageSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 191);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxExposureTime);
            this.Controls.Add(this.textBoxCameraName);
            this.Controls.Add(this.comboBoxCameraBrand);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AcqusitionImageSet";
            this.Text = "AcqusitionImageSet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxCameraBrand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCameraName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxExposureTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}