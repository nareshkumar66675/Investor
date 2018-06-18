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
        public FundamentalCharts()
        {
            InitializeComponent();
            
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

        public void SetChartTitle(Chart chart,string title)
        {
            chart.Titles.Add(new TitleDockable());
            chart.Titles[0].Text = title;
            chart.Titles[0].Font = new Font("Arial", 10);
            chart.Titles[0].Alignment = StringAlignment.Center;
        }

        public string[] ChangeColNameToQuart(string [] colNames)
        {
            List<string> resultCols = new List<string>();
            foreach (var col in colNames)
            {
                if(col != null)
                resultCols.Add(col.Replace("_y", "_q"));
            }
            return resultCols.ToArray();
        }
        public ChartInfo GetQuartChartInfo(ChartInfo chartInfo)
        {
            ChartInfo resultInfo = new ChartInfo();
            resultInfo.perend = "perend_q";
            resultInfo.LineStyles.AddRange(chartInfo.LineStyles);
            resultInfo.colName = ChangeColNameToQuart(chartInfo.colName);
            resultInfo.legend = chartInfo.legend.ToArray();
            resultInfo.nSeries = chartInfo.nSeries;
            resultInfo.nvalues = 8;

            return resultInfo;
        }

        public void ChartQuarterly(ChartInfo annualChartInfo, DataRow[] rows, Chart chart, string title)
        {
            var qChartInfo = GetQuartChartInfo(annualChartInfo);
            chart.OpenData(COD.Values, qChartInfo.nSeries, 7);
            Task.Factory.StartNew(() => PlotChart(rows, chart, qChartInfo));
            SetChartTitle(chart, title);
            chart.CloseData(COD.Values);
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

            //Plot PL 
            #region PL
            ChartInfo plInfo = new ChartInfo();
            Annual_PL.OpenData(COD.Values, 7, 7);
            plInfo.nSeries = 7;
            plInfo.nvalues = 7;
            plInfo.perend = "perend_y";
            plInfo.colName[0] = "sales_y";
            plInfo.colName[1] = "cgs_y";
            plInfo.colName[2] = "opexp_y";
            plInfo.colName[3] = "gopinc_y";
            plInfo.colName[4] = "ebit_y";
            plInfo.colName[5] = "nit_y";
            plInfo.colName[6] = "netinc_y";
            plInfo.LineStyles.Insert(0, new LineStyle(Color.Green, DashStyle.Solid));
            plInfo.LineStyles.Insert(1, new LineStyle(Color.Red, DashStyle.Solid));
            plInfo.LineStyles.Insert(2, new LineStyle(Color.IndianRed, DashStyle.Dash));
            plInfo.LineStyles.Insert(3, new LineStyle(Color.DarkBlue, DashStyle.Solid));
            plInfo.LineStyles.Insert(4, new LineStyle(Color.Blue, DashStyle.DashDot));
            plInfo.LineStyles.Insert(5, new LineStyle(Color.Maroon, DashStyle.DashDotDot));
            plInfo.LineStyles.Insert(6, new LineStyle(Color.Blue, DashStyle.Dash));
            plInfo.legend[0] = "Sales";
            plInfo.legend[1] = "CGS";
            plInfo.legend[2] = "OpExp";
            plInfo.legend[3] = "OpInc";
            plInfo.legend[4] = "EBIT";
            plInfo.legend[5] = "NonRec";
            plInfo.legend[6] = "NetInc";
            Task.Factory.StartNew(() => PlotChart(selectedRows, Annual_PL, plInfo));
            SetChartTitle(Annual_PL, "Annual - PL");

            ChartQuarterly(plInfo, selectedRows, Q_PL, "Quarterly - PL");
            #endregion

            //Plot Expenses
            #region EXP
            ChartInfo expInfo = new ChartInfo();
            A_Exp.OpenData(COD.Values, 7, 7);
            expInfo.nSeries = 7;
            expInfo.nvalues = 7;
            expInfo.perend = "perend_y";
            expInfo.colName[0] = "dep_y";
            expInfo.colName[1] = "rd_y";
            expInfo.colName[2] = "int_y";
            expInfo.colName[3] = "uninc_y";
            expInfo.colName[4] = "othinc_y";
            expInfo.colName[5] = "intno_y";
            expInfo.colName[6] = "adjust_y";
            expInfo.LineStyles.Insert(0, new LineStyle(ColorTranslator.FromHtml("#ff0000"), DashStyle.Solid));
            expInfo.LineStyles.Insert(1, new LineStyle(ColorTranslator.FromHtml("#990000"), DashStyle.Dash));
            expInfo.LineStyles.Insert(2, new LineStyle(ColorTranslator.FromHtml("#e60000"), DashStyle.Dot));
            expInfo.LineStyles.Insert(3, new LineStyle(ColorTranslator.FromHtml("#ff3333"), DashStyle.DashDot));
            expInfo.LineStyles.Insert(4, new LineStyle(ColorTranslator.FromHtml("#1b4b1c"), DashStyle.Solid));
            expInfo.LineStyles.Insert(5, new LineStyle(ColorTranslator.FromHtml("#236526"), DashStyle.Dash));
            expInfo.LineStyles.Insert(6, new LineStyle(ColorTranslator.FromHtml("#0033cc"), DashStyle.Solid));
            expInfo.legend[0] = "dep";
            expInfo.legend[1] = "rd";
            expInfo.legend[2] = "intExp";
            expInfo.legend[3] = "unExp";
            expInfo.legend[4] = "otExp";
            expInfo.legend[5] = "intNo";
            expInfo.legend[6] = "adj";
            Task.Factory.StartNew(() => PlotChart(selectedRows, A_Exp, expInfo));
            SetChartTitle(A_Exp, "Annual - Expenses");
            A_Exp.CloseData(COD.Values);

            ChartQuarterly(expInfo, selectedRows, Q_Exp, "Quarterly - Expenses");
            #endregion

            //Plot EPS
            #region EPS
            ChartInfo epsInfo = new ChartInfo();
            A_EPS.OpenData(COD.Values, 7, 7);
            epsInfo.nSeries = 7;
            epsInfo.nvalues = 7;
            epsInfo.perend = "perend_y";
            epsInfo.colName[0] = "eps_y";
            epsInfo.colName[1] = "epscon_y";
            epsInfo.colName[2] = "epsd_y";
            epsInfo.colName[3] = "epsdc_y";
            epsInfo.colName[4] = "epsnd_y";
            epsInfo.colName[5] = "dps_y";
            epsInfo.colName[6] = "dpst_y";
            epsInfo.LineStyles.Insert(0, new LineStyle(ColorTranslator.FromHtml("#236526"), DashStyle.Solid));
            epsInfo.LineStyles.Insert(1, new LineStyle(ColorTranslator.FromHtml("#37963C"), DashStyle.Dash));
            epsInfo.LineStyles.Insert(2, new LineStyle(ColorTranslator.FromHtml("#46C24C"), DashStyle.Dot));
            epsInfo.LineStyles.Insert(3, new LineStyle(ColorTranslator.FromHtml("#51DF58"), DashStyle.DashDot));
            epsInfo.LineStyles.Insert(4, new LineStyle(ColorTranslator.FromHtml("#60FF7A"), DashStyle.DashDotDot));
            epsInfo.LineStyles.Insert(5, new LineStyle(ColorTranslator.FromHtml("#2F31FD"), DashStyle.Solid));
            epsInfo.LineStyles.Insert(6, new LineStyle(ColorTranslator.FromHtml("#2FC8FD"), DashStyle.Dash));
            epsInfo.legend[0] = "eps";
            epsInfo.legend[1] = "epsC";
            epsInfo.legend[2] = "epsD";
            epsInfo.legend[3] = "espDC";
            epsInfo.legend[4] = "espDN";
            epsInfo.legend[5] = "divT";
            epsInfo.legend[6] = "divNS";
            Task.Factory.StartNew(() => PlotChart(selectedRows, A_EPS, epsInfo));
            SetChartTitle(A_EPS, "Annual - EPS");
            A_EPS.CloseData(COD.Values);

            ChartQuarterly(epsInfo, selectedRows, Q_EPS, "Quarterly - EPS");
            #endregion

            //Plot CFL
            #region CF
            ChartInfo cfInfo = new ChartInfo();
            A_CF.OpenData(COD.Values, 3, 7);
            cfInfo.nSeries = 3;
            cfInfo.nvalues = 7;
            cfInfo.perend = "perend_y";
            cfInfo.colName[0] = "tco_y";
            cfInfo.colName[1] = "tci_y";
            cfInfo.colName[2] = "tcf_y";
            cfInfo.LineStyles.Insert(0, new LineStyle(Color.Black, DashStyle.Solid));
            cfInfo.LineStyles.Insert(1, new LineStyle(Color.Red, DashStyle.Solid));
            cfInfo.LineStyles.Insert(2, new LineStyle(Color.Green, DashStyle.Solid));
            cfInfo.legend[0] = "tco";
            cfInfo.legend[1] = "tci";
            cfInfo.legend[2] = "tcf";
            Task.Factory.StartNew(() => PlotChart(selectedRows, A_CF, cfInfo));
            SetChartTitle(A_CF, "Annual - Cashflow");
            A_CF.CloseData(COD.Values);

            ChartQuarterly(cfInfo, selectedRows, Q_CFL, "Quarterly - Cashflow");
            #endregion

            //Plot CFL 2
            #region CF2
            ChartInfo cf2Info = new ChartInfo();
            A_CF2.OpenData(COD.Values, 4, 7);
            cf2Info.nSeries = 4;
            cf2Info.nvalues = 7;
            cf2Info.perend = "perend_y";
            cf2Info.colName[0] = "dep_cf_y";
            cf2Info.colName[1] = "ce_y";
            cf2Info.colName[2] = "divpaid_y";
            cf2Info.colName[3] = "ere_y";
            cf2Info.LineStyles.Insert(0, new LineStyle(Color.Black, DashStyle.Solid));
            cf2Info.LineStyles.Insert(1, new LineStyle(Color.Red, DashStyle.Solid));
            cf2Info.LineStyles.Insert(2, new LineStyle(Color.Green, DashStyle.Solid));
            cf2Info.LineStyles.Insert(3, new LineStyle(Color.Blue, DashStyle.Solid));
            cf2Info.legend[0] = "dep";
            cf2Info.legend[1] = "ce";
            cf2Info.legend[2] = "div";
            cf2Info.legend[3] = "ere";
            Task.Factory.StartNew(() => PlotChart(selectedRows, A_CF2, cf2Info));
            SetChartTitle(A_CF2, "Annual - Cashflow 2");
            A_CF2.CloseData(COD.Values);

            ChartQuarterly(cf2Info, selectedRows, Q_CF2, "Quarterly - Cashflow 2");
            #endregion

            //Plot CFL 3
            #region CF3
            ChartInfo cf3Info = new ChartInfo();
            A_CF3.OpenData(COD.Values, 2, 7);
            cf3Info.nSeries = 2;
            cf3Info.nvalues = 7;
            cf3Info.perend = "perend_y";
            cf3Info.colName[0] = "cfps_y";
            cf3Info.colName[1] = "fcfps_y";
            cf3Info.LineStyles.Insert(0, new LineStyle(Color.Blue, DashStyle.Solid));
            cf3Info.LineStyles.Insert(1, new LineStyle(Color.Green, DashStyle.Solid));
            cf3Info.legend[0] = "cfps";
            cf3Info.legend[1] = "fcfps";
            Task.Factory.StartNew(() => PlotChart(selectedRows, A_CF3, cf3Info));
            SetChartTitle(A_CF3, "Annual - Cashflow 3");
            A_CF3.CloseData(COD.Values);

            ChartQuarterly(cf3Info, selectedRows, Q_CF3, "Quarterly - Cashflow 3");
            #endregion

            //Plot Assets
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

            ChartQuarterly(astInfo, balanceRows, Q_Ast, "Quarterly - Asset");
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

            ChartQuarterly(ltInfo, balanceRows, Q_LT, "Quarterly - Asset(Long Term)");
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
            liabInfo.LineStyles.Insert(0, new LineStyle(ColorTranslator.FromHtml("#1b4b1c"), DashStyle.Solid));
            liabInfo.LineStyles.Insert(1, new LineStyle(ColorTranslator.FromHtml("#236526"), DashStyle.Dash));
            liabInfo.LineStyles.Insert(2, new LineStyle(ColorTranslator.FromHtml("#37963C"), DashStyle.Dot));
            liabInfo.LineStyles.Insert(3, new LineStyle(ColorTranslator.FromHtml("#ff0000"), DashStyle.Solid));
            liabInfo.LineStyles.Insert(4, new LineStyle(ColorTranslator.FromHtml("#e60000"), DashStyle.Dash));
            liabInfo.legend[0] = "accPy";
            liabInfo.legend[1] = "stDbt";
            liabInfo.legend[2] = "otCrLi";
            liabInfo.legend[3] = "ltDbt";
            liabInfo.legend[4] = "otLtLi";
            Task.Factory.StartNew(() => PlotChart(balanceRows, A_Liab, liabInfo));
            SetChartTitle(A_Liab, "Annual - Liability");
            A_Liab.CloseData(COD.Values);

            ChartQuarterly(liabInfo, balanceRows, Q_Liab, "Quarterly - Liability");
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
            eqtInfo.legend[0] = "prefSt";
            eqtInfo.legend[1] = "retEa";
            eqtInfo.legend[2] = "csEq";
            eqtInfo.legend[3] = "minor";
            Task.Factory.StartNew(() => PlotChart(balanceRows, A_Eqt, eqtInfo));
            SetChartTitle(A_Eqt, "Annual - Equity");
            A_Eqt.CloseData(COD.Values);

            ChartQuarterly(eqtInfo, balanceRows, Q_Eqt, "Quarterly - Equity");
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

            ChartQuarterly(aBookInfo, balanceRows, Q_Book, "Quarterly - Book Value");
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

        private void chart1_Load(object sender, EventArgs e)
        {

        }

    }
}
