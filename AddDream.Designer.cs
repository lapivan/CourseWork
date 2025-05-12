namespace CourseWork
{
    partial class AddDream
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
            this.WallName = new System.Windows.Forms.TextBox();
            this.WallDescr = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelDescr = new System.Windows.Forms.Label();
            this.labelValue = new System.Windows.Forms.Label();
            this.WallBegSum = new System.Windows.Forms.TextBox();
            this.labelAdd = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonUSD = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEUR = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBYN = new System.Windows.Forms.ToolStripButton();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // WallName
            // 
            this.WallName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.WallName.Location = new System.Drawing.Point(162, 26);
            this.WallName.Name = "WallName";
            this.WallName.Size = new System.Drawing.Size(100, 20);
            this.WallName.TabIndex = 2;
            // 
            // WallDescr
            // 
            this.WallDescr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.WallDescr.Location = new System.Drawing.Point(162, 62);
            this.WallDescr.Name = "WallDescr";
            this.WallDescr.Size = new System.Drawing.Size(100, 20);
            this.WallDescr.TabIndex = 3;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.labelName.Location = new System.Drawing.Point(89, 29);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(32, 13);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Имя:";
            // 
            // labelDescr
            // 
            this.labelDescr.AutoSize = true;
            this.labelDescr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.labelDescr.Location = new System.Drawing.Point(61, 65);
            this.labelDescr.Name = "labelDescr";
            this.labelDescr.Size = new System.Drawing.Size(60, 13);
            this.labelDescr.TabIndex = 5;
            this.labelDescr.Text = "Описание:";
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.labelValue.Location = new System.Drawing.Point(63, 101);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(58, 13);
            this.labelValue.TabIndex = 6;
            this.labelValue.Text = "Значение:";
            // 
            // WallBegSum
            // 
            this.WallBegSum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.WallBegSum.Location = new System.Drawing.Point(162, 101);
            this.WallBegSum.Name = "WallBegSum";
            this.WallBegSum.Size = new System.Drawing.Size(100, 20);
            this.WallBegSum.TabIndex = 7;
            // 
            // labelAdd
            // 
            this.labelAdd.AutoSize = true;
            this.labelAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.labelAdd.Location = new System.Drawing.Point(206, 184);
            this.labelAdd.Name = "labelAdd";
            this.labelAdd.Size = new System.Drawing.Size(57, 13);
            this.labelAdd.TabIndex = 9;
            this.labelAdd.Text = "Добавить";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonUSD,
            this.toolStripButtonEUR,
            this.toolStripButtonBYN});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(284, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonUSD
            // 
            this.toolStripButtonUSD.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUSD.Image = global::CourseWork.Properties.Resources.usd2;
            this.toolStripButtonUSD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUSD.Name = "toolStripButtonUSD";
            this.toolStripButtonUSD.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonUSD.Text = "toolStripButton1";
            this.toolStripButtonUSD.Click += new System.EventHandler(this.toolStripButtonUSD_Click);
            // 
            // toolStripButtonEUR
            // 
            this.toolStripButtonEUR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEUR.Image = global::CourseWork.Properties.Resources.euro2;
            this.toolStripButtonEUR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEUR.Name = "toolStripButtonEUR";
            this.toolStripButtonEUR.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonEUR.Text = "toolStripButton2";
            this.toolStripButtonEUR.Click += new System.EventHandler(this.toolStripButtonEUR_Click);
            // 
            // toolStripButtonBYN
            // 
            this.toolStripButtonBYN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBYN.Image = global::CourseWork.Properties.Resources.blr2;
            this.toolStripButtonBYN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBYN.Name = "toolStripButtonBYN";
            this.toolStripButtonBYN.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonBYN.Text = "toolStripButton3";
            this.toolStripButtonBYN.Click += new System.EventHandler(this.toolStripButtonBYN_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.buttonAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.buttonAdd.Image = global::CourseWork.Properties.Resources.add_501;
            this.buttonAdd.Location = new System.Drawing.Point(208, 127);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(54, 54);
            this.buttonAdd.TabIndex = 8;
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // AddDream
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(284, 204);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.labelAdd);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.WallBegSum);
            this.Controls.Add(this.labelValue);
            this.Controls.Add(this.labelDescr);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.WallDescr);
            this.Controls.Add(this.WallName);
            this.Name = "AddDream";
            this.Text = "AddDream";
            this.Load += new System.EventHandler(this.AddDream_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox WallName;
        private System.Windows.Forms.TextBox WallDescr;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelDescr;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.TextBox WallBegSum;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label labelAdd;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonUSD;
        private System.Windows.Forms.ToolStripButton toolStripButtonEUR;
        private System.Windows.Forms.ToolStripButton toolStripButtonBYN;
    }
}