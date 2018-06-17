using Investor.Util;
using SoftwareFX.ChartFX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using WindowsFormsApp1.Util;

namespace Investor
{
    public partial class FundamentalCharts : Form
    {
        public const int nYears = 7;
        public const int nQuarters = 8;
        BackgroundWorker backgroundWorker = new BackgroundWorker();
        public FundamentalCharts()
        {
            InitializeComponent();
            this.backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            DataTable dt = new DataTable();
            DataRow dr = null;
            string[,] info = new string[5, 3];

            for (int i = 0; i <= 3; i++)
            {
                dt.Columns.Add("");
            }

            info[0, 0] = "mktcap";
            info[0, 1] = "1234";
            info[1, 0] = "prcSales";
            info[1, 1] = "1234";
            info[2, 0] = "eps";
            info[2, 1] = "1234";
            info[3, 0] = "outshares";
            info[3, 1] = "1234";

            dr = dt.NewRow();
            dr[0] = info[0, 0];
            dr[1] = info[0, 1];
            dr[2] = info[3, 0];
            dr[3] = info[3, 1];

            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = info[1, 0];
            dr[1] = info[1, 1];

            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = info[2, 0];
            dr[1] = info[2, 1];

            dt.Rows.Add(dr);

            A_Stats.DataSource = dt;

            A_Stats.Width = dt.Columns.Count * A_Stats.Columns[0].Width;
            A_Stats.Height = dt.Rows.Count * A_Stats.Rows[0].Height;
            
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void SetChartTitle(Chart chart,string title)
        {
            chart.Titles.Add(new TitleDockable());
            chart.Titles[0].Text = title;
            chart.Titles[0].Font = new Font("Arial", 10);
            chart.Titles[0].Alignment = StringAlignment.Center;
        }

        public void ShowChart(string ticker)
        {
            ChartInfo charttinfo = new ChartInfo();

            // Gets data from database parallely
            List<Task<DataTable>> tasks = new List<Task<DataTable>>();

            tasks.Add(Task.Factory.StartNew(function: () => Database.GetValuesByTicker(ticker)));
            tasks.Add(Task.Factory.StartNew(function: () => Database.GetBalanaceSheet(ticker)));

            Task.WaitAll(tasks.ToArray());
            var dataTable = tasks[0].Result;
            var balanceData = tasks[1].Result;


            //create the chartview form
            //populate charts with data from the dataset
            DataRow[] selectedRows = null;
            DataRow[] balanceRows = balanceData.Select();
            //array of rows which will hold the row(s) selected
            //to store value of column

            //get the dataset row with the given ticker
            selectedRows = dataTable.Select();

            //   Start ChartForm ------------------------------------------------------------------------------------

            //set form title and label
            Text = ticker;

            //Plot Quarterly
            #region Q_PL
            Q_PL.OpenData(COD.Values, 7, 8);
            charttinfo.nSeries = 7;
            charttinfo.nvalues = 8;
            charttinfo.perend = "perend_q";
            charttinfo.colName[0] = "sales_q";
            charttinfo.colName[1] = "cgs_q";
            charttinfo.colName[2] = "opexp_q";
            charttinfo.colName[3] = "gopinc_q";
            charttinfo.colName[4] = "ebit_q";
            charttinfo.colName[5] = "nit_q";
            charttinfo.colName[6] = "netinc_q";
            charttinfo.LineStyles.Insert(0, new LineStyle(Color.Green, DashStyle.Solid));
            charttinfo.LineStyles.Insert(1, new LineStyle(Color.Red, DashStyle.Solid));
            charttinfo.LineStyles.Insert(2, new LineStyle(Color.IndianRed, DashStyle.Dash));
            charttinfo.LineStyles.Insert(3, new LineStyle(Color.Blue, DashStyle.Solid));
            charttinfo.LineStyles.Insert(4, new LineStyle(Color.OrangeRed, DashStyle.DashDot));
            charttinfo.LineStyles.Insert(5, new LineStyle(Color.Maroon, DashStyle.DashDotDot));
            charttinfo.LineStyles.Insert(6, new LineStyle(Color.Blue, DashStyle.Dash));
            charttinfo.legend[0] = "Sales";
            charttinfo.legend[1] = "CGS";
            charttinfo.legend[2] = "OpExp";
            charttinfo.legend[3] = "OpInc";
            charttinfo.legend[4] = "EBIT";
            charttinfo.legend[5] = "NonRec";
            charttinfo.legend[6] = "NetInc";
            PlotChart(selectedRows, Q_PL, charttinfo);
            SetChartTitle(Q_PL, "Quarterly - PL");
            Q_PL.CloseData(COD.Values);
            #endregion
            //Plot Annual
            #region Annual_PL
            charttinfo = new ChartInfo();
            Annual_PL.OpenData(COD.Values, 7, 7);
            charttinfo.nSeries = 7;
            charttinfo.nvalues = 7;
            charttinfo.perend = "perend_y";
            charttinfo.colName[0] = "sales_y";
            charttinfo.colName[1] = "cgs_y";
            charttinfo.colName[2] = "opexp_y";
            charttinfo.colName[3] = "gopinc_y";
            charttinfo.colName[4] = "ebit_y";
            charttinfo.colName[5] = "nit_y";
            charttinfo.colName[6] = "netinc_y";
            charttinfo.LineStyles.Insert(0, new LineStyle(Color.Green, DashStyle.Solid));
            charttinfo.LineStyles.Insert(1, new LineStyle(Color.Red, DashStyle.Solid));
            charttinfo.LineStyles.Insert(2, new LineStyle(Color.IndianRed, DashStyle.Dash));
            charttinfo.LineStyles.Insert(3, new LineStyle(Color.DarkBlue, DashStyle.Solid));
            charttinfo.LineStyles.Insert(4, new LineStyle(Color.Blue, DashStyle.DashDot));
            charttinfo.LineStyles.Insert(5, new LineStyle(Color.Maroon, DashStyle.DashDotDot));
            charttinfo.LineStyles.Insert(6, new LineStyle(Color.Blue, DashStyle.Dash));
            charttinfo.legend[0] = "Sales";
            charttinfo.legend[1] = "CGS";
            charttinfo.legend[2] = "OpExp";
            charttinfo.legend[3] = "OpInc";
            charttinfo.legend[4] = "EBIT";
            charttinfo.legend[5] = "NonRec";
            charttinfo.legend[6] = "NetInc";
            PlotChart(selectedRows, Annual_PL, charttinfo);
            SetChartTitle(Annual_PL, "Annual - PL");
            #endregion

            //Plot Annual Expenses
            #region A_EXP
            charttinfo = new ChartInfo();
            A_Exp.OpenData(COD.Values, 7, 7);
            charttinfo.nSeries = 7;
            charttinfo.nvalues = 7;
            charttinfo.perend = "perend_y";
            charttinfo.colName[0] = "dep_y";
            charttinfo.colName[1] = "rd_y";
            charttinfo.colName[2] = "int_y";
            charttinfo.colName[3] = "uninc_y";
            charttinfo.colName[4] = "othinc_y";
            charttinfo.colName[5] = "intno_y";
            charttinfo.colName[6] = "adjust_y";
            charttinfo.LineStyles.Insert(0, new LineStyle(ColorTranslator.FromHtml("#ff0000"), DashStyle.Solid));
            charttinfo.LineStyles.Insert(1, new LineStyle(ColorTranslator.FromHtml("#990000"), DashStyle.Dash));
            charttinfo.LineStyles.Insert(2, new LineStyle(ColorTranslator.FromHtml("#e60000"), DashStyle.Dot));
            charttinfo.LineStyles.Insert(3, new LineStyle(ColorTranslator.FromHtml("#ff3333"), DashStyle.DashDot));
            charttinfo.LineStyles.Insert(4, new LineStyle(ColorTranslator.FromHtml("#1b4b1c"), DashStyle.Solid));
            charttinfo.LineStyles.Insert(5, new LineStyle(ColorTranslator.FromHtml("#236526"), DashStyle.Dash));
            charttinfo.LineStyles.Insert(6, new LineStyle(ColorTranslator.FromHtml("#0033cc"), DashStyle.Solid));
            charttinfo.legend[0] = "dep";
            charttinfo.legend[1] = "rd";
            charttinfo.legend[2] = "intExp";
            charttinfo.legend[3] = "unExp";
            charttinfo.legend[4] = "otExp";
            charttinfo.legend[5] = "intNo";
            charttinfo.legend[6] = "adj";
            PlotChart(selectedRows, A_Exp, charttinfo);
            SetChartTitle(A_Exp, "Annual - Expenses");
            A_Exp.CloseData(COD.Values);
            #endregion

            //Plot Quarterly Expenses
            #region Q_EXP
            charttinfo = new ChartInfo();
            Q_Exp.OpenData(COD.Values, 7, 8);
            charttinfo.nSeries = 7;
            charttinfo.nvalues = 8;
            charttinfo.perend = "perend_q";
            charttinfo.colName[0] = "eps_q";
            charttinfo.colName[1] = "epscon_q";
            charttinfo.colName[2] = "epsd_q";
            charttinfo.colName[3] = "epsdc_q";
            charttinfo.colName[4] = "epsnd_q";
            charttinfo.colName[5] = "dps_q";
            charttinfo.colName[6] = "dpst_q";
            charttinfo.LineStyles.Insert(0, new LineStyle(Color.Green, DashStyle.Solid));
            charttinfo.LineStyles.Insert(1, new LineStyle(Color.Red, DashStyle.Solid));
            charttinfo.LineStyles.Insert(2, new LineStyle(Color.IndianRed, DashStyle.Dash));
            charttinfo.LineStyles.Insert(3, new LineStyle(Color.Blue, DashStyle.Solid));
            charttinfo.LineStyles.Insert(4, new LineStyle(Color.OrangeRed, DashStyle.DashDot));
            charttinfo.LineStyles.Insert(5, new LineStyle(Color.Maroon, DashStyle.DashDotDot));
            charttinfo.LineStyles.Insert(6, new LineStyle(Color.Blue, DashStyle.Dash));
            charttinfo.legend[0] = "eps";
            charttinfo.legend[1] = "epsC";
            charttinfo.legend[2] = "epsD";
            charttinfo.legend[3] = "espDC";
            charttinfo.legend[4] = "espDN";
            charttinfo.legend[5] = "divT";
            charttinfo.legend[6] = "divNS";
            PlotChart(selectedRows, Q_Exp, charttinfo);
            SetChartTitle(Q_Exp, "Quarterly - Expenses");
            Q_Exp.CloseData(COD.Values);
            #endregion

            //Plot Annual EPS
            #region A_EPS
            charttinfo = new ChartInfo();
            A_EPS.OpenData(COD.Values, 7, 7);
            charttinfo.nSeries = 7;
            charttinfo.nvalues = 7;
            charttinfo.perend = "perend_y";
            charttinfo.colName[0] = "eps_y";
            charttinfo.colName[1] = "epscon_y";
            charttinfo.colName[2] = "epsd_y";
            charttinfo.colName[3] = "epsdc_y";
            charttinfo.colName[4] = "epsnd_y";
            charttinfo.colName[5] = "dps_y";
            charttinfo.colName[6] = "dpst_y";
            charttinfo.LineStyles.Insert(0, new LineStyle(ColorTranslator.FromHtml("#236526"), DashStyle.Solid));
            charttinfo.LineStyles.Insert(1, new LineStyle(ColorTranslator.FromHtml("#37963C"), DashStyle.Dash));
            charttinfo.LineStyles.Insert(2, new LineStyle(ColorTranslator.FromHtml("#46C24C"), DashStyle.Dot));
            charttinfo.LineStyles.Insert(3, new LineStyle(ColorTranslator.FromHtml("#51DF58"), DashStyle.DashDot));
            charttinfo.LineStyles.Insert(4, new LineStyle(ColorTranslator.FromHtml("#60FF7A"), DashStyle.DashDotDot));
            charttinfo.LineStyles.Insert(5, new LineStyle(ColorTranslator.FromHtml("#2F31FD"), DashStyle.Solid));
            charttinfo.LineStyles.Insert(6, new LineStyle(ColorTranslator.FromHtml("#2FC8FD"), DashStyle.Dash));
            charttinfo.legend[0] = "eps";
            charttinfo.legend[1] = "epsC";
            charttinfo.legend[2] = "epsD";
            charttinfo.legend[3] = "espDC";
            charttinfo.legend[4] = "espDN";
            charttinfo.legend[5] = "divT";
            charttinfo.legend[6] = "divNS";
            PlotChart(selectedRows, A_EPS, charttinfo);
            SetChartTitle(A_EPS, "Annual - EPS");
            A_EPS.CloseData(COD.Values);
            #endregion

            //Plot Quarterly EPS
            #region Q_EPS
            charttinfo = new ChartInfo();
            Q_EPS.OpenData(COD.Values, 7, 8);
            charttinfo.nSeries = 7;
            charttinfo.nvalues = 8;
            charttinfo.perend = "perend_Q";
            charttinfo.colName[0] = "eps_q";
            charttinfo.colName[1] = "epscon_q";
            charttinfo.colName[2] = "epsd_q";
            charttinfo.colName[3] = "epsdc_q";
            charttinfo.colName[4] = "epsnd_q";
            charttinfo.colName[5] = "dps_q";
            charttinfo.colName[6] = "dpst_q";
            charttinfo.LineStyles.Insert(0, new LineStyle(Color.Green, DashStyle.Solid));
            charttinfo.LineStyles.Insert(1, new LineStyle(Color.Red, DashStyle.Solid));
            charttinfo.LineStyles.Insert(2, new LineStyle(Color.IndianRed, DashStyle.Dash));
            charttinfo.LineStyles.Insert(3, new LineStyle(Color.Blue, DashStyle.Solid));
            charttinfo.LineStyles.Insert(4, new LineStyle(Color.OrangeRed, DashStyle.DashDot));
            charttinfo.LineStyles.Insert(5, new LineStyle(Color.Maroon, DashStyle.DashDotDot));
            charttinfo.LineStyles.Insert(6, new LineStyle(Color.Blue, DashStyle.Dash));
            charttinfo.legend[0] = "eps";
            charttinfo.legend[1] = "epsC";
            charttinfo.legend[2] = "epsD";
            charttinfo.legend[3] = "espDC";
            charttinfo.legend[4] = "espDN";
            charttinfo.legend[5] = "divT";
            charttinfo.legend[6] = "divNS";
            PlotChart(selectedRows, Q_EPS, charttinfo);
            SetChartTitle(Q_EPS, "Quarterly - EPS");
            Q_EPS.CloseData(COD.Values);
            #endregion

            //Plot annual CFL
            #region A_CF
            charttinfo = new ChartInfo();
            A_CF.OpenData(COD.Values, 7, 7);
            charttinfo.nSeries = 7;
            charttinfo.nvalues = 7;
            charttinfo.perend = "perend_y";
            charttinfo.colName[0] = "tco_y";
            charttinfo.colName[1] = "tci_y";
            charttinfo.colName[2] = "tcf_y";
            charttinfo.colName[3] = "dep_cf_y";
            charttinfo.colName[4] = "ce_y";
            charttinfo.colName[5] = "cfps_y";
            charttinfo.colName[6] = "fcfps_y";
            charttinfo.LineStyles.Insert(0, new LineStyle(Color.Green, DashStyle.Solid));
            charttinfo.LineStyles.Insert(1, new LineStyle(Color.Red, DashStyle.Solid));
            charttinfo.LineStyles.Insert(2, new LineStyle(Color.IndianRed, DashStyle.Dash));
            charttinfo.LineStyles.Insert(3, new LineStyle(Color.Blue, DashStyle.Solid));
            charttinfo.LineStyles.Insert(4, new LineStyle(Color.OrangeRed, DashStyle.DashDot));
            charttinfo.LineStyles.Insert(5, new LineStyle(Color.Maroon, DashStyle.DashDotDot));
            charttinfo.LineStyles.Insert(6, new LineStyle(Color.Blue, DashStyle.Dash));
            charttinfo.legend[0] = "tco";
            charttinfo.legend[1] = "tci";
            charttinfo.legend[2] = "tcf";
            charttinfo.legend[3] = "dep";
            charttinfo.legend[4] = "ce";
            charttinfo.legend[5] = "cfps";
            charttinfo.legend[6] = "fcfps";
            PlotChart(selectedRows, A_CF, charttinfo);
            SetChartTitle(A_CF, "Annual - Cashflow");
            A_CF.CloseData(COD.Values);
            #endregion

            //Plot Quarterly CFL
            #region Q_CFL
            charttinfo = new ChartInfo();
            Q_CFL.OpenData(COD.Values, 7, 8);
            charttinfo.nSeries = 7;
            charttinfo.nvalues = 8;
            charttinfo.perend = "perend_Q";
            charttinfo.colName[0] = "tco_q";
            charttinfo.colName[1] = "tci_q";
            charttinfo.colName[2] = "tcf_q";
            charttinfo.colName[3] = "dep_cf_q";
            charttinfo.colName[4] = "ce_q";
            charttinfo.colName[5] = "cfps_q";
            charttinfo.colName[6] = "fcfps_q";
            charttinfo.LineStyles.Insert(0, new LineStyle(Color.Green, DashStyle.Solid));
            charttinfo.LineStyles.Insert(1, new LineStyle(Color.Red, DashStyle.Solid));
            charttinfo.LineStyles.Insert(2, new LineStyle(Color.IndianRed, DashStyle.Dash));
            charttinfo.LineStyles.Insert(3, new LineStyle(Color.Blue, DashStyle.Solid));
            charttinfo.LineStyles.Insert(4, new LineStyle(Color.OrangeRed, DashStyle.DashDot));
            charttinfo.LineStyles.Insert(5, new LineStyle(Color.Maroon, DashStyle.DashDotDot));
            charttinfo.LineStyles.Insert(6, new LineStyle(Color.Blue, DashStyle.Dash));
            charttinfo.legend[0] = "tco";
            charttinfo.legend[1] = "tci";
            charttinfo.legend[2] = "tcf";
            charttinfo.legend[3] = "dep";
            charttinfo.legend[4] = "ce";
            charttinfo.legend[5] = "cfps";
            charttinfo.legend[6] = "fcfps";
            PlotChart(selectedRows, Q_CFL, charttinfo);
            SetChartTitle(Q_CFL, "Quarterly - Cashflow");
            Q_CFL.CloseData(COD.Values);
            #endregion

            //Plot Annual Assets
            #region A_Ast
            ChartInfo astInfo = new ChartInfo();
            A_Ast.OpenData(COD.Values, 5, 7);
            astInfo.nSeries = 5;
            astInfo.nvalues = 7;
            astInfo.perend = "perend_y";
            astInfo.colName[0] = "cash_y";
            astInfo.colName[1] = "stinv_y";
            astInfo.colName[2] = "ar_y";
            astInfo.colName[3] = "inv_y";
            astInfo.colName[4] = "oca_y";
            astInfo.LineStyles.Insert(0, new LineStyle(Color.Black, DashStyle.Solid));
            astInfo.LineStyles.Insert(1, new LineStyle(Color.Red, DashStyle.Solid));
            astInfo.LineStyles.Insert(2, new LineStyle(Color.Green, DashStyle.Solid));
            astInfo.LineStyles.Insert(3, new LineStyle(Color.Blue, DashStyle.Solid));
            astInfo.LineStyles.Insert(4, new LineStyle(Color.Orange, DashStyle.Solid));
            astInfo.legend[0] = "cash";
            astInfo.legend[1] = "stInv";
            astInfo.legend[2] = "AccRcv";
            astInfo.legend[3] = "Inv";
            astInfo.legend[4] = "curAst";
            Task.Factory.StartNew(() => PlotChart(balanceRows, A_Ast, astInfo));
            SetChartTitle(A_Ast, "Annual - Asset");
            A_Ast.CloseData(COD.Values);
            #endregion

            //Plot Annual Assets - Long term
            #region A_LT
            ChartInfo ltInfo = new ChartInfo();
            A_LT.OpenData(COD.Values, 4, 7);
            ltInfo.nSeries = 4;
            ltInfo.nvalues = 7;
            ltInfo.perend = "perend_y";
            ltInfo.colName[0] = "nppe_y";
            ltInfo.colName[1] = "ltinv_y";
            ltInfo.colName[2] = "gwi_y";
            ltInfo.colName[3] = "olta_y";
            ltInfo.LineStyles.Insert(0, new LineStyle(Color.Black, DashStyle.Solid));
            ltInfo.LineStyles.Insert(1, new LineStyle(Color.Red, DashStyle.Solid));
            ltInfo.LineStyles.Insert(2, new LineStyle(Color.Green, DashStyle.Solid));
            ltInfo.LineStyles.Insert(3, new LineStyle(Color.Blue, DashStyle.Solid));
            ltInfo.legend[0] = "nppe";
            ltInfo.legend[1] = "longInv";
            ltInfo.legend[2] = "good";
            ltInfo.legend[3] = "longAst";
            Task.Factory.StartNew(() => PlotChart(balanceRows, A_LT, ltInfo));
            SetChartTitle(A_LT, "Annual - Asset(Long Term)");
            A_LT.CloseData(COD.Values);
            #endregion

            //Plot Annual Liability
            #region A_Liab
            ChartInfo liabInfo = new ChartInfo();
            A_Liab.OpenData(COD.Values, 5, 7);
            liabInfo.nSeries = 5;
            liabInfo.nvalues = 7;
            liabInfo.perend = "perend_y";
            liabInfo.colName[0] = "ap_y";
            liabInfo.colName[1] = "stdebt_y";
            liabInfo.colName[2] = "ocl_y";
            liabInfo.colName[3] = "ltdebt_y";
            liabInfo.colName[4] = "oltl_y";
            //liabInfo.colName[5] = "pref_y";
            //liabInfo.colName[6] = "retearn_y";
            //liabInfo.colName[7] = "equity_y";
            liabInfo.LineStyles.Insert(0, new LineStyle(ColorTranslator.FromHtml("#1b4b1c"), DashStyle.Solid));
            liabInfo.LineStyles.Insert(1, new LineStyle(ColorTranslator.FromHtml("#236526"), DashStyle.Dash));
            liabInfo.LineStyles.Insert(2, new LineStyle(ColorTranslator.FromHtml("#37963C"), DashStyle.Dot));
            liabInfo.LineStyles.Insert(3, new LineStyle(ColorTranslator.FromHtml("#ff0000"), DashStyle.Solid));
            liabInfo.LineStyles.Insert(4, new LineStyle(ColorTranslator.FromHtml("#e60000"), DashStyle.Dash));
            //liabInfo.LineStyles.Insert(5, new LineStyle(ColorTranslator.FromHtml("#002080"), DashStyle.Solid));
            //liabInfo.LineStyles.Insert(6, new LineStyle(ColorTranslator.FromHtml("#0033cc"), DashStyle.Dash));
            //liabInfo.LineStyles.Insert(7, new LineStyle(ColorTranslator.FromHtml("#1a53ff"), DashStyle.Dot));
            liabInfo.legend[0] = "accPy";
            liabInfo.legend[1] = "stDbt";
            liabInfo.legend[2] = "otCrLi";
            liabInfo.legend[3] = "ltDbt";
            liabInfo.legend[4] = "otLtLi";
            //liabInfo.legend[5] = "prefSt";
            //liabInfo.legend[6] = "retEa";
            //liabInfo.legend[7] = "csEq";
            Task.Factory.StartNew(() => PlotChart(balanceRows, A_Liab, liabInfo));
            SetChartTitle(A_Liab, "Annual - Liability");
            A_Liab.CloseData(COD.Values);
            #endregion


            //Plot Annual Liability
            #region A_Eqt
            ChartInfo eqtInfo = new ChartInfo();
            A_Eqt.OpenData(COD.Values, 4, 7);
            eqtInfo.nSeries = 4;
            eqtInfo.nvalues = 7;
            eqtInfo.perend = "perend_y";
            eqtInfo.colName[0] = "pref_y";
            eqtInfo.colName[1] = "retearn_y";
            eqtInfo.colName[2] = "equity_y"; 
            eqtInfo.colName[3] = "minor_y";
            eqtInfo.LineStyles.Insert(0, new LineStyle(ColorTranslator.FromHtml("#ff0000"), DashStyle.Solid));
            eqtInfo.LineStyles.Insert(1, new LineStyle(ColorTranslator.FromHtml("#e60000"), DashStyle.Dash));
            eqtInfo.LineStyles.Insert(2, new LineStyle(ColorTranslator.FromHtml("#e60000"), DashStyle.Dot));
            eqtInfo.LineStyles.Insert(3, new LineStyle(ColorTranslator.FromHtml("#ff3333"), DashStyle.DashDot));
            //eqtInfo.LineStyles.Insert(5, new LineStyle(ColorTranslator.FromHtml("#002080"), DashStyle.Solid));
            //eqtInfo.LineStyles.Insert(6, new LineStyle(ColorTranslator.FromHtml("#0033cc"), DashStyle.Dash));
            //eqtInfo.LineStyles.Insert(7, new LineStyle(ColorTranslator.FromHtml("#1a53ff"), DashStyle.Dot));
            eqtInfo.legend[0] = "prefSt";
            eqtInfo.legend[1] = "retEa";
            eqtInfo.legend[2] = "csEq";
            eqtInfo.legend[3] = "minor";
            Task.Factory.StartNew(() => PlotChart(balanceRows, A_Eqt, eqtInfo));
            SetChartTitle(A_Eqt, "Annual - Equity");
            A_Eqt.CloseData(COD.Values);
            #endregion

            //Plot Annual Book Value
            #region A_Book
            ChartInfo aBookInfo = new ChartInfo();
            A_Book.OpenData(COD.Values, 1, 7);
            aBookInfo.nSeries = 1;
            aBookInfo.nvalues = 7;
            aBookInfo.perend = "perend_y";
            aBookInfo.colName[0] = "bvps_y";
            aBookInfo.LineStyles.Insert(0, new LineStyle(ColorTranslator.FromHtml("#1b4b1c"), DashStyle.Solid));
            A_Book.LegendBox = false;
            Task.Factory.StartNew(() => PlotChart(balanceRows, A_Book, aBookInfo));
            SetChartTitle(A_Book, "Annual - Book Value");
            A_Book.SerLegBox = false;
            A_Book.CloseData(COD.Values);
            #endregion

        }

        private void PlotChart(DataRow[] selectedRows, Chart chart, ChartInfo charttinfo)
        {
            object item = null;
            int ii = 0;
            int iii = 0;
            int j = 0;
            
                ii = charttinfo.nvalues;
                iii = charttinfo.nSeries;
                j = 1;
            chart.BeginInvoke((MethodInvoker)delegate {
            //set x-axis labels
            for (int i = ii; i >= 1; i += -1)
                {
                    item = selectedRows[0][charttinfo.perend + i.ToString()];
                    if (((!object.ReferenceEquals(item, DBNull.Value)) && (!(i % 2 == 0))))
                    {
                    chart.AxisX.Label[0 + (ii - i)] = System.DateTime.Parse(item.ToString()).ToString("MM/yy");

                    }
                    else
                    {
                        chart.AxisX.Label[0 + (ii - i)] = "";
                    }
                }
                chart.AxisY.ForceZero = false;
                chart.AxisY.LabelsFormat.Format = AxisFormat.Currency;
                chart.AxisX.TickMark = TickMark.Outside;
                chart.AxisX.LabelAngle = 0;



                //charttinfo.nSeries Step -1 'charttinfo.nSeries - 1  ' 2 To 2  '1 To charttinfo.nSeries
                for (j = 0; j <= (iii - 1); j++)
                {
                    //quarterly totextp
                    for (int i = ii; i >= 1; i += -1)
                    {
                        //stringg = charttinfo.colName(j)
                        item = selectedRows[0][charttinfo.colName[j] + i.ToString()];
                        if (((!object.ReferenceEquals(item, DBNull.Value))))
                        {
                            
                        
                            // Running on the UI thread
                            chart.Value[j, 0 + (ii - i)] = Convert.ToDouble(item);
                        
                            //objwriter.Write(item);
                        }
                        else
                        {
                            //chart.Value[j, 0 + (ii - i)] =  null;
                        
                        }
                    }
                    chart.Series[j].Color = charttinfo.LineStyles[j].LineColor;
                    chart.Series[j].LineStyle = charttinfo.LineStyles[j].DashStyle;
                    chart.Series[j].Legend = charttinfo.legend[j];

            }
            });

        }

        private void A_Stats_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
