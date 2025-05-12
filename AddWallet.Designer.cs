namespace CourseWork
{
    partial class AddWallet
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
            this.WalletName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.WallName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.WallBegSum = new System.Windows.Forms.TextBox();
            this.WallDescr = new System.Windows.Forms.TextBox();
            this.AddWall = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // WalletName
            // 
            this.WalletName.AutoSize = true;
            this.WalletName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WalletName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.WalletName.Location = new System.Drawing.Point(41, 30);
            this.WalletName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WalletName.Name = "WalletName";
            this.WalletName.Size = new System.Drawing.Size(103, 15);
            this.WalletName.TabIndex = 0;
            this.WalletName.Text = "Название счета:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.label2.Location = new System.Drawing.Point(41, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Описание счета:";
            // 
            // WallName
            // 
            this.WallName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.WallName.Location = new System.Drawing.Point(201, 27);
            this.WallName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.WallName.Name = "WallName";
            this.WallName.Size = new System.Drawing.Size(116, 21);
            this.WallName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.label1.Location = new System.Drawing.Point(41, 99);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Начальная сумма:";
            // 
            // WallBegSum
            // 
            this.WallBegSum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.WallBegSum.Location = new System.Drawing.Point(201, 96);
            this.WallBegSum.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.WallBegSum.Name = "WallBegSum";
            this.WallBegSum.Size = new System.Drawing.Size(116, 21);
            this.WallBegSum.TabIndex = 4;
            // 
            // WallDescr
            // 
            this.WallDescr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.WallDescr.Location = new System.Drawing.Point(201, 61);
            this.WallDescr.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.WallDescr.Name = "WallDescr";
            this.WallDescr.Size = new System.Drawing.Size(116, 21);
            this.WallDescr.TabIndex = 5;
            // 
            // AddWall
            // 
            this.AddWall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.AddWall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddWall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.AddWall.Location = new System.Drawing.Point(125, 158);
            this.AddWall.Name = "AddWall";
            this.AddWall.Size = new System.Drawing.Size(102, 23);
            this.AddWall.TabIndex = 6;
            this.AddWall.Text = "Добавить счет";
            this.AddWall.UseVisualStyleBackColor = false;
            this.AddWall.Click += new System.EventHandler(this.AddWall_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(363, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::CourseWork.Properties.Resources.usd;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "USD";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::CourseWork.Properties.Resources.euro;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.ToolTipText = "EUR";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::CourseWork.Properties.Resources.blr;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.ToolTipText = "BYN";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // AddWallet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(363, 204);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.AddWall);
            this.Controls.Add(this.WallDescr);
            this.Controls.Add(this.WallBegSum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WallName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.WalletName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "AddWallet";
            this.Text = "AddWallet";
            this.Load += new System.EventHandler(this.AddWallet_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WalletName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox WallName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox WallBegSum;
        private System.Windows.Forms.TextBox WallDescr;
        private System.Windows.Forms.Button AddWall;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
    }
}