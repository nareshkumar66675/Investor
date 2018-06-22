using Investor;
using Investor.Database;
using Investor.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Investor
{
    public partial class MainForm : Form
    {
        // dbf connection members
        public const string dbfDir = @"C:\Program Files (x86)\Stock Investor\Professional\";
        public string[] dbfDirs = new string[2];

        public Dictionary<string, string[]> dbfToTableDict;

        public const string dbfConnPre = "Provider=vfpoledb.1; Data Source=";

        // query constant

        // consts
        public const int nYears = 7;
        public const int nQuarters = 8;
        public const int TABLE_NAME_IND = 0;
        public const int PK_NAME_IND = 1;
        public const int COLSPEC_IND = 2;
        public string sqlConnStr;
        public SqlDataAdapter sqlAdapter;

        // md5 hash object
        public MD5 md5;
        public MainForm()
        {
            InitializeComponent();
            // initialize sql db connection
            sqlConnStr = "Data Source=" + Environment.MachineName + @"\SQLEXPRESS;Initial Catalog=Investor;Integrated Security=True";

            var tickers = DBOperation.GetTickers();
            tickerComboBox.DataSource = tickers;
            tickerComboBox.ValueMember = "ticker";
            tickerComboBox.DisplayMember = "ticker";
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            DBConstruct constg = new DBConstruct();
            constg.Initialize();

            updateProgressBar.Maximum = constg.Specs.Count;
            updateProgressBar.Value = 0;
            updateStatus.Text = string.Empty;

            var updateProgress = new Progress<int>();

            updateProgress.ProgressChanged += UpdateProgress_ProgressChanged;

            Task.Factory.StartNew(() => constg.StartDBUpdate(updateProgress));
        }

        private void UpdateProgress_ProgressChanged(object sender, int completed)
        {
            if(updateProgressBar.Value < completed)
            {
                updateProgressBar.Increment(1);
                updateStatus.Text = $"{completed} of {updateProgressBar.Maximum} completed";
            }
        }
        private void viewChartButton_Click(object sender, EventArgs e)
        {
            FundamentalCharts fundamentalCharts = new FundamentalCharts();

            fundamentalCharts.ShowChart(tickerComboBox.Text);

            fundamentalCharts.Show();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            //start creating the query and dataset
            string queryString = null;
            queryString = "Select ticker, company, business from si_ci where business Like ";
            DataSet queryDS = null;
            queryDS = new DataSet();

            //check that there is at least some text entered in the first query box
            if ((string.IsNullOrEmpty(queryText1.Text)))
            {
                MessageBox.Show("There must be text entered To search");
                return;
            }

            //create query string
            queryString += "'%" + queryText1.Text + "%' ";
            if ((andOption1.Checked | orOption1.Checked) & (!string.IsNullOrEmpty(queryText2.Text)))
            {
                queryString += andOption1.Checked ? "and " : "or " + "business like '%" + queryText2.Text + "%' ";
            }
            if ((andOption2.Checked | orOption2.Checked) & (!string.IsNullOrEmpty(queryText3.Text)))
            {
                queryString += andOption1.Checked ? "and " : "or " + "business like '%" + queryText2.Text + "%' ";
            }

            //run the query
            sqlAdapter.SelectCommand.CommandText = queryString;
            sqlAdapter.Fill(queryDS);

            //now create the new query window with the gridview having the query result as the data source
            QueryForm queryWindow = null;
            queryWindow = new QueryForm();
            queryWindow.gridView.DataSource = queryDS.Tables[0];

            //update the count
            queryWindow.countLabel.Text = queryDS.Tables[0].Rows.Count.ToString();

            //finally show the queryWindows
            queryWindow.Show();

            //resize columns to max width
            queryWindow.gridView.AutoResizeColumns();
        }
    }
}
