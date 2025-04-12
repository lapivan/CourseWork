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
    public partial class AddDream : Form
    {
        private decimal _koef = 1;
        private Dollar _dollar = new Dollar();
        private Euro _euro = new Euro();
        private BYN _byn = new BYN();
        private SqlConnection connectCourseDB = null;
        public AddDream()
        {
            InitializeComponent();
        }
        ~AddDream()
        {
            connectCourseDB.Close();
        }
        private void AddDream_Load(object sender, EventArgs e)
        {
            connectCourseDB = new SqlConnection(ConfigurationManager.ConnectionStrings["CourseWorkDB"].ConnectionString);
            connectCourseDB.Open();
            _dollar.Value = Form1.SetCurrentDollar();
            _euro.Value = Form1.SetCurrentEuro();
        }

        private void toolStripButtonUSD_Click(object sender, EventArgs e)
        {
            _koef = _dollar.Value;
        }

        private void toolStripButtonEUR_Click(object sender, EventArgs e)
        {
            _koef = _euro.Value;
        }

        private void toolStripButtonBYN_Click(object sender, EventArgs e)
        {
            _koef = _byn.Value;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(WallName.Text) && string.IsNullOrEmpty(WallDescr.Text) && string.IsNullOrEmpty(WallBegSum.Text))
            {
                MessageBox.Show($"Нельзя создать пустой счет ", "Ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(WallName.Text))
            {
                MessageBox.Show($"Нельзя создать счет без имени", "Ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //string query = "SELECT 1 FROM DREAMS WHERE Name = @WalletName";

                //using (SqlCommand cmd = new SqlCommand(query, connectCourseDB))
                //{
                //    cmd.Parameters.AddWithValue("@WalletName", WallName.Text);

                //    object result0 = cmd.ExecuteScalar();
                //    if (result0 != null && result0 != DBNull.Value)
                //    {
                //        MessageBox.Show($"Счет с таким именем существует", "Ошибка",
                //       MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        return;
                //    }
                //}

                if (string.IsNullOrEmpty(WallBegSum.Text))
                {
                    WallBegSum.Text = "0";
                }
                bool result = decimal.TryParse(WallBegSum.Text, out var begSumm);
                if (!result || begSumm < 0)
                {
                    MessageBox.Show($"Некорректный ввод начальной суммы", "Ошибка",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                begSumm *= _koef;
                SqlCommand command = new SqlCommand("INSERT INTO [DREAMS] (Name, Description, Value) VALUES (@Name, @Description, @Value)", connectCourseDB);
                command.Parameters.AddWithValue("Name", WallName.Text);
                command.Parameters.AddWithValue("Description", WallDescr.Text);
                command.Parameters.AddWithValue("Value", begSumm);
                if (command.ExecuteNonQuery() <= 0)
                {
                    MessageBox.Show($"Непредвиденная ошибка", "Ошибка",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                WallName.Text = "";
                WallDescr.Text = "";
                WallBegSum.Text = "";
            }
        }
    }
}
