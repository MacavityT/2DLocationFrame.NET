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
            this.buttonLoadPic = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonAddVerZone = new System.Windows.Forms.Button();
            this.buttonAddHorZone = new System.Windows.Forms.Button();
            this.buttonLoadModel = new System.Windows.Forms.Button();
            this.buttonSaveModel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonRemoveGraph
            // 
            this.buttonRemoveGraph.Location = new System.Drawing.Point(3, 531);
            this.buttonRemoveGraph.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRemoveGraph.Name = "buttonRemoveGraph";
            this.buttonRemoveGraph.Size = new System.Drawing.Size(126, 34);
            this.buttonRemoveGraph.TabIndex = 10;
            this.buttonRemoveGraph.Text = "移除所有图形";
            this.buttonRemoveGraph.UseVisualStyleBackColor = true;
            this.buttonRemoveGraph.Click += new System.EventHandler(this.buttonRemoveGraph_Click);
            // 
            // buttonAddRectangleRegion
            // 
            this.buttonAddRectangleRegion.ForeColor = System.Drawing.Color.Magenta;
            this.buttonAddRectangleRegion.Location = new System.Drawing.Point(2, 2);
            this.buttonAddRectangleRegion.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddRectangleRegion.Name = "buttonAddRectangleRegion";
            this.buttonAddRectangleRegion.Size = new System.Drawing.Size(126, 34);
            this.buttonAddRectangleRegion.TabIndex = 7;
            this.buttonAddRectangleRegion.Text = "添加匹配区域(洋红)";
            this.buttonAddRectangleRegion.UseVisualStyleBackColor = true;
            this.buttonAddRectangleRegion.Click += new System.EventHandler(this.buttonAddRectangleRegion_Click);
            // 
            // buttonTraining
            // 
            this.buttonTraining.Location = new System.Drawing.Point(1, 116);
            this.buttonTraining.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTraining.Name = "buttonTraining";
            this.buttonTraining.Size = new System.Drawing.Size(126, 34);
            this.buttonTraining.TabIndex = 8;
            this.buttonTraining.Text = "训练";
            this.buttonTraining.UseVisualStyleBackColor = true;
            this.buttonTraining.Click += new System.EventHandler(this.buttonTraining_Click);
            // 
            // buttonLocation
            // 
            this.buttonLocation.Location = new System.Drawing.Point(3, 193);
            this.buttonLocation.Name = "buttonLocation";
            this.buttonLocation.Size = new System.Drawing.Size(126, 34);
            this.buttonLocation.TabIndex = 11;
            this.buttonLocation.Text = "测试定位效果";
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
            this.aqDisplayCreateModel.Size = new System.Drawing.Size(1228, 725);
            this.aqDisplayCreateModel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonLoadPic);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.buttonAddVerZone);
            this.panel1.Controls.Add(this.buttonAddHorZone);
            this.panel1.Controls.Add(this.buttonAddRectangleRegion);
            this.panel1.Controls.Add(this.buttonLocation);
            this.panel1.Controls.Add(this.buttonLoadModel);
            this.panel1.Controls.Add(this.buttonSaveModel);
            this.panel1.Controls.Add(this.buttonTraining);
            this.panel1.Controls.Add(this.buttonRemoveGraph);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1228, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(130, 725);
            this.panel1.TabIndex = 12;
            // 
            // buttonLoadPic
            // 
            this.buttonLoadPic.Location = new System.Drawing.Point(3, 455);
            this.buttonLoadPic.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLoadPic.Name = "buttonLoadPic";
            this.buttonLoadPic.Size = new System.Drawing.Size(126, 34);
            this.buttonLoadPic.TabIndex = 14;
            this.buttonLoadPic.Text = "加载图片";
            this.buttonLoadPic.UseVisualStyleBackColor = true;
            this.buttonLoadPic.Click += new System.EventHandler(this.buttonLoadPic_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(3, 418);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(126, 21);
            this.textBox3.TabIndex = 13;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(3, 391);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(126, 21);
            this.textBox2.TabIndex = 13;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 364);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(126, 21);
            this.textBox1.TabIndex = 13;
            // 
            // buttonAddVerZone
            // 
            this.buttonAddVerZone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonAddVerZone.Location = new System.Drawing.Point(2, 78);
            this.buttonAddVerZone.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddVerZone.Name = "buttonAddVerZone";
            this.buttonAddVerZone.Size = new System.Drawing.Size(126, 34);
            this.buttonAddVerZone.TabIndex = 7;
            this.buttonAddVerZone.Text = "添加竖线区域(绿色)";
            this.buttonAddVerZone.UseVisualStyleBackColor = true;
            this.buttonAddVerZone.Click += new System.EventHandler(this.buttonAddVerZone_Click);
            // 
            // buttonAddHorZone
            // 
            this.buttonAddHorZone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonAddHorZone.Location = new System.Drawing.Point(1, 40);
            this.buttonAddHorZone.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddHorZone.Name = "buttonAddHorZone";
            this.buttonAddHorZone.Size = new System.Drawing.Size(127, 34);
            this.buttonAddHorZone.TabIndex = 7;
            this.buttonAddHorZone.Text = "添加横线区域(橙色)";
            this.buttonAddHorZone.UseVisualStyleBackColor = true;
            this.buttonAddHorZone.Click += new System.EventHandler(this.buttonAddHorZone_Click);
            // 
            // buttonLoadModel
            // 
            this.buttonLoadModel.Location = new System.Drawing.Point(3, 493);
            this.buttonLoadModel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLoadModel.Name = "buttonLoadModel";
            this.buttonLoadModel.Size = new System.Drawing.Size(126, 34);
            this.buttonLoadModel.TabIndex = 5;
            this.buttonLoadModel.Text = "加载模板";
            this.buttonLoadModel.UseVisualStyleBackColor = true;
            this.buttonLoadModel.Click += new System.EventHandler(this.buttonLoadModel_Click);
            // 
            // buttonSaveModel
            // 
            this.buttonSaveModel.Location = new System.Drawing.Point(2, 154);
            this.buttonSaveModel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSaveModel.Name = "buttonSaveModel";
            this.buttonSaveModel.Size = new System.Drawing.Size(126, 34);
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
            this.panel2.Size = new System.Drawing.Size(1228, 725);
            this.panel2.TabIndex = 13;
            // 
            // TemplateSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 725);
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
        private System.Windows.Forms.Button buttonSaveModel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button buttonLoadModel;
        private System.Windows.Forms.Button buttonLoadPic;
        private System.Windows.Forms.Button buttonAddHorZone;
        private System.Windows.Forms.Button buttonAddVerZone;

    }
}