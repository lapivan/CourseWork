namespace CourseWork
{
    partial class SpendMoney
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
            this.textDescr = new System.Windows.Forms.TextBox();
            this.textSum = new System.Windows.Forms.TextBox();
            this.labelDescrip = new System.Windows.Forms.Label();
            this.labelsum = new System.Windows.Forms.Label();
            this.labelconst = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCurrency = new System.Windows.Forms.Label();
            this.buttonspend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textDescr
            // 
            this.textDescr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.textDescr.Location = new System.Drawing.Point(170, 37);
            this.textDescr.Name = "textDescr";
            this.textDescr.Size = new System.Drawing.Size(100, 20);
            this.textDescr.TabIndex = 0;
            // 
            // textSum
            // 
            this.textSum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.textSum.Location = new System.Drawing.Point(170, 87);
            this.textSum.Name = "textSum";
            this.textSum.Size = new System.Drawing.Size(100, 20);
            this.textSum.TabIndex = 1;
            // 
            // labelDescrip
            // 
            this.labelDescrip.AutoSize = true;
            this.labelDescrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.labelDescrip.Location = new System.Drawing.Point(63, 42);
            this.labelDescrip.Name = "labelDescrip";
            this.labelDescrip.Size = new System.Drawing.Size(60, 13);
            this.labelDescrip.TabIndex = 2;
            this.labelDescrip.Text = "Описание:";
            // 
            // labelsum
            // 
            this.labelsum.AutoSize = true;
            this.labelsum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.labelsum.Location = new System.Drawing.Point(79, 92);
            this.labelsum.Name = "labelsum";
            this.labelsum.Size = new System.Drawing.Size(44, 13);
            this.labelsum.TabIndex = 3;
            this.labelsum.Text = "Сумма:";
            // 
            // labelconst
            // 
            this.labelconst.AutoSize = true;
            this.labelconst.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.labelconst.Location = new System.Drawing.Point(217, 182);
            this.labelconst.Name = "labelconst";
            this.labelconst.Size = new System.Drawing.Size(60, 13);
            this.labelconst.TabIndex = 5;
            this.labelconst.Text = "Потратить";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.label1.Location = new System.Drawing.Point(222, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Валюта:";
            // 
            // labelCurrency
            // 
            this.labelCurrency.AutoSize = true;
            this.labelCurrency.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.labelCurrency.Location = new System.Drawing.Point(276, 9);
            this.labelCurrency.Name = "labelCurrency";
            this.labelCurrency.Size = new System.Drawing.Size(0, 13);
            this.labelCurrency.TabIndex = 7;
            // 
            // buttonspend
            // 
            this.buttonspend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.buttonspend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonspend.Image = global::CourseWork.Properties.Resources.spend;
            this.buttonspend.Location = new System.Drawing.Point(220, 125);
            this.buttonspend.Name = "buttonspend";
            this.buttonspend.Size = new System.Drawing.Size(50, 50);
            this.buttonspend.TabIndex = 4;
            this.buttonspend.UseVisualStyleBackColor = false;
            this.buttonspend.Click += new System.EventHandler(this.buttonspend_Click);
            // 
            // SpendMoney
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(317, 204);
            this.Controls.Add(this.labelCurrency);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelconst);
            this.Controls.Add(this.buttonspend);
            this.Controls.Add(this.labelsum);
            this.Controls.Add(this.labelDescrip);
            this.Controls.Add(this.textSum);
            this.Controls.Add(this.textDescr);
            this.Name = "SpendMoney";
            this.Text = "SpendMoney";
            this.Load += new System.EventHandler(this.SpendMoney_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textDescr;
        private System.Windows.Forms.TextBox textSum;
        private System.Windows.Forms.Label labelDescrip;
        private System.Windows.Forms.Label labelsum;
        private System.Windows.Forms.Button buttonspend;
        private System.Windows.Forms.Label labelconst;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCurrency;
    }
}