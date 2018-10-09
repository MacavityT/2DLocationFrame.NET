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
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxExposureTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.panelLocalFolder = new System.Windows.Forms.Panel();
            this.textBoxFolder = new System.Windows.Forms.TextBox();
            this.buttonSelectFolder = new System.Windows.Forms.Button();
            this.panelCamerapanelLocalFile = new System.Windows.Forms.Panel();
            this.textBoxFile = new System.Windows.Forms.TextBox();
            this.buttonLocationDirectory = new System.Windows.Forms.Button();
            this.panelCamera = new System.Windows.Forms.Panel();
            this.comboBoxCameraName = new System.Windows.Forms.ComboBox();
            this.radioButtonCamera = new System.Windows.Forms.RadioButton();
            this.radioButtonLocalFolder = new System.Windows.Forms.RadioButton();
            this.radioButtonLocalFile = new System.Windows.Forms.RadioButton();
            this.groupBox.SuspendLayout();
            this.panelLocalFolder.SuspendLayout();
            this.panelCamerapanelLocalFile.SuspendLayout();
            this.panelCamera.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "相机品牌";
            // 
            // comboBoxCameraBrand
            // 
            this.comboBoxCameraBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCameraBrand.FormattingEnabled = true;
            this.comboBoxCameraBrand.Items.AddRange(new object[] {
            "DaHeng",
            "Balser"});
            this.comboBoxCameraBrand.Location = new System.Drawing.Point(230, 18);
            this.comboBoxCameraBrand.Name = "comboBoxCameraBrand";
            this.comboBoxCameraBrand.Size = new System.Drawing.Size(74, 20);
            this.comboBoxCameraBrand.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Camera Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(310, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Exposure Time";
            // 
            // textBoxExposureTime
            // 
            this.textBoxExposureTime.Location = new System.Drawing.Point(394, 19);
            this.textBoxExposureTime.Name = "textBoxExposureTime";
            this.textBoxExposureTime.Size = new System.Drawing.Size(74, 21);
            this.textBoxExposureTime.TabIndex = 3;
            this.textBoxExposureTime.Text = "5000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(473, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "ms";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(322, 273);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(132, 273);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.panelLocalFolder);
            this.groupBox.Controls.Add(this.panelCamerapanelLocalFile);
            this.groupBox.Controls.Add(this.panelCamera);
            this.groupBox.Controls.Add(this.radioButtonCamera);
            this.groupBox.Controls.Add(this.radioButtonLocalFolder);
            this.groupBox.Controls.Add(this.radioButtonLocalFile);
            this.groupBox.Location = new System.Drawing.Point(12, 2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(521, 265);
            this.groupBox.TabIndex = 7;
            this.groupBox.TabStop = false;
            // 
            // panelLocalFolder
            // 
            this.panelLocalFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLocalFolder.Controls.Add(this.textBoxFolder);
            this.panelLocalFolder.Controls.Add(this.buttonSelectFolder);
            this.panelLocalFolder.Location = new System.Drawing.Point(13, 202);
            this.panelLocalFolder.Name = "panelLocalFolder";
            this.panelLocalFolder.Size = new System.Drawing.Size(502, 47);
            this.panelLocalFolder.TabIndex = 8;
            // 
            // textBoxFolder
            // 
            this.textBoxFolder.Location = new System.Drawing.Point(2, 16);
            this.textBoxFolder.Name = "textBoxFolder";
            this.textBoxFolder.ReadOnly = true;
            this.textBoxFolder.Size = new System.Drawing.Size(408, 21);
            this.textBoxFolder.TabIndex = 9;
            // 
            // buttonSelectFolder
            // 
            this.buttonSelectFolder.Location = new System.Drawing.Point(415, 13);
            this.buttonSelectFolder.Name = "buttonSelectFolder";
            this.buttonSelectFolder.Size = new System.Drawing.Size(77, 24);
            this.buttonSelectFolder.TabIndex = 10;
            this.buttonSelectFolder.Text = "选择";
            this.buttonSelectFolder.UseVisualStyleBackColor = true;
            this.buttonSelectFolder.Click += new System.EventHandler(this.buttonSelectFolder_Click);
            // 
            // panelCamerapanelLocalFile
            // 
            this.panelCamerapanelLocalFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCamerapanelLocalFile.Controls.Add(this.textBoxFile);
            this.panelCamerapanelLocalFile.Controls.Add(this.buttonLocationDirectory);
            this.panelCamerapanelLocalFile.Location = new System.Drawing.Point(13, 117);
            this.panelCamerapanelLocalFile.Name = "panelCamerapanelLocalFile";
            this.panelCamerapanelLocalFile.Size = new System.Drawing.Size(502, 57);
            this.panelCamerapanelLocalFile.TabIndex = 8;
            // 
            // textBoxFile
            // 
            this.textBoxFile.Location = new System.Drawing.Point(2, 18);
            this.textBoxFile.Name = "textBoxFile";
            this.textBoxFile.ReadOnly = true;
            this.textBoxFile.Size = new System.Drawing.Size(410, 21);
            this.textBoxFile.TabIndex = 9;
            // 
            // buttonLocationDirectory
            // 
            this.buttonLocationDirectory.Location = new System.Drawing.Point(417, 17);
            this.buttonLocationDirectory.Name = "buttonLocationDirectory";
            this.buttonLocationDirectory.Size = new System.Drawing.Size(79, 24);
            this.buttonLocationDirectory.TabIndex = 10;
            this.buttonLocationDirectory.Text = "选择";
            this.buttonLocationDirectory.UseVisualStyleBackColor = true;
            this.buttonLocationDirectory.Click += new System.EventHandler(this.buttonDirectory_Click);
            // 
            // panelCamera
            // 
            this.panelCamera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCamera.Controls.Add(this.comboBoxCameraName);
            this.panelCamera.Controls.Add(this.comboBoxCameraBrand);
            this.panelCamera.Controls.Add(this.label1);
            this.panelCamera.Controls.Add(this.label2);
            this.panelCamera.Controls.Add(this.label4);
            this.panelCamera.Controls.Add(this.label3);
            this.panelCamera.Controls.Add(this.textBoxExposureTime);
            this.panelCamera.Location = new System.Drawing.Point(13, 40);
            this.panelCamera.Name = "panelCamera";
            this.panelCamera.Size = new System.Drawing.Size(501, 51);
            this.panelCamera.TabIndex = 8;
            // 
            // comboBoxCameraName
            // 
            this.comboBoxCameraName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCameraName.FormattingEnabled = true;
            this.comboBoxCameraName.Items.AddRange(new object[] {
            "DaHeng",
            "Balser"});
            this.comboBoxCameraName.Location = new System.Drawing.Point(81, 17);
            this.comboBoxCameraName.Name = "comboBoxCameraName";
            this.comboBoxCameraName.Size = new System.Drawing.Size(74, 20);
            this.comboBoxCameraName.TabIndex = 1;
            this.comboBoxCameraName.SelectedIndexChanged += new System.EventHandler(this.comboBoxCameraName_SelectedIndexChanged);
            // 
            // radioButtonCamera
            // 
            this.radioButtonCamera.AutoSize = true;
            this.radioButtonCamera.Checked = true;
            this.radioButtonCamera.Location = new System.Drawing.Point(13, 20);
            this.radioButtonCamera.Name = "radioButtonCamera";
            this.radioButtonCamera.Size = new System.Drawing.Size(47, 16);
            this.radioButtonCamera.TabIndex = 8;
            this.radioButtonCamera.TabStop = true;
            this.radioButtonCamera.Text = "相机";
            this.radioButtonCamera.UseVisualStyleBackColor = true;
            this.radioButtonCamera.CheckedChanged += new System.EventHandler(this.radioButtonCamera_CheckedChanged);
            // 
            // radioButtonLocalFolder
            // 
            this.radioButtonLocalFolder.AutoSize = true;
            this.radioButtonLocalFolder.Location = new System.Drawing.Point(13, 180);
            this.radioButtonLocalFolder.Name = "radioButtonLocalFolder";
            this.radioButtonLocalFolder.Size = new System.Drawing.Size(59, 16);
            this.radioButtonLocalFolder.TabIndex = 8;
            this.radioButtonLocalFolder.Text = "文件夹";
            this.radioButtonLocalFolder.UseVisualStyleBackColor = true;
            this.radioButtonLocalFolder.CheckedChanged += new System.EventHandler(this.radioButtonLocalFolder_CheckedChanged);
            // 
            // radioButtonLocalFile
            // 
            this.radioButtonLocalFile.AutoSize = true;
            this.radioButtonLocalFile.Location = new System.Drawing.Point(13, 97);
            this.radioButtonLocalFile.Name = "radioButtonLocalFile";
            this.radioButtonLocalFile.Size = new System.Drawing.Size(47, 16);
            this.radioButtonLocalFile.TabIndex = 8;
            this.radioButtonLocalFile.Text = "文件";
            this.radioButtonLocalFile.UseVisualStyleBackColor = true;
            this.radioButtonLocalFile.CheckedChanged += new System.EventHandler(this.radioButtonLocalFile_CheckedChanged);
            // 
            // AcqusitionImageSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 300);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Name = "AcqusitionImageSet";
            this.Text = "取像参数设置";
            this.Load += new System.EventHandler(this.AcqusitionImageSet_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.panelLocalFolder.ResumeLayout(false);
            this.panelLocalFolder.PerformLayout();
            this.panelCamerapanelLocalFile.ResumeLayout(false);
            this.panelCamerapanelLocalFile.PerformLayout();
            this.panelCamera.ResumeLayout(false);
            this.panelCamera.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxCameraBrand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxExposureTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.RadioButton radioButtonLocalFile;
        private System.Windows.Forms.RadioButton radioButtonCamera;
        private System.Windows.Forms.Button buttonLocationDirectory;
        private System.Windows.Forms.TextBox textBoxFile;
        private System.Windows.Forms.Panel panelCamerapanelLocalFile;
        private System.Windows.Forms.Panel panelCamera;
        private System.Windows.Forms.Panel panelLocalFolder;
        private System.Windows.Forms.TextBox textBoxFolder;
        private System.Windows.Forms.Button buttonSelectFolder;
        private System.Windows.Forms.RadioButton radioButtonLocalFolder;
        private System.Windows.Forms.ComboBox comboBoxCameraName;
    }
}