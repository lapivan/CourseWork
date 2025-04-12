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
    public partial class SelectWallet : Form
    {
        public SelectWallet()
        {
            InitializeComponent();
        }
        ~SelectWallet()
        {
            connectCourseDB.Close();
        }
        private SqlConnection connectCourseDB = null;
        private void setTable()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT Name FROM WALLETS WHERE VALUE > 0", connectCourseDB);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            DataTable dt = ds.Tables[0];
            dt.Columns.Add("Select", typeof(bool));

            dataGridViewSelect.DataSource = dt;

            dataGridViewSelect.Columns["Name"].HeaderText = "Название";
            dataGridViewSelect.Columns["Select"].HeaderText = "Выбрать";

            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Выбрать";
            checkBoxColumn.Name = "Select";
            checkBoxColumn.TrueValue = true;
            checkBoxColumn.FalseValue = false;

            dataGridViewSelect.ReadOnly = false;
            dataGridViewSelect.AllowUserToOrderColumns = false;
            dataGridViewSelect.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewSelect.Columns["Name"].ReadOnly = true;
        }
        private void buttonSelect_Click(object sender, EventArgs e)
        {
            int count = 0;
            decimal tmpValue = 0;
            foreach (DataGridViewRow row in dataGridViewSelect.Rows)
            {
                if (row.Cells["Select"].Value != null &&
                (row.Cells["Select"].Value is bool isSelected && isSelected))
                {
                    count++;
                    if (count  >1)
                    {
                        MessageBox.Show($"Нельзя выбрать два счета одновременно", "Ошибка",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string walletName = row.Cells["Name"].Value.ToString();
                    using (SqlCommand cmd = new SqlCommand("SELECT VALUE FROM WALLETS WHERE Name = @Name", connectCourseDB))
                    {
                        cmd.Parameters.AddWithValue("@Name", walletName);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            tmpValue = Convert.ToDecimal(result);
                        }
                        else
                        {
                            result = 0;
                        }
                        Form1.CurrentWalletName = walletName;
                    }
                }
            }
            
            Form1.CurrentWalletValue=tmpValue;
            setTable();
        }

        private void SelectWallet_Load(object sender, EventArgs e)
        {
            connectCourseDB = new SqlConnection(ConfigurationManager.ConnectionStrings["CourseWorkDB"].ConnectionString);
            connectCourseDB.Open();
            setTable();
        }
    }
}
