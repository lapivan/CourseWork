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
    public partial class DeleteWallet : Form
    {
        private SqlConnection connectCourseDB = null;
        private void setTable()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT Name FROM WALLETS WHERE VALUE > 0", connectCourseDB);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            DataTable dt = ds.Tables[0];
            dt.Columns.Add("Select", typeof(bool));

            dataGridViewDelete.DataSource = dt;

            dataGridViewDelete.Columns["Name"].HeaderText = "Название";
            dataGridViewDelete.Columns["Select"].HeaderText = "Выбрать";

            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Выбрать";
            checkBoxColumn.Name = "Select";
            checkBoxColumn.TrueValue = true;
            checkBoxColumn.FalseValue = false;

            dataGridViewDelete.ReadOnly = false;
            dataGridViewDelete.AllowUserToOrderColumns = false;
            dataGridViewDelete.AllowUserToAddRows = false;
            dataGridViewDelete.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewDelete.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0x2E, 0x5B, 0xFF);
            dataGridViewDelete.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewDelete.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridViewDelete.Font, FontStyle.Bold);
            dataGridViewDelete.EnableHeadersVisualStyles = false;
            dataGridViewDelete.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dataGridViewDelete.DefaultCellStyle.ForeColor = Color.FromArgb(0x2D, 0x37, 0x48);
            dataGridViewDelete.DefaultCellStyle.BackColor = Color.White;
            dataGridViewDelete.DefaultCellStyle.SelectionForeColor = Color.FromArgb(0x2D, 0x37, 0x48);
            dataGridViewDelete.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0xE6, 0xF0, 0xFF);
            dataGridViewDelete.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(0xF5, 0xF9, 0xFF);
            dataGridViewDelete.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(0x2D, 0x37, 0x48);
            dataGridViewDelete.GridColor = Color.FromArgb(0xE2, 0xE8, 0xF0);
            dataGridViewDelete.BorderStyle = BorderStyle.None;
            dataGridViewDelete.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewDelete.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewDelete.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridViewDelete.Columns["Name"].ReadOnly = true;
        }
        public DeleteWallet()
        {
            InitializeComponent();
        }
        ~DeleteWallet()
        {
            connectCourseDB.Close();
        }

        private void DeleteWallet_Load(object sender, EventArgs e)
        {
            connectCourseDB = new SqlConnection(ConfigurationManager.ConnectionStrings["CourseWorkDB"].ConnectionString);
            connectCourseDB.Open();
            setTable();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewDelete.Rows)
            {
                if (row.Cells["Select"].Value != null &&
                (row.Cells["Select"].Value is bool isSelected && isSelected))
                {
                    string walletName = row.Cells["Name"].Value.ToString();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM WALLETS WHERE Name = @Name", connectCourseDB))
                    {
                        cmd.Parameters.AddWithValue("@Name", walletName);
                        cmd.ExecuteNonQuery();
                        if(walletName == Form1.CurrentWalletName)
                        {
                            Form1.CurrentWalletDeleted = true;
                        }
                    }
                }
            }
            setTable();
        }

        private void dataGridViewDelete_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
