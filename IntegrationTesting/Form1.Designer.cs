namespace IntegrationTesting
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_LoadBitmap = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonAddLine = new System.Windows.Forms.Button();
            this.buttonAddCircle = new System.Windows.Forms.Button();
            this.buttonAddRectangle = new System.Windows.Forms.Button();
            this.buttonAcquisition = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // aqDisplay1
            // 
            this.aqDisplay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aqDisplay1.Image = null;
            this.aqDisplay1.Location = new System.Drawing.Point(0, 0);
            this.aqDisplay1.Margin = new System.Windows.Forms.Padding(2);
            this.aqDisplay1.Name = "aqDisplay1";
            this.aqDisplay1.Size = new System.Drawing.Size(745, 533);
            this.aqDisplay1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonAcquisition);
            this.groupBox1.Controls.Add(this.btn_LoadBitmap);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.buttonAddLine);
            this.groupBox1.Controls.Add(this.buttonAddCircle);
            this.groupBox1.Controls.Add(this.buttonAddRectangle);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 476);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(745, 57);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // btn_LoadBitmap
            // 
            this.btn_LoadBitmap.Location = new System.Drawing.Point(3, 14);
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
            this.button3.Location = new System.Drawing.Point(439, 14);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 34);
            this.button3.TabIndex = 4;
            this.button3.Text = "移除所有图形";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonAddLine
            // 
            this.buttonAddLine.Location = new System.Drawing.Point(112, 14);
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
            this.buttonAddCircle.Location = new System.Drawing.Point(330, 14);
            this.buttonAddCircle.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddCircle.Name = "buttonAddCircle";
            this.buttonAddCircle.Size = new System.Drawing.Size(92, 34);
            this.buttonAddCircle.TabIndex = 3;
            this.buttonAddCircle.Text = "添加圆形";
            this.buttonAddCircle.UseVisualStyleBackColor = true;
            this.buttonAddCircle.Click += new System.EventHandler(this.buttonAddCircle_Click);
            // 
            // buttonAddRectangle
            // 
            this.buttonAddRectangle.Location = new System.Drawing.Point(221, 14);
            this.buttonAddRectangle.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddRectangle.Name = "buttonAddRectangle";
            this.buttonAddRectangle.Size = new System.Drawing.Size(92, 34);
            this.buttonAddRectangle.TabIndex = 3;
            this.buttonAddRectangle.Text = "添加矩形框";
            this.buttonAddRectangle.UseVisualStyleBackColor = true;
            this.buttonAddRectangle.Click += new System.EventHandler(this.buttonAddRectangle_Click);
            // 
            // buttonAcquisition
            // 
            this.buttonAcquisition.Location = new System.Drawing.Point(566, 19);
            this.buttonAcquisition.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAcquisition.Name = "buttonAcquisition";
            this.buttonAcquisition.Size = new System.Drawing.Size(69, 34);
            this.buttonAcquisition.TabIndex = 1;
            this.buttonAcquisition.Text = "实时取像";
            this.buttonAcquisition.UseVisualStyleBackColor = true;
            this.buttonAcquisition.Click += new System.EventHandler(this.buttonAcquisition_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 533);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.aqDisplay1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AqVision.Controls.AqDisplay aqDisplay1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_LoadBitmap;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonAddLine;
        private System.Windows.Forms.Button buttonAddCircle;
        private System.Windows.Forms.Button buttonAddRectangle;
        private System.Windows.Forms.Button buttonAcquisition;
    }
}

