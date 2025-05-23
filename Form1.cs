﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using Guna.Charts.WinForms;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Xml;

namespace CourseWork
{
    public partial class Form1 : Form
    {
        private enum TimeAmount
        {
            Today,
            AnyDay,
            Week,
            Month,
            Year,
            AllTime
        }

        private SqlConnection connectCourseDB = null;

        private const string _http = "https://www.nbrb.by/statistics/rates/ratesdaily";

        private static bool _activeBYN = true;
        private static bool _activeUSD = false;
        private static bool _activeEUR = false;

        private Dollar _dollar = new Dollar();
        private Euro _euro = new Euro();
        private BYN _byn = new BYN();

        private decimal _summaryValue;
        private static decimal _currentWalletValue;
        private static string _currentWalletName;
        private static bool _currentWalletDeleted = false;

        private string _password;

        private string[] tableNames = { "AddMoney", "Dreams", "Pass", "Treats", "Wallets" };
        const string xmlFilePath = "DatabaseExport.xml";

        public Form1()
        {
            InitializeComponent();
            tabControl1.DrawItem += TabControl1_DrawItem;
            connectCourseDB = new SqlConnection(ConfigurationManager.ConnectionStrings["CourseWorkDB"].ConnectionString);
            connectCourseDB.Open();
            checkPassword();
            passwordBar();
        }
        ~Form1()
        {
            connectCourseDB.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _dollar.Value = SetCurrentDollar();
            _euro.Value = SetCurrentEuro();
            textBoxCurrentBalance.ReadOnly = true;
            currentVal.Text = "BYN";
            labelCur2.Text = "BYN";
            getMaxBalanceFromDB();
            setSummaryValue();
            setTable();
            setTableDreams();
            _currentWalletValue = Convert.ToDecimal(textBoxCurrentBalance.Text);
            dateTimePicker.CustomFormat = " ";
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            createGraphic_SUMPL();
            createGraphic_SUM();
            needToReceive();
            SetupAboutTab();
        }

        private void addWallet1_Click_1(object sender, EventArgs e)
        {
            AddWallet form = new AddWallet();
            form.Show();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteWallet form = new DeleteWallet();
            form.Show();
        }
        private void chooseButton_Click(object sender, EventArgs e)
        {
            SelectWallet form = new SelectWallet();
            form.Show();
        }
        private void buttonAddMoney_Click(object sender, EventArgs e)
        {
            AddMoney form = new AddMoney(_currentWalletName);
            form.Show();
        }

        private void buttonEat_Click(object sender, EventArgs e)
        {
            SpendMoney form = new SpendMoney("Еда");
            form.Show();
        }
        private void buttonShop_Click(object sender, EventArgs e)
        {
            SpendMoney form = new SpendMoney("Шоппинг");
            form.Show();
        }

        private void buttonRest_Click(object sender, EventArgs e)
        {
            SpendMoney form = new SpendMoney("Отдых");
            form.Show();
        }

        private void buttonTransp_Click(object sender, EventArgs e)
        {
            SpendMoney form = new SpendMoney("Транспорт");
            form.Show();
        }

        private void buttonHealth_Click(object sender, EventArgs e)
        {
            SpendMoney form = new SpendMoney("Здоровье");
            form.Show();
        }

        private void buttonFam_Click(object sender, EventArgs e)
        {
            SpendMoney form = new SpendMoney("Семья");
            form.Show();
        }

        private void buttonClothes_Click(object sender, EventArgs e)
        {
            SpendMoney form = new SpendMoney("Одежда");
            form.Show();
        }

        private void buttonOther_Click(object sender, EventArgs e)
        {
            SpendMoney form = new SpendMoney("Прочее");
            form.Show();
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddDream form = new AddDream();
            form.Show();
        }
        private void buttonDeleteGoal_Click(object sender, EventArgs e)
        {
            DeleteGoal form = new DeleteGoal();
            form.Show();
        }

        private void usdollar()
        {
            currentVal.Text = "USD";
            labelCur2.Text = "USD";
            _activeUSD = true;
            _activeEUR = false;
            _activeBYN = false;
            setTables();
        }
        private void eur()
        {
            currentVal.Text = "EUR";
            labelCur2.Text = "EUR";
            _activeEUR = true;
            _activeUSD = false;
            _activeBYN = false;
            setTables();
        }
        private void byn()
        {
            currentVal.Text = "BYN";
            labelCur2.Text = "BYN";
            _activeBYN = true;
            _activeEUR = false;
            _activeUSD = false;
            setTables();
        }
        private void setTables()
        {
            setSummaryValue();
            SetCurrentInCurrency();
            setTable();
            setTableDreams();
        }
        private void usd_Click(object sender, EventArgs e)
        {
            usdollar();
            needToReceive();
        }

