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
            this.SuspendLayout();
            // 
            // btn_LoadBitmap
            // 
            this.btn_LoadBitmap.Location = new System.Drawing.Point(681, 311);
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
            this.buttonRemoveGraph.Location = new System.Drawing.Point(681, 387);
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
            this.buttonAddRectangleRegion.Location = new System.Drawing.Point(681, 11);
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
            this.buttonTraining.Location = new System.Drawing.Point(681, 49);
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
            this.buttonAddCircle.Location = new System.Drawing.Point(681, 349);
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
            this.buttonLocation.Location = new System.Drawing.Point(681, 88);
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
            this.aqDisplayCreateModel.Image = null;
            this.aqDisplayCreateModel.Location = new System.Drawing.Point(11, 11);
            this.aqDisplayCreateModel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.aqDisplayCreateModel.Name = "aqDisplayCreateModel";
            this.aqDisplayCreateModel.ScrollBar = false;
            this.aqDisplayCreateModel.Size = new System.Drawing.Size(638, 452);
            this.aqDisplayCreateModel.TabIndex = 0;
            // 
            // TemplateSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 575);
            this.Controls.Add(this.buttonLocation);
            this.Controls.Add(this.btn_LoadBitmap);
            this.Controls.Add(this.buttonRemoveGraph);
            this.Controls.Add(this.buttonAddRectangleRegion);
            this.Controls.Add(this.buttonTraining);
            this.Controls.Add(this.buttonAddCircle);
            this.Controls.Add(this.aqDisplayCreateModel);
            this.Name = "TemplateSet";
            this.Text = "TemplateSet";
            this.Load += new System.EventHandler(this.TemplateSet_Load);
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

    }
}