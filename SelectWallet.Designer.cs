namespace CourseWork
{
    partial class SelectWallet
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
            this.tableLayoutPanelSelect = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewSelect = new System.Windows.Forms.DataGridView();
            this.selectLabel = new System.Windows.Forms.Label();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.tableLayoutPanelSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelSelect
            // 
            this.tableLayoutPanelSelect.ColumnCount = 1;
            this.tableLayoutPanelSelect.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSelect.Controls.Add(this.dataGridViewSelect, 0, 0);
            this.tableLayoutPanelSelect.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanelSelect.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelSelect.Name = "tableLayoutPanelSelect";
            this.tableLayoutPanelSelect.RowCount = 1;
            this.tableLayoutPanelSelect.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSelect.Size = new System.Drawing.Size(266, 204);
            this.tableLayoutPanelSelect.TabIndex = 2;
            // 
            // dataGridViewSelect
            // 
            this.dataGridViewSelect.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridViewSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSelect.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dataGridViewSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSelect.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewSelect.Name = "dataGridViewSelect";
            this.dataGridViewSelect.Size = new System.Drawing.Size(260, 198);
            this.dataGridViewSelect.TabIndex = 0;
            // 
            // selectLabel
            // 
            this.selectLabel.AutoSize = true;
            this.selectLabel.Location = new System.Drawing.Point(292, 187);
            this.selectLabel.Name = "selectLabel";
            this.selectLabel.Size = new System.Drawing.Size(51, 13);
            this.selectLabel.TabIndex = 4;
            this.selectLabel.Text = "Выбрать";
            // 
            // buttonSelect
            // 
            this.buttonSelect.BackgroundImage = global::CourseWork.Properties.Resources.selectinform;
            this.buttonSelect.Location = new System.Drawing.Point(291, 138);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(50, 50);
            this.buttonSelect.TabIndex = 3;
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // SelectWallet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 204);
            this.Controls.Add(this.selectLabel);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.tableLayoutPanelSelect);
            this.Name = "SelectWallet";
            this.Text = "SelectWallet";
            this.Load += new System.EventHandler(this.SelectWallet_Load);
            this.tableLayoutPanelSelect.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSelect;
        private System.Windows.Forms.DataGridView dataGridViewSelect;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Label selectLabel;
    }
}