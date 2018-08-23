namespace IntegrationTesting.Aidi
{
    partial class AIDIManagementForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonRead = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxShowResultList = new System.Windows.Forms.ComboBox();
            this.aqDisplay1 = new AqVision.Controls.AqDisplay();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 512);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "label1";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(720, 1);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(152, 481);
            this.richTextBox2.TabIndex = 16;
            this.richTextBox2.Text = "";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(615, 1);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(99, 481);
            this.richTextBox1.TabIndex = 15;
            this.richTextBox1.Text = "";
            // 
            // buttonRead
            // 
            this.buttonRead.Location = new System.Drawing.Point(767, 512);
            this.buttonRead.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(92, 34);
            this.buttonRead.TabIndex = 19;
            this.buttonRead.Text = "AIDI读取";
            this.buttonRead.UseVisualStyleBackColor = true;
            this.buttonRead.Click += new System.EventHandler(this.buttonRead_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(671, 512);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 34);
            this.button1.TabIndex = 20;
            this.button1.Text = "AIDI初始化";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxShowResultList
            // 
            this.comboBoxShowResultList.FormattingEnabled = true;
            this.comboBoxShowResultList.Location = new System.Drawing.Point(86, 508);
            this.comboBoxShowResultList.Name = "comboBoxShowResultList";
            this.comboBoxShowResultList.Size = new System.Drawing.Size(121, 20);
            this.comboBoxShowResultList.TabIndex = 21;
            this.comboBoxShowResultList.SelectedIndexChanged += new System.EventHandler(this.comboBoxShowResultList_SelectedIndexChanged);
            // 
            // aqDisplay1
            // 
            this.aqDisplay1.AutoScroll = true;
            this.aqDisplay1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.aqDisplay1.Image = null;
            this.aqDisplay1.Location = new System.Drawing.Point(8, 8);
            this.aqDisplay1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.aqDisplay1.Name = "aqDisplay1";
            this.aqDisplay1.ScrollBar = false;
            this.aqDisplay1.Size = new System.Drawing.Size(602, 474);
            this.aqDisplay1.TabIndex = 22;
            // 
            // AIDIManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 554);
            this.Controls.Add(this.aqDisplay1);
            this.Controls.Add(this.comboBoxShowResultList);
            this.Controls.Add(this.buttonRead);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Name = "AIDIManagementForm";
            this.Text = "AIDIManagementForm";
            this.Load += new System.EventHandler(this.AIDIManagementForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonRead;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxShowResultList;
        private AqVision.Controls.AqDisplay aqDisplay1;
    }
}