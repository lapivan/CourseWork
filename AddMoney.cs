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
    public partial class AddMoney : Form
    {
        private SqlConnection connectCourseDB = null;
        private string _name;
        public AddMoney(string name)
        {
            InitializeComponent();
            connectCourseDB = new SqlConnection(ConfigurationManager.ConnectionStrings["CourseWorkDB"].ConnectionString);
            connectCourseDB.Open();
            _name = name;
        }
        public AddMoney()
        {
            InitializeComponent();
            connectCourseDB = new SqlConnection(ConfigurationManager.ConnectionStrings["CourseWorkDB"].ConnectionString);
            connectCourseDB.Open();
        }
        ~AddMoney()
        {
            connectCourseDB.Close();
        }
        private Dollar _dollar = new Dollar();
        private Euro _euro = new Euro();
        private BYN _byn = new BYN();
        private decimal koef = 1;
            

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime todayDate = new DateTime();
            todayDate = DateTime.Now.Date;
            if (string.IsNullOrEmpty(textBoxSum.Text))
            {
                MessageBox.Show($"Нельзя выполнить такую операцию", "Ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                bool result = decimal.TryParse(textBoxSum.Text, out var begSumm);
                
                if (!result || begSumm < 0)
                {
                    MessageBox.Show($"Некорректный ввод начальной суммы", "Ошибка",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if(begSumm>1000000000/koef)
                {
                    MessageBox.Show($"Сумма слишком велика", "Ошибка",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else 
                {
                    begSumm *= koef;
                    Form1.CurrentWalletValue += begSumm;
                    SqlCommand command = new SqlCommand("INSERT INTO [AddMoney] (Name, Value, Date) VALUES (@Name, @Value, @Date)", connectCourseDB);
                    command.Parameters.AddWithValue("Name", _name);
                    command.Parameters.AddWithValue("Value", begSumm);
                    command.Parameters.AddWithValue("Date", todayDate);
                    if (command.ExecuteNonQuery() <= 0)
                    {
                        MessageBox.Show($"Непредвиденная ошибка", "Ошибка",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    SqlCommand commandWallets = new SqlCommand("UPDATE [Wallets] SET Value = Value + @Amount WHERE Name = @WalletName", connectCourseDB);
                    commandWallets.Parameters.AddWithValue("@Amount", begSumm);
                    commandWallets.Parameters.AddWithValue("@WalletName", Form1.CurrentWalletName);
                    if (commandWallets.ExecuteNonQuery() <= 0)
                    {
                        MessageBox.Show($"Непредвиденная ошибка", "Ошибка",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                textBoxSum.Text = "";
            }


        }

        private void AddMoney_Load(object sender, EventArgs e)
        {
            _dollar.Value = Form1.SetCurrentDollar();
            _euro.Value = Form1.SetCurrentEuro();
            _byn.Value = 1;
            if (Form1.IsActiveEUR())
            {
                label1.Text = "EUR";
                koef *= _euro.Value;
            }
            else if (Form1.IsActiveBYN())
            {
                label1.Text = "BYN";
            }
            else
            {
                label1.Text = "USD";
                koef *= _dollar.Value;
            }
        }
    }
}
