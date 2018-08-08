namespace IntegrationTesting
{
    partial class TemplateSet
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
            this.SuspendLayout();
            // 
            // aqDisplay1
            // 
            this.aqDisplay1.Image = null;
            this.aqDisplay1.Location = new System.Drawing.Point(11, 11);
            this.aqDisplay1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.aqDisplay1.Name = "aqDisplay1";
            this.aqDisplay1.ScrollBar = true;
            this.aqDisplay1.Size = new System.Drawing.Size(467, 427);
            this.aqDisplay1.TabIndex = 0;
            // 
            // TemplateSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 498);
            this.Controls.Add(this.aqDisplay1);
            this.Name = "TemplateSet";
            this.Text = "TemplateSet";
            this.ResumeLayout(false);

        }

        #endregion

        private AqVision.Controls.AqDisplay aqDisplay1;

    }
}