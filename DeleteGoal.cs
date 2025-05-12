using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class DeleteGoal : Form
    {
        private SqlConnection connectCourseDB = null;
        public DeleteGoal()
        {
            InitializeComponent();
        }
        ~DeleteGoal()
        {
            connectCourseDB.Close();
        }
        private void setTable()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT Name FROM Dreams WHERE VALUE > 0", connectCourseDB);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            DataTable dt = ds.Tables[0];
            dt.Columns.Add("Select", typeof(bool));

            dataGridView1.DataSource = dt;

            dataGridView1.Columns["Name"].HeaderText = "Название";
            dataGridView1.Columns["Select"].HeaderText = "Выбрать";

            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Выбрать";
            checkBoxColumn.Name = "Select";
            checkBoxColumn.TrueValue = true;
            checkBoxColumn.FalseValue = false;

            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToOrderColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0x2E, 0x5B, 0xFF);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dataGridView1.DefaultCellStyle.ForeColor = Color.FromArgb(0x2D, 0x37, 0x48);
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.FromArgb(0x2D, 0x37, 0x48);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0xE6, 0xF0, 0xFF);
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(0xF5, 0xF9, 0xFF);
            dataGridView1.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(0x2D, 0x37, 0x48);
            dataGridView1.GridColor = Color.FromArgb(0xE2, 0xE8, 0xF0);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridView1.Columns["Name"].ReadOnly = true;
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Select"].Value != null &&
                (row.Cells["Select"].Value is bool isSelected && isSelected))
                {
                    string walletName = row.Cells["Name"].Value.ToString();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Dreams WHERE Name = @Name", connectCourseDB))
                    {
                        cmd.Parameters.AddWithValue("@Name", walletName);
                        cmd.ExecuteNonQuery();
                        if (walletName == Form1.CurrentWalletName)
                        {
                            Form1.CurrentWalletDeleted = true;
                        }
                    }
                }
            }
            setTable();
        }

        private void DeleteGoal_Load(object sender, EventArgs e)
        {
            connectCourseDB = new SqlConnection(ConfigurationManager.ConnectionStrings["CourseWorkDB"].ConnectionString);
            connectCourseDB.Open();
            setTable();

        }
    }
}
