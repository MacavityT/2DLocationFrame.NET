namespace IntegrationTesting
{
    partial class PositionSet
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
            this.labelDataTypeX = new System.Windows.Forms.Label();
            this.textBoxDataX = new System.Windows.Forms.TextBox();
            this.labelDataTypeY = new System.Windows.Forms.Label();
            this.textBoxDataY = new System.Windows.Forms.TextBox();
            this.labelDataTypeRz = new System.Windows.Forms.Label();
            this.textBoxDataRz = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelDataTypeX
            // 
            this.labelDataTypeX.AutoSize = true;
            this.labelDataTypeX.Location = new System.Drawing.Point(13, 24);
            this.labelDataTypeX.Name = "labelDataTypeX";
            this.labelDataTypeX.Size = new System.Drawing.Size(53, 12);
            this.labelDataTypeX.TabIndex = 0;
            this.labelDataTypeX.Text = "数据类型";
            // 
            // textBoxDataX
            // 
            this.textBoxDataX.Location = new System.Drawing.Point(92, 21);
            this.textBoxDataX.Name = "textBoxDataX";
            this.textBoxDataX.Size = new System.Drawing.Size(100, 21);
            this.textBoxDataX.TabIndex = 2;
            // 
            // labelDataTypeY
            // 
            this.labelDataTypeY.AutoSize = true;
            this.labelDataTypeY.Location = new System.Drawing.Point(13, 74);
            this.labelDataTypeY.Name = "labelDataTypeY";
            this.labelDataTypeY.Size = new System.Drawing.Size(53, 12);
            this.labelDataTypeY.TabIndex = 0;
            this.labelDataTypeY.Text = "数据类型";
            // 
            // textBoxDataY
            // 
            this.textBoxDataY.Location = new System.Drawing.Point(92, 71);
            this.textBoxDataY.Name = "textBoxDataY";
            this.textBoxDataY.Size = new System.Drawing.Size(100, 21);
            this.textBoxDataY.TabIndex = 2;
            // 
            // labelDataTypeRz
            // 
            this.labelDataTypeRz.AutoSize = true;
            this.labelDataTypeRz.Location = new System.Drawing.Point(13, 134);
            this.labelDataTypeRz.Name = "labelDataTypeRz";
            this.labelDataTypeRz.Size = new System.Drawing.Size(53, 12);
            this.labelDataTypeRz.TabIndex = 0;
            this.labelDataTypeRz.Text = "数据类型";
            // 
            // textBoxDataRz
            // 
            this.textBoxDataRz.Location = new System.Drawing.Point(92, 131);
            this.textBoxDataRz.Name = "textBoxDataRz";
            this.textBoxDataRz.Size = new System.Drawing.Size(100, 21);
            this.textBoxDataRz.TabIndex = 2;
            // 
            // PositionSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 186);
            this.Controls.Add(this.textBoxDataRz);
            this.Controls.Add(this.labelDataTypeRz);
            this.Controls.Add(this.textBoxDataY);
            this.Controls.Add(this.labelDataTypeY);
            this.Controls.Add(this.textBoxDataX);
            this.Controls.Add(this.labelDataTypeX);
            this.Name = "PositionSet";
            this.Text = "PositionSet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDataTypeX;
        private System.Windows.Forms.TextBox textBoxDataX;
        private System.Windows.Forms.Label labelDataTypeY;
        private System.Windows.Forms.TextBox textBoxDataY;
        private System.Windows.Forms.Label labelDataTypeRz;
        private System.Windows.Forms.TextBox textBoxDataRz;
    }
}