using Investor.Database;
using Investor.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Investor
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();

            var tickers = DBOperation.GetTickers();
            tickerComboBox.DataSource = tickers;
            tickerComboBox.ValueMember = "ticker";
            tickerComboBox.DisplayMember = "ticker";
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            DBConstruct constg = new DBConstruct();
            constg.Initialize();

            updateProgressBar.Maximum = constg.Specs.Count;
            updateProgressBar.Value = 0;
            updateStatus.Text = string.Empty;

            var updateProgress = new Progress<int>();

            updateProgress.ProgressChanged += UpdateProgress_ProgressChanged;

            var task = Task.Factory.StartNew(() => constg.StartDBUpdate(updateProgress));

            task.ContinueWith((Task) =>
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    MessageBox.Show(this, "Completed Successfully");
                });

            });
        }

        private void UpdateProgress_ProgressChanged(object sender, int completed)
        {
            if(updateProgressBar.Value < completed)
            {
                updateProgressBar.Increment(1);
                updateStatus.Text = $"{completed} of {updateProgressBar.Maximum} completed";
            }
        }
        private void ViewChartButton_Click(object sender, EventArgs e)
        {
            FundamentalCharts fundamentalCharts = new FundamentalCharts();

            fundamentalCharts.ShowChart(tickerComboBox.Text);

            fundamentalCharts.Show();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            ////start creating the query and dataset
            //string queryString = null;
            //queryString = "Select ticker, company, business from si_ci where business Like ";
            //DataSet queryDS = null;
            //queryDS = new DataSet();

            ////check that there is at least some text entered in the first query box
            //if ((string.IsNullOrEmpty(queryText1.Text)))
            //{
            //    MessageBox.Show("There must be text entered To search");
            //    return;
            //}

            ////create query string
            //queryString += "'%" + queryText1.Text + "%' ";
            //if ((andOption1.Checked | orOption1.Checked) & (!string.IsNullOrEmpty(queryText2.Text)))
            //{
            //    queryString += andOption1.Checked ? "and " : "or " + "business like '%" + queryText2.Text + "%' ";
            //}
            //if ((andOption2.Checked | orOption2.Checked) & (!string.IsNullOrEmpty(queryText3.Text)))
            //{
            //    queryString += andOption1.Checked ? "and " : "or " + "business like '%" + queryText2.Text + "%' ";
            //}

            ////run the query
            //sqlAdapter.SelectCommand.CommandText = queryString;
            //sqlAdapter.Fill(queryDS);

            ////now create the new query window with the gridview having the query result as the data source
            //QueryForm queryWindow = null;
            //queryWindow = new QueryForm();
            //queryWindow.gridView.DataSource = queryDS.Tables[0];

            ////update the count
            //queryWindow.countLabel.Text = queryDS.Tables[0].Rows.Count.ToString();

            ////finally show the queryWindows
            //queryWindow.Show();

            ////resize columns to max width
            //queryWindow.gridView.AutoResizeColumns();
        }
    }
}
