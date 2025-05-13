using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CourseWork
{
    public partial class SpendMoney : Form
    {
        private SqlConnection connectCourseDB = null;
        public SpendMoney()
        {
            InitializeComponent();
            connectCourseDB = new SqlConnection(ConfigurationManager.ConnectionStrings["CourseWorkDB"].ConnectionString);
            connectCourseDB.Open();
        }
        private  string _name;
        public SpendMoney(string name)
        {
            InitializeComponent();
            connectCourseDB = new SqlConnection(ConfigurationManager.ConnectionStrings["CourseWorkDB"].ConnectionString);
            connectCourseDB.Open();
            _name= name;
        }
        ~SpendMoney()
        {
            connectCourseDB.Close();
        }
        private Dollar _dollar = new Dollar();
        private Euro _euro = new Euro();
        private BYN _byn = new BYN();
        private decimal koef = 1;
        private void SpendMoney_Load(object sender, EventArgs e)
        {
            _dollar.Value = Form1.SetCurrentDollar();
            _euro.Value = Form1.SetCurrentEuro();
            _byn.Value = 1;
            if (Form1.IsActiveEUR())
            {
                labelCurrency.Text = "EUR";
                koef*=_euro.Value;
            }
            else if (Form1.IsActiveBYN())
            {
                labelCurrency.Text = "BYN";
            }
            else
            {
                labelCurrency.Text = "USD";
                koef *= _dollar.Value;
            }
        }

        private void buttonspend_Click(object sender, EventArgs e)
        {
            DateTime todayDate = new DateTime();
            todayDate = DateTime.Now.Date;
            if (string.IsNullOrEmpty(textSum.Text) || string.IsNullOrEmpty(textDescr.Text))
            {
                MessageBox.Show($"Нельзя выполнить такую операцию", "Ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                bool result = decimal.TryParse(textSum.Text, out var begSumm);
                if (!result || begSumm < 0)
                {
                    MessageBox.Show($"Некорректный ввод начальной суммы", "Ошибка",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (begSumm > Form1.CurrentWalletValue)
                {
                    begSumm *= koef;
                    MessageBox.Show($"На текущем счете недостаточно средств", "Ошибка",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    begSumm *= koef;
                    SqlCommand command = new SqlCommand("INSERT INTO [Treats] (Name, Description, Value, Date) VALUES (@Name, @Description, @Value, @Date)", connectCourseDB);
                    command.Parameters.AddWithValue("Name", _name);
                    command.Parameters.AddWithValue("Description", textDescr.Text);
                    command.Parameters.AddWithValue("Value", begSumm);
                    command.Parameters.AddWithValue("Date", todayDate);
                    if (command.ExecuteNonQuery() <= 0)
                    {
                        MessageBox.Show($"Непредвиденная ошибка", "Ошибка",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Form1.CurrentWalletValue -=begSumm;
                    SqlCommand commandWallets = new SqlCommand("UPDATE [Wallets] SET Value = Value - @Amount WHERE Name = @WalletName",connectCourseDB);
                    commandWallets.Parameters.AddWithValue("@Amount", begSumm);
                    commandWallets.Parameters.AddWithValue("@WalletName", Form1.CurrentWalletName);
                    if (commandWallets.ExecuteNonQuery() <= 0)
                    {
                        MessageBox.Show($"Непредвиденная ошибка", "Ошибка",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            }
            textSum.Text = "";
            textDescr.Text = "";
        }
    }
}