        private void eyr_Click(object sender, EventArgs e)
        {
            eur();
            needToReceive();
        }
        private void blr_Click(object sender, EventArgs e)
        {
            byn();
            needToReceive();
        }
        private void buttonEuro2_Click(object sender, EventArgs e)
        {
            currentVal.Text = "EUR";
            labelCur2.Text = "EUR";
            _activeEUR = true;
            _activeUSD = false;
            _activeBYN = false;
            setSummaryValue();
            SetCurrentInCurrency();
            setTable();
        }

        private void buttonDollar2_Click(object sender, EventArgs e)
        {
            currentVal.Text = "USD";
            labelCur2.Text = "USD";
            _activeUSD = true;
            _activeEUR = false;
            _activeBYN = false;
            setSummaryValue();
            SetCurrentInCurrency();
            setTable();
        }

        private void buttonBYN2_Click(object sender, EventArgs e)
        {
            currentVal.Text = "BYN";
            _activeBYN = true;
            _activeEUR = false;
            _activeUSD = false;
            setSummaryValue();
            labelCur2.Text = "BYN";
            SetCurrentInCurrency();
            setTable();
        }
        private void buttonDolGoals_Click(object sender, EventArgs e)
        {
            usdollar();
            needToReceive();
        }

        private void buttonEURGoals_Click(object sender, EventArgs e)
        {
            eur();
            needToReceive();
        }

        private void buttonBYNGoals_Click(object sender, EventArgs e)
        {
            byn();
            needToReceive();
        }
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {

            oneDayGraphics(TimeAmount.AnyDay);
            oneDayGraphicsAdd(TimeAmount.AnyDay);
        }

        private void buttonToday_Click(object sender, EventArgs e)
        {
            oneDayGraphics(TimeAmount.Today);
            oneDayGraphicsAdd(TimeAmount.Today);
        }

        private void buttonWeek_Click(object sender, EventArgs e)
        {
            oneDayGraphics(TimeAmount.Week);
            oneDayGraphicsAdd(TimeAmount.Week);
        }

        private void buttonMonth_Click(object sender, EventArgs e)
        {
            oneDayGraphics(TimeAmount.Month);
            oneDayGraphicsAdd(TimeAmount.Month);
        }

        private void buttonYear_Click(object sender, EventArgs e)
        {
            oneDayGraphics(TimeAmount.Year);
            oneDayGraphicsAdd(TimeAmount.Year);
        }
        public static bool CurrentWalletDeleted
        {
            set
            {
                _currentWalletDeleted=value;
            }
        }
        public static string CurrentWalletName
        {
            get
            {
                return _currentWalletName;
            }
            set
            {
                _currentWalletName = value;
            }
        }

        public static decimal CurrentWalletValue
        {
            set
            {
                _currentWalletValue = value;
            }
            get
            {
                return _currentWalletValue;
            }
        }
        public static bool IsActiveBYN()
        {
            return _activeBYN;
        }
        public static bool IsActiveEUR()
        {
            return _activeEUR;
        }
        public static bool IsActiveUSD()
        {
            return _activeUSD;
        }

