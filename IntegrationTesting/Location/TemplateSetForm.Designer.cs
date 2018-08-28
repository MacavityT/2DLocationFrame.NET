namespace IntegrationTesting
{
    partial class TemplateSetForm
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
            this.buttonRemoveGraph = new System.Windows.Forms.Button();
            this.buttonAddRectangleRegion = new System.Windows.Forms.Button();
            this.buttonTraining = new System.Windows.Forms.Button();
            this.buttonLocation = new System.Windows.Forms.Button();
            this.aqDisplayCreateModel = new AqVision.Controls.AqDisplay();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonSaveModel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonRemoveGraph
            // 
            this.buttonRemoveGraph.Location = new System.Drawing.Point(7, 334);
            this.buttonRemoveGraph.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRemoveGraph.Name = "buttonRemoveGraph";
            this.buttonRemoveGraph.Size = new System.Drawing.Size(92, 34);
            this.buttonRemoveGraph.TabIndex = 10;
            this.buttonRemoveGraph.Text = "移除所有图形";
            this.buttonRemoveGraph.UseVisualStyleBackColor = true;
            this.buttonRemoveGraph.Click += new System.EventHandler(this.buttonRemoveGraph_Click);
            // 
            // buttonAddRectangleRegion
            // 
            this.buttonAddRectangleRegion.Location = new System.Drawing.Point(5, 18);
            this.buttonAddRectangleRegion.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddRectangleRegion.Name = "buttonAddRectangleRegion";
            this.buttonAddRectangleRegion.Size = new System.Drawing.Size(92, 34);
            this.buttonAddRectangleRegion.TabIndex = 7;
            this.buttonAddRectangleRegion.Text = "添加示教区";
            this.buttonAddRectangleRegion.UseVisualStyleBackColor = true;
            this.buttonAddRectangleRegion.Click += new System.EventHandler(this.buttonAddRectangleRegion_Click);
            // 
            // buttonTraining
            // 
            this.buttonTraining.Location = new System.Drawing.Point(5, 56);
            this.buttonTraining.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTraining.Name = "buttonTraining";
            this.buttonTraining.Size = new System.Drawing.Size(92, 34);
            this.buttonTraining.TabIndex = 8;
            this.buttonTraining.Text = "训练";
            this.buttonTraining.UseVisualStyleBackColor = true;
            this.buttonTraining.Click += new System.EventHandler(this.buttonTraining_Click);
            // 
            // buttonLocation
            // 
            this.buttonLocation.Location = new System.Drawing.Point(5, 95);
            this.buttonLocation.Name = "buttonLocation";
            this.buttonLocation.Size = new System.Drawing.Size(92, 34);
            this.buttonLocation.TabIndex = 11;
            this.buttonLocation.Text = "定位";
            this.buttonLocation.UseVisualStyleBackColor = true;
            this.buttonLocation.Click += new System.EventHandler(this.buttonLocation_Click);
            // 
            // aqDisplayCreateModel
            // 
            this.aqDisplayCreateModel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.aqDisplayCreateModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aqDisplayCreateModel.Image = null;
            this.aqDisplayCreateModel.Location = new System.Drawing.Point(0, 0);
            this.aqDisplayCreateModel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.aqDisplayCreateModel.Name = "aqDisplayCreateModel";
            this.aqDisplayCreateModel.ScrollBar = false;
            this.aqDisplayCreateModel.Size = new System.Drawing.Size(833, 725);
            this.aqDisplayCreateModel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.buttonAddRectangleRegion);
            this.panel1.Controls.Add(this.buttonLocation);
            this.panel1.Controls.Add(this.buttonSaveModel);
            this.panel1.Controls.Add(this.buttonTraining);
            this.panel1.Controls.Add(this.buttonRemoveGraph);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(833, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 725);
            this.panel1.TabIndex = 12;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(-1, 259);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 21);
            this.textBox3.TabIndex = 13;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(3, 223);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 13;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 188);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 13;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(9, 373);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(209, 340);
            this.listBox1.TabIndex = 12;
            // 
            // buttonSaveModel
            // 
            this.buttonSaveModel.Location = new System.Drawing.Point(5, 134);
            this.buttonSaveModel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSaveModel.Name = "buttonSaveModel";
            this.buttonSaveModel.Size = new System.Drawing.Size(92, 34);
            this.buttonSaveModel.TabIndex = 5;
            this.buttonSaveModel.Text = "保存模板";
            this.buttonSaveModel.UseVisualStyleBackColor = true;
            this.buttonSaveModel.Click += new System.EventHandler(this.buttonSaveModel_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.aqDisplayCreateModel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(833, 725);
            this.panel2.TabIndex = 13;
            // 
            // TemplateSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 725);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "TemplateSetForm";
            this.Text = "定位参数设置";
            this.Load += new System.EventHandler(this.TemplateSet_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AqVision.Controls.AqDisplay aqDisplayCreateModel;
        private System.Windows.Forms.Button buttonRemoveGraph;
        private System.Windows.Forms.Button buttonAddRectangleRegion;
        private System.Windows.Forms.Button buttonTraining;
        private System.Windows.Forms.Button buttonLocation;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button buttonSaveModel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;

    }
}