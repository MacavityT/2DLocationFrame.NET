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
            this.btn_LoadBitmap = new System.Windows.Forms.Button();
            this.buttonRemoveGraph = new System.Windows.Forms.Button();
            this.buttonAddRectangleRegion = new System.Windows.Forms.Button();
            this.buttonTraining = new System.Windows.Forms.Button();
            this.buttonAddCircle = new System.Windows.Forms.Button();
            this.buttonLocation = new System.Windows.Forms.Button();
            this.aqDisplayCreateModel = new AqVision.Controls.AqDisplay();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_LoadBitmap
            // 
            this.btn_LoadBitmap.Location = new System.Drawing.Point(43, 178);
            this.btn_LoadBitmap.Margin = new System.Windows.Forms.Padding(2);
            this.btn_LoadBitmap.Name = "btn_LoadBitmap";
            this.btn_LoadBitmap.Size = new System.Drawing.Size(92, 34);
            this.btn_LoadBitmap.TabIndex = 5;
            this.btn_LoadBitmap.Text = "加载图片";
            this.btn_LoadBitmap.UseVisualStyleBackColor = true;
            this.btn_LoadBitmap.Click += new System.EventHandler(this.btn_LoadBitmap_Click);
            // 
            // buttonRemoveGraph
            // 
            this.buttonRemoveGraph.Location = new System.Drawing.Point(43, 254);
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
            this.buttonAddRectangleRegion.Location = new System.Drawing.Point(43, 11);
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
            this.buttonTraining.Location = new System.Drawing.Point(43, 49);
            this.buttonTraining.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTraining.Name = "buttonTraining";
            this.buttonTraining.Size = new System.Drawing.Size(92, 34);
            this.buttonTraining.TabIndex = 8;
            this.buttonTraining.Text = "训练";
            this.buttonTraining.UseVisualStyleBackColor = true;
            this.buttonTraining.Click += new System.EventHandler(this.buttonTraining_Click);
            // 
            // buttonAddCircle
            // 
            this.buttonAddCircle.Location = new System.Drawing.Point(43, 216);
            this.buttonAddCircle.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddCircle.Name = "buttonAddCircle";
            this.buttonAddCircle.Size = new System.Drawing.Size(92, 34);
            this.buttonAddCircle.TabIndex = 9;
            this.buttonAddCircle.Text = "添加圆形";
            this.buttonAddCircle.UseVisualStyleBackColor = true;
            this.buttonAddCircle.Click += new System.EventHandler(this.buttonAddCircle_Click);
            // 
            // buttonLocation
            // 
            this.buttonLocation.Location = new System.Drawing.Point(43, 88);
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
            this.aqDisplayCreateModel.Size = new System.Drawing.Size(853, 658);
            this.aqDisplayCreateModel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.buttonAddRectangleRegion);
            this.panel1.Controls.Add(this.buttonLocation);
            this.panel1.Controls.Add(this.buttonAddCircle);
            this.panel1.Controls.Add(this.btn_LoadBitmap);
            this.panel1.Controls.Add(this.buttonTraining);
            this.panel1.Controls.Add(this.buttonRemoveGraph);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(853, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(177, 658);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.aqDisplayCreateModel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(853, 658);
            this.panel2.TabIndex = 13;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(33, 293);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 364);
            this.listBox1.TabIndex = 12;
            // 
            // TemplateSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 658);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "TemplateSetForm";
            this.Text = "TemplateSet";
            this.Load += new System.EventHandler(this.TemplateSet_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AqVision.Controls.AqDisplay aqDisplayCreateModel;
        private System.Windows.Forms.Button btn_LoadBitmap;
        private System.Windows.Forms.Button buttonRemoveGraph;
        private System.Windows.Forms.Button buttonAddRectangleRegion;
        private System.Windows.Forms.Button buttonTraining;
        private System.Windows.Forms.Button buttonAddCircle;
        private System.Windows.Forms.Button buttonLocation;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox listBox1;

    }
}