        public static decimal SetCurrentEuro()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string json = client.DownloadString("https://api.nbrb.by/exrates/rates/EUR?parammode=2");
                    dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                    return data.Cur_OfficialRate;
                }
            }
            catch
            {
                return 0;
            }
        }

        public static decimal SetCurrentDollar()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string json = client.DownloadString("https://api.nbrb.by/exrates/rates/USD?parammode=2");
                    dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                    return data.Cur_OfficialRate;
                }
            }
            catch
            {
                return 0;
            }
        }
        private void SetCurrentInCurrency()
        {
            decimal onBeginValue = _currentWalletValue;
            if (_activeEUR)
            {
                onBeginValue /= _euro.Value;
            }
            else if (_activeUSD)
            {
                onBeginValue /= _dollar.Value;
            }
            else
            {
                onBeginValue /= 1;
            }
            textBoxCurrentBalance.Text = onBeginValue.ToString("N2");
            textBoxCurrentMoney2.Text = onBeginValue.ToString("N2");
        }

        private void getMaxBalanceFromDB()
        {
            decimal onBeginValueRUB = 0;
            using (SqlCommand command = new SqlCommand("SELECT MAX(Value) AS максимум FROM WALLETS", connectCourseDB))
            {
                decimal onBeginValue = 0;

                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    onBeginValue = Convert.ToDecimal(result);
                    onBeginValueRUB = onBeginValue;
                    if (_activeEUR)
                    {
                        onBeginValue /= _euro.Value;
                    }
                    else if (_activeUSD)
                    {
                        onBeginValue /= _dollar.Value;
                    }
                    else
                    {
                        onBeginValue /= 1;
                    }
                    textBoxCurrentBalance.Text = onBeginValue.ToString("N2");
                    textBoxCurrentMoney2.Text = onBeginValue.ToString("N2");
                }
                else
                {
                    textBoxCurrentBalance.Text = "0";
                    textBoxCurrentMoney2.Text = "0";
                }

            }
            using (SqlCommand command = new SqlCommand($"SELECT Name FROM WALLETS WHERE Value = {onBeginValueRUB}", connectCourseDB))
            {
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    _currentWalletName = Convert.ToString(result);
                }
                else
                {
                    _currentWalletName = "";
                }
            }
        }
        private void setTable()
        {
            if(_activeUSD)
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter($"SELECT Name, Description, Value/{_dollar.Value} FROM WALLETS WHERE VALUE > 0", connectCourseDB);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns["Name"].HeaderText = "Название";
                dataGridView1.Columns["Description"].HeaderText = "Описание";
                dataGridView1.Columns["Column1"].HeaderText = "Сумма";
                dataGridView1.Columns["Column1"].DefaultCellStyle.Format = "N2";
            }
            else if(_activeEUR)
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter($"SELECT Name, Description, Value/{_euro.Value} FROM WALLETS WHERE VALUE > 0", connectCourseDB);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns["Name"].HeaderText = "Название";
                dataGridView1.Columns["Description"].HeaderText = "Описание";
                dataGridView1.Columns["Column1"].HeaderText = "Сумма";
                dataGridView1.Columns["Column1"].DefaultCellStyle.Format = "N2";
            }
            else
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT Name, Description, Value FROM WALLETS WHERE VALUE > 0", connectCourseDB);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns["Name"].HeaderText = "Название";
                dataGridView1.Columns["Description"].HeaderText = "Описание";
                dataGridView1.Columns["Value"].HeaderText = "Сумма";
                dataGridView1.Columns["Value"].DefaultCellStyle.Format = "N2";
            }
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToOrderColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false; 
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

            if (dataGridView1.Columns.Contains("Description"))
            {
                dataGridView1.Columns["Description"].DefaultCellStyle.ForeColor = Color.FromArgb(0x71, 0x80, 0x96);
            }
        }
        private void setTableDreams()
        {
            if (_activeUSD)
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter($"SELECT Name, Description, Value/{_dollar.Value} FROM Dreams WHERE VALUE > 0", connectCourseDB);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridViewDreams.DataSource = ds.Tables[0];
                dataGridViewDreams.Columns["Name"].HeaderText = "Название";
                dataGridViewDreams.Columns["Description"].HeaderText = "Описание";
                dataGridViewDreams.Columns["Column1"].HeaderText = "Сумма";
                dataGridViewDreams.Columns["Column1"].DefaultCellStyle.Format = "N2";
            }
            else if (_activeEUR)
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter($"SELECT Name, Description, Value/{_euro.Value} FROM Dreams WHERE VALUE > 0", connectCourseDB);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridViewDreams.DataSource = ds.Tables[0];
                dataGridViewDreams.Columns["Name"].HeaderText = "Название";
                dataGridViewDreams.Columns["Description"].HeaderText = "Описание";
                dataGridViewDreams.Columns["Column1"].HeaderText = "Сумма";
                dataGridViewDreams.Columns["Column1"].DefaultCellStyle.Format = "N2";
            }
            else
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT Name, Description, Value FROM Dreams WHERE VALUE > 0", connectCourseDB);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridViewDreams.DataSource = ds.Tables[0];
                dataGridViewDreams.Columns["Name"].HeaderText = "Название";
                dataGridViewDreams.Columns["Description"].HeaderText = "Описание";
                dataGridViewDreams.Columns["Value"].HeaderText = "Сумма";
                dataGridViewDreams.Columns["Value"].DefaultCellStyle.Format = "N2";
            }
            dataGridViewDreams.ReadOnly = true;
            dataGridViewDreams.AllowUserToOrderColumns = false;
            dataGridViewDreams.AllowUserToAddRows = false;
            dataGridViewDreams.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewDreams.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0x2E, 0x5B, 0xFF);
            dataGridViewDreams.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewDreams.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridViewDreams.Font, FontStyle.Bold);
            dataGridViewDreams.EnableHeadersVisualStyles = false;
            dataGridViewDreams.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dataGridViewDreams.DefaultCellStyle.ForeColor = Color.FromArgb(0x2D, 0x37, 0x48);
            dataGridViewDreams.DefaultCellStyle.BackColor = Color.White;
            dataGridViewDreams.DefaultCellStyle.SelectionForeColor = Color.FromArgb(0x2D, 0x37, 0x48);
            dataGridViewDreams.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0xE6, 0xF0, 0xFF);
            dataGridViewDreams.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(0xF5, 0xF9, 0xFF);
            dataGridViewDreams.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(0x2D, 0x37, 0x48);
            dataGridViewDreams.GridColor = Color.FromArgb(0xE2, 0xE8, 0xF0);
            dataGridViewDreams.BorderStyle = BorderStyle.None;
            dataGridViewDreams.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewDreams.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewDreams.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }
        private void setSummaryValue()
        {
            using (SqlCommand command = new SqlCommand("SELECT SUM(Value) AS сумма FROM WALLETS", connectCourseDB))
            {
                decimal onBeginValue = 0;
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    onBeginValue = Convert.ToDecimal(result);
                    if (_activeEUR)
                    {
                        onBeginValue /= _euro.Value;
                    }
                    else if (_activeUSD)
                    {
                        onBeginValue /= _dollar.Value;
                    }
                    else
                    {
                        onBeginValue /= 1;
                    }
                    maskedTextBoxAllMoney.Text = onBeginValue.ToString("N2");
                }
                else
                {
                    maskedTextBoxAllMoney.Text = "0";
                }
                _summaryValue = onBeginValue;
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            setTable();
            setSummaryValue();
            SetCurrentInCurrency();
            if (_currentWalletDeleted==true)
            {
                getMaxBalanceFromDB();
                _currentWalletValue = Convert.ToDecimal(textBoxCurrentBalance.Text);
                _currentWalletDeleted =false;
            }
            needToReceive();
        }
        private void tabControl1_Click(object sender, EventArgs e)
        {
            setTable();
        }

        private void updButton2_Click(object sender, EventArgs e)
        {
            setTable();
            setSummaryValue();
            SetCurrentInCurrency();
            if (_currentWalletDeleted == true)
            {
                getMaxBalanceFromDB();
                _currentWalletValue = Convert.ToDecimal(textBoxCurrentBalance.Text);
                _currentWalletDeleted = false;
            }

        }

        private void createGraphic_SUM()
        {
            var data = new DataTable();
            data.Columns.Add("Категория", typeof(string));
            data.Columns.Add("Потрачено", typeof(decimal));
            string[] categories = { "Еда", "Шоппинг", "Транспорт", "Здоровье", "Семья", "Одежда", "Отдых", "Прочее" };

            foreach (string category in categories)
            {
                using (SqlCommand command = new SqlCommand("SELECT SUM(Value) AS сумма FROM Treats WHERE Name = @Category", connectCourseDB))
                {
                    command.Parameters.AddWithValue("@Category", category);

                    object result = command.ExecuteScalar();
                    decimal value = (result != null && result != DBNull.Value) ?
                                  Convert.ToDecimal(result) : 0;

                    if (value > 0)
                    {
                        data.Rows.Add(category, value);
                    }
                }
            }
            UpdateChart(gunaChart1, data, "Статистика расходов по категориям");
        }
        private void createGraphic_SUMPL()
        {
            var data = new DataTable();
            data.Columns.Add("Пополнение на", typeof(decimal));
            using (SqlCommand command = new SqlCommand("SELECT SUM(Value) AS сумма FROM AddMoney", connectCourseDB))
            {

                object result = command.ExecuteScalar();
                decimal value = (result != null && result != DBNull.Value) ?
                                Convert.ToDecimal(result) : 0;
                data.Rows.Add(value);
            }
            updateChartPl(gunaChartpl, data, "");

        }
        private void oneDayGraphics(TimeAmount timeAmount)
        {
            DateTime chooseDate= DateTime.Now.Date;
            DateTime compareDate= DateTime.Now.Date;
            if (timeAmount == TimeAmount.Today)
            {
                chooseDate = DateTime.Now.Date;
                DateDiapason.Text = DateTime.Now.Date.ToShortDateString();
            }
            else if (timeAmount == TimeAmount.AnyDay)
            {
                chooseDate = dateTimePicker.Value.Date;
                DateDiapason.Text = chooseDate.ToShortDateString();
            }
            else if(timeAmount == TimeAmount.Week)
            {
                compareDate= chooseDate.AddDays(-7);
                DateDiapason.Text = $"{compareDate.ToShortDateString()} - {chooseDate.ToShortDateString()}";
            }
            else if(timeAmount == TimeAmount.Month)
            {
                compareDate = chooseDate.AddDays(-30);
                DateDiapason.Text = $"{compareDate.ToShortDateString()} - {chooseDate.ToShortDateString()}";
            }
            else
            {
                compareDate = chooseDate.AddDays(-365);
                DateDiapason.Text = $"{compareDate.ToShortDateString()} - {chooseDate.ToShortDateString()}";
            }
            var data = new DataTable();
            data.Columns.Add("Категория", typeof(string));
            data.Columns.Add("Потрачено", typeof(decimal));
            string[] categories = { "Еда", "Шоппинг", "Транспорт", "Здоровье", "Семья", "Одежда", "Отдых", "Прочее" };

            foreach (string category in categories)
            {
                if (timeAmount == TimeAmount.Today || timeAmount == TimeAmount.AnyDay)
                {
                    using (SqlCommand command = new SqlCommand("SELECT SUM(Value) AS сумма FROM Treats WHERE Name = @Category AND Date = @Date", connectCourseDB))
                    {
                        command.Parameters.AddWithValue("@Category", category);
                        command.Parameters.AddWithValue("@Date", chooseDate);

                        object result = command.ExecuteScalar();
                        decimal value = (result != null && result != DBNull.Value) ?
                                      Convert.ToDecimal(result) : 0;
                            data.Rows.Add(category, value);
                    }
                }
                else
                {
                    using (SqlCommand command = new SqlCommand("SELECT SUM(Value) AS сумма FROM Treats WHERE Name = @Category AND Date >= @Date", connectCourseDB))
                    {
                        command.Parameters.AddWithValue("@Category", category);
                        command.Parameters.AddWithValue("@Date", compareDate);

                        object result = command.ExecuteScalar();
                        decimal value = (result != null && result != DBNull.Value) ?
                                      Convert.ToDecimal(result) : 0;
                            data.Rows.Add(category, value);
                    }
                }
            }
            UpdateChart(gunaChart1, data, "Статистика расходов по категориям");
        }
        private void createGraphic_Click(object sender, EventArgs e)
        {
            createGraphic_SUM();
            DateDiapason.Text = "";
        }
        private void UpdateChart(GunaChart chart,  DataTable data, string title)
        {
            if (data.Rows.Count == 0)
            {
                MessageBox.Show("Данных не достаточно.", "Ошибка");
                return;
            } 
            try
            {
                chart.Datasets.Clear();
                chart.Legend.Position = LegendPosition.Right;
                chart.Legend.Display = true;
                chart.XAxes.Display = false;
                chart.YAxes.Display = false;

                var dataset = new GunaPieDataset();
                foreach (DataRow row in data.Rows)
                {
                    dataset.DataPoints.Add(
                        row[0].ToString(),
                        Convert.ToDouble(row[1])
                    );
                }

                chart.Datasets.Add(dataset);
            }
            finally
            {
            }
        }
        private void updateChartPl(GunaChart chart, DataTable data, string title)
        {
            if (data.Rows.Count == 0)
            {
                MessageBox.Show("Данных не достаточно.", "Ошибка");
                return;
            }
            try
            {
                chart.Datasets.Clear();
                double value = Convert.ToDouble(data.Rows[0][0]);

                var dataset = new GunaBarDataset()
                {
                    Label = $"{title}: {value}"
                };
                chart.Legend.Position = LegendPosition.Right;
                chart.Legend.Display = true;
                chart.XAxes.Display = false;
                chart.YAxes.Display = false;

                foreach (DataRow row in data.Rows)
                {
                    dataset.DataPoints.Add("",
                        Convert.ToDouble(row[0])
                    );
                }

                chart.Datasets.Add(dataset);
            }
            finally
            {
            }
        }
        private void oneDayGraphicsAdd(TimeAmount timeAmount)
        {
            DateTime chooseDate = DateTime.Now.Date;
            DateTime compareDate = DateTime.Now.Date;
            if (timeAmount == TimeAmount.Today)
            {
                chooseDate = DateTime.Now.Date;
                DateDiapason.Text = DateTime.Now.Date.ToShortDateString();
            }
            else if (timeAmount == TimeAmount.AnyDay)
            {
                chooseDate = dateTimePicker.Value.Date;
                DateDiapason.Text = chooseDate.ToShortDateString();
            }
            else if (timeAmount == TimeAmount.Week)
            {
                compareDate = chooseDate.AddDays(-7);
                DateDiapason.Text = $"{compareDate.ToShortDateString()} - {chooseDate.ToShortDateString()}";
            }
            else if (timeAmount == TimeAmount.Month)
            {
                compareDate = chooseDate.AddDays(-30);
                DateDiapason.Text = $"{compareDate.ToShortDateString()} - {chooseDate.ToShortDateString()}";
            }
            else
            {
                compareDate = chooseDate.AddDays(-365);
                DateDiapason.Text = $"{compareDate.ToShortDateString()} - {chooseDate.ToShortDateString()}";
            }
            var data = new DataTable();
            data.Columns.Add("Пополнение на", typeof(decimal));
            if (timeAmount == TimeAmount.Today || timeAmount == TimeAmount.AnyDay)
            {
                using (SqlCommand command = new SqlCommand("SELECT SUM(Value) AS сумма FROM AddMoney WHERE Date = @Date", connectCourseDB))
                {
                    command.Parameters.AddWithValue("@Date", chooseDate);

                    object result = command.ExecuteScalar();
                    decimal value = (result != null && result != DBNull.Value) ?
                                    Convert.ToDecimal(result) : 0;
                    data.Rows.Add(value);
                }
            }
            else
            {
                using (SqlCommand command = new SqlCommand("SELECT SUM(Value) AS сумма FROM AddMoney WHERE Date >= @Date", connectCourseDB))
                {
                    command.Parameters.AddWithValue("@Date", compareDate);

                    object result = command.ExecuteScalar();
                    decimal value = (result != null && result != DBNull.Value) ?
                                    Convert.ToDecimal(result) : 0;
                    data.Rows.Add(value);

                }
            }
            updateChartPl(gunaChartpl, data, "");
        }

        private void needToReceive()
        {
            decimal needToReceive;
            using (SqlCommand command = new SqlCommand("SELECT SUM(Value) AS сумма FROM Dreams WHERE Value > 0", connectCourseDB))
            {
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    needToReceive = Convert.ToDecimal(result);
                }
                else
                {
                    needToReceive = 0;
                }
            }
            if (_activeBYN)
            {
                needToReceive /= 1;
                curGoals.Text = "BYN";
            }
            else if(_activeEUR)
            {
                needToReceive/=  _euro.Value;
                curGoals.Text = "EUR";
            }
            else
            {
                needToReceive /= _dollar.Value;
                curGoals.Text = "USD";
            }
            needToReceive -= _summaryValue;
            if (needToReceive > 0)
            {
                NeedToReceive.Text = needToReceive.ToString("N2");
            }
            else
            {
                NeedToReceive.Text = "Сумма накоплена";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            setTableDreams();
            needToReceive();
        }
        private void TabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tc = (TabControl)sender;
            TabPage tab = tc.TabPages[e.Index];
            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            Color backColor = isSelected ? Color.FromArgb(0x2E, 0x5B, 0xFF) : Color.FromArgb(0xCB, 0xD5, 0xE0);
            Color textColor = isSelected ? Color.White : Color.FromArgb(0x4A, 0x55, 0x68);
            using (SolidBrush brush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }
            TextRenderer.DrawText
            (
                e.Graphics,
                tab.Text,
                tab.Font,
                new Rectangle(e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height),
                textColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );
            if (e.Index < tc.TabCount - 1)
            {
                using (Pen pen = new Pen(Color.FromArgb(0xE2, 0xE8, 0xF0)))
                {
                    e.Graphics.DrawLine(pen,
                        e.Bounds.Right - 1, e.Bounds.Top + 5,
                        e.Bounds.Right - 1, e.Bounds.Bottom - 5);
                }
            }
        }

        private void panelAddMoney_Paint(object sender, PaintEventArgs e)
        {

        }
        private void SetupAboutTab()
        {
            WebBrowser browser = new WebBrowser
            {
                Dock = DockStyle.Fill,
                ScrollBarsEnabled = false
            };

            tabPage3.Controls.Add(browser);

            string htmlContent = @"
    <!DOCTYPE html>
    <html>
    <head>
        <meta http-equiv='Content-Type' content='text/html; charset=utf-8'>
        <style>
            body {
                font-family: 'Segoe UI', Arial;
                padding: 20px;
                color: #333;
                line-height: 1.6;
            }
            h1 {
                color: #0056b3;
                text-align: center;
                margin-bottom: 10px;
            }
            .version {
                text-align: center;
                color: #666;
                margin-bottom: 20px;
            }
            ul {
                padding-left: 20px;
            }
            li {
                margin-bottom: 8px;
            }
            .footer {
                margin-top: 30px;
                text-align: center;
                font-size: 12px;
                color: #888;
            }
        </style>
    </head>
    <body>
        <h1>Финансовый менеджер</h1>
        <div class='version'>Версия 1.0.0</div>
        
        <p>Приложение для управления личными финансами:</p>
        
        <ul>
            <li>Учет доходов и расходов</li>
            <li>Анализ финансовых операций</li>
            <li>Ведение нескольких счетов</li>
            <li>Создание резервных копий</li>
        </ul>
        
        <div class='footer'>
            <p>© 2025 Все права защищены</p>
            <p>Курсовой проект</p>
        </div>
    </body>
    </html>";

            browser.DocumentText = htmlContent;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        private void checkPassword()
        {
            using (SqlCommand command = new SqlCommand("SELECT TOP 1 password FROM Pass", connectCourseDB))
            {
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    _password = Convert.ToString(result);
                }
                else
                {
                    _password = "";
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (var passwordForm = new Form())
            {
                passwordForm.Text = "Новый пароль";
                passwordForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                passwordForm.StartPosition = FormStartPosition.CenterScreen;
                passwordForm.MaximizeBox = false;
                passwordForm.MinimizeBox = false;
                passwordForm.Size = new Size(350, 200);
                passwordForm.BackColor = Color.FromArgb(230, 240, 255);
                passwordForm.Font = new Font("Segoe UI", 10);
                var label = new Label
                {
                    Text = "Введите новый пароль:",
                    Location = new Point(20, 20),
                    AutoSize = true,
                    ForeColor = Color.FromArgb(50, 50, 50)
                };

                var textBox = new TextBox
                {
                    PasswordChar = '•',
                    Location = new Point(20, 50),
                    Size = new Size(290, 25),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.White
                };

                var button = new Button
                {
                    Text = "Подтвердить",
                    Location = new Point(120, 100),
                    Size = new Size(100, 35),
                    BackColor = Color.FromArgb(0, 120, 215),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    DialogResult = DialogResult.OK
                };

                button.FlatAppearance.BorderSize = 0;
                button.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 100, 200);

                passwordForm.Controls.Add(label);
                passwordForm.Controls.Add(textBox);
                passwordForm.Controls.Add(button);
                passwordForm.AcceptButton = button;
                if (passwordForm.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(textBox.Text))
                    {
                        try
                        {
                            using (SqlCommand rm = new SqlCommand("TRUNCATE TABLE [Pass]", connectCourseDB))
                            {
                                rm.ExecuteNonQuery();
                            }

                            using (SqlCommand command = new SqlCommand("INSERT INTO [Pass] (password) VALUES (@P)", connectCourseDB))
                            {
                                command.Parameters.AddWithValue("@P", textBox.Text);
                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Пароль успешно изменен!", "Успех",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Не удалось изменить пароль", "Ошибка",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка при изменении пароля: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пароль не может быть пустым!", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlCommand rm = new SqlCommand("TRUNCATE TABLE [Pass]", connectCourseDB))
            {
                rm.ExecuteNonQuery();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement root = xmlDoc.CreateElement("DatabaseData");
            xmlDoc.AppendChild(root);
            foreach (string tableName in tableNames)
            {
                string query = $"SELECT * FROM {tableName} FOR XML AUTO, ROOT('{tableName}')";
                using (SqlCommand cmd = new SqlCommand(query, connectCourseDB))
                {
                    string tableXml = (string)cmd.ExecuteScalar();
                    XmlDocumentFragment fragment = xmlDoc.CreateDocumentFragment();
                    fragment.InnerXml = tableXml;
                    root.AppendChild(fragment);
                }
            }
            xmlDoc.Save(xmlFilePath);
            MessageBox.Show($"Копия успешно создана", "Выполнено",
                   MessageBoxButtons.OK);        
        }
        private void passwordBar()
        {
            if (!string.IsNullOrEmpty(_password))
            {
                bool passwordCorrect = false;
                int attempts = 0;
                const int maxAttempts = 3;

                while (!passwordCorrect && attempts < maxAttempts)
                {
                    using (var passwordForm = new Form())
                    {
                        passwordForm.Text = "Требуется авторизация";
                        passwordForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                        passwordForm.StartPosition = FormStartPosition.CenterScreen;
                        passwordForm.MaximizeBox = false;
                        passwordForm.MinimizeBox = false;
                        passwordForm.Size = new Size(350, 200);
                        passwordForm.BackColor = Color.FromArgb(230, 240, 255);
                        passwordForm.Font = new Font("Segoe UI", 10);

                        passwordForm.FormClosing += (s, e) =>
                        {
                            if (!passwordCorrect && passwordForm.DialogResult != DialogResult.OK)
                            {
                                Application.Exit();
                            }
                        };

                        var label = new Label
                        {
                            Text = "Введите пароль для доступа:",
                            Location = new Point(20, 20),
                            AutoSize = true,
                            ForeColor = Color.FromArgb(50, 50, 50)
                        };

                        var textBox = new TextBox
                        {
                            PasswordChar = '•',
                            Location = new Point(20, 50),
                            Size = new Size(290, 25),
                            BorderStyle = BorderStyle.FixedSingle,
                            BackColor = Color.White
                        };

                        var button = new Button
                        {
                            Text = "Подтвердить",
                            Location = new Point(120, 100),
                            Size = new Size(100, 35),
                            BackColor = Color.FromArgb(0, 120, 215),
                            ForeColor = Color.White,
                            FlatStyle = FlatStyle.Flat,
                            Cursor = Cursors.Hand
                        };
                        button.FlatAppearance.BorderSize = 0;
                        button.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 100, 200);
                        button.Click += (sender, e) =>
                        {
                            if (textBox.Text == _password)
                            {
                                passwordCorrect = true;
                                passwordForm.DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                attempts++;
                                if (attempts >= maxAttempts)
                                {
                                    MessageBox.Show("Превышено максимальное количество попыток. Приложение будет закрыто.",
                                                  "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    passwordForm.DialogResult = DialogResult.Cancel;
                                }
                                else
                                {
                                    MessageBox.Show($"Неверный пароль! Осталось попыток: {maxAttempts - attempts}",
                                                   "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    textBox.Text = "";
                                    textBox.Focus();
                                }
                            }
                        };

                        passwordForm.Controls.Add(label);
                        passwordForm.Controls.Add(textBox);
                        passwordForm.Controls.Add(button);
                        passwordForm.AcceptButton = button;
                        if (passwordForm.ShowDialog() != DialogResult.OK)
                        {
                            Application.Exit();
                            return;
                        }
                    }
                }

                if (!passwordCorrect)
                {
                    Application.Exit();
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlTransaction transaction = connectCourseDB.BeginTransaction())
            {
                try
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(xmlFilePath);

                    foreach (XmlNode tableNode in xmlDoc.DocumentElement.ChildNodes)
                    {
                        string tableName = tableNode.Name;
                        using (SqlCommand clearCmd = new SqlCommand($"DELETE FROM {tableName}", connectCourseDB, transaction))
                        {
                            clearCmd.ExecuteNonQuery();
                        }
                        bool hasIdentityColumn = false;
                        using (SqlCommand checkIdentityCmd = new SqlCommand(
                            $"SELECT OBJECTPROPERTY(OBJECT_ID('{tableName}'), 'TableHasIdentity')",
                            connectCourseDB, transaction))
                        {
                            hasIdentityColumn = (int)checkIdentityCmd.ExecuteScalar() == 1;
                        }
                        if (hasIdentityColumn)
                        {
                            new SqlCommand($"SET IDENTITY_INSERT {tableName} ON", connectCourseDB, transaction)
                                .ExecuteNonQuery();
                        }
                        foreach (XmlNode rowNode in tableNode.ChildNodes)
                        {
                            var parameters = new List<SqlParameter>();
                            var columnNames = new List<string>();
                            var paramNames = new List<string>();

                            foreach (XmlAttribute attr in rowNode.Attributes)
                            {
                                columnNames.Add(attr.Name);
                                paramNames.Add($"@{attr.Name}");

                                parameters.Add(new SqlParameter(
                                    $"@{attr.Name}",
                                    attr.Value == null ? DBNull.Value : (object)attr.Value
                                ));
                            }

                            string insertQuery = $@"
                    INSERT INTO {tableName} 
                    ({string.Join(", ", columnNames)}) 
                    VALUES ({string.Join(", ", paramNames)})";

                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, connectCourseDB, transaction))
                            {
                                insertCmd.Parameters.AddRange(parameters.ToArray());
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                        if (hasIdentityColumn)
                        {
                            new SqlCommand($"SET IDENTITY_INSERT {tableName} OFF", connectCourseDB, transaction)
                                .ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
