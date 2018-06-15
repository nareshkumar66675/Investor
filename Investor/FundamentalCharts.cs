using Investor.Util;
using SoftwareFX.ChartFX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            chart.Titles[0].Font = new Font("Arial", 12);
            chart.Titles[0].Alignment = StringAlignment.Center;
        }

        public void ShowChart(string ticker)
        {
            ChartInfo charttinfo = new ChartInfo();
            charttinfo.colName = new string[12];
            charttinfo.legend = new string[12];
            charttinfo.rgb = new int[12, 4];

            var dataTable = Database.GetValuesByTicker(ticker);

            //create the chartview form
            //populate charts with data from the dataset
            DataRow[] selectedRows = null;
            //array of rows which will hold the row(s) selected
            //to store value of column
            object item = null;

            //get the dataset row with the given ticker
            selectedRows = dataTable.Select();

            //   Start ChartForm ------------------------------------------------------------------------------------

            //set form title and label
            Text = ticker;

            //Plot Quarterly
            #region Q_PL
            charttinfo.nSeries = 5;
            charttinfo.nvalues = 8;
            charttinfo.perend = "perend_q";
            charttinfo.colName[0] = "sales_q";
            charttinfo.colName[1] = "cgs_q";
            charttinfo.colName[2] = "totexp_q";
            charttinfo.colName[3] = "ebit_q";
            charttinfo.colName[4] = "netinc_q";
            charttinfo.rgb[0, 0] = 255;
            charttinfo.rgb[0, 1] = 0;
            charttinfo.rgb[0, 2] = 255;
            charttinfo.rgb[0, 3] = 0;
            charttinfo.rgb[1, 0] = 50;
            charttinfo.rgb[1, 1] = 255;
            charttinfo.rgb[1, 2] = 0;
            charttinfo.rgb[1, 3] = 0;
            charttinfo.rgb[2, 0] = 255;
            charttinfo.rgb[2, 1] = 255;
            charttinfo.rgb[2, 2] = 0;
            charttinfo.rgb[2, 3] = 0;
            charttinfo.rgb[3, 0] = 50;
            charttinfo.rgb[3, 1] = 0;
            charttinfo.rgb[3, 2] = 0;
            charttinfo.rgb[3, 3] = 255;
            charttinfo.rgb[4, 0] = 255;
            charttinfo.rgb[4, 1] = 0;
            charttinfo.rgb[4, 2] = 0;
            charttinfo.rgb[4, 3] = 255;
            charttinfo.legend[0] = "Sales";
            charttinfo.legend[1] = "CGS";
            charttinfo.legend[2] = "OpExp";
            charttinfo.legend[3] = "EBIT";
            charttinfo.legend[4] = "NetInc";
            PlotChart(selectedRows, Q_PL, charttinfo);
            SetChartTitle(Q_PL, "Quarterly - PL");
            Q_PL.CloseData(COD.Values);
            #endregion
            //Plot Annual
            #region A_PL
            charttinfo.nSeries = 5;
            charttinfo.nvalues = 7;
            charttinfo.perend = "perend_y";
            charttinfo.colName[0] = "sales_y";
            charttinfo.colName[1] = "cgs_y";
            charttinfo.colName[2] = "totexp_y";
            charttinfo.colName[3] = "ebit_y";
            charttinfo.colName[4] = "netinc_y";
            charttinfo.rgb[0, 0] = 255;
            charttinfo.rgb[0, 1] = 0;
            charttinfo.rgb[0, 2] = 255;
            charttinfo.rgb[0, 3] = 0;
            charttinfo.rgb[1, 0] = 50;
            charttinfo.rgb[1, 1] = 255;
            charttinfo.rgb[1, 2] = 0;
            charttinfo.rgb[1, 3] = 0;
            charttinfo.rgb[2, 0] = 255;
            charttinfo.rgb[2, 1] = 255;
            charttinfo.rgb[2, 2] = 0;
            charttinfo.rgb[2, 3] = 0;
            charttinfo.rgb[3, 0] = 50;
            charttinfo.rgb[3, 1] = 0;
            charttinfo.rgb[3, 2] = 0;
            charttinfo.rgb[3, 3] = 255;
            charttinfo.rgb[4, 0] = 255;
            charttinfo.rgb[4, 1] = 0;
            charttinfo.rgb[4, 2] = 0;
            charttinfo.rgb[4, 3] = 255;
            charttinfo.legend[0] = "Sales";
            charttinfo.legend[1] = "CGS";
            charttinfo.legend[2] = "OpExp";
            charttinfo.legend[3] = "EBIT";
            charttinfo.legend[4] = "NetInc";
            PlotChart(selectedRows, Annual_PL, charttinfo);
            SetChartTitle(Annual_PL, "Annual - PL");
            #endregion

            //Plot Annual Expenses
            #region A_EXP
            A_Exp.OpenData(COD.Values, 10, 7);
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
            charttinfo.rgb[0, 0] = 255;
            charttinfo.rgb[0, 1] = 4;
            charttinfo.rgb[0, 2] = 114;
            charttinfo.rgb[0, 3] = 30;
            charttinfo.rgb[1, 0] = 50;
            charttinfo.rgb[1, 1] = 7;
            charttinfo.rgb[1, 2] = 177;
            charttinfo.rgb[1, 3] = 47;
            charttinfo.rgb[2, 0] = 255;
            charttinfo.rgb[2, 1] = 10;
            charttinfo.rgb[2, 2] = 246;
            charttinfo.rgb[2, 3] = 66;
            charttinfo.rgb[3, 0] = 50;
            charttinfo.rgb[3, 1] = 59;
            charttinfo.rgb[3, 2] = 247;
            charttinfo.rgb[3, 3] = 104;
            charttinfo.rgb[4, 0] = 255;
            charttinfo.rgb[4, 1] = 130;
            charttinfo.rgb[4, 2] = 250;
            charttinfo.rgb[4, 3] = 159;
            charttinfo.rgb[5, 0] = 50;
            charttinfo.rgb[5, 1] = 0;
            charttinfo.rgb[5, 2] = 0;
            charttinfo.rgb[5, 3] = 255;
            charttinfo.rgb[6, 0] = 255;
            charttinfo.rgb[6, 1] = 48;
            charttinfo.rgb[6, 2] = 142;
            charttinfo.rgb[6, 3] = 206;
            charttinfo.legend[0] = "eps";
            charttinfo.legend[1] = "epsC";
            charttinfo.legend[2] = "epsD";
            charttinfo.legend[3] = "espDC";
            charttinfo.legend[4] = "espDN";
            charttinfo.legend[5] = "divT";
            charttinfo.legend[6] = "divNS";
            PlotChart(selectedRows, A_Exp, charttinfo);
            SetChartTitle(A_Exp, "Annual - Expenses");
            A_Exp.CloseData(COD.Values);
            #endregion

            //Plot Quarterly Expenses
            #region Q_EXP
            Q_Exp.OpenData(COD.Values, 7, 7);
            charttinfo.nSeries = 7;
            charttinfo.nvalues = 7;
            charttinfo.perend = "perend_q";
            charttinfo.colName[0] = "eps_q";
            charttinfo.colName[1] = "epscon_q";
            charttinfo.colName[2] = "epsd_q";
            charttinfo.colName[3] = "epsdc_q";
            charttinfo.colName[4] = "epsnd_q";
            charttinfo.colName[5] = "dps_q";
            charttinfo.colName[6] = "dpst_q";
            charttinfo.rgb[0, 0] = 255;
            charttinfo.rgb[0, 1] = 4;
            charttinfo.rgb[0, 2] = 114;
            charttinfo.rgb[0, 3] = 30;
            charttinfo.rgb[1, 0] = 50;
            charttinfo.rgb[1, 1] = 7;
            charttinfo.rgb[1, 2] = 177;
            charttinfo.rgb[1, 3] = 47;
            charttinfo.rgb[2, 0] = 255;
            charttinfo.rgb[2, 1] = 10;
            charttinfo.rgb[2, 2] = 246;
            charttinfo.rgb[2, 3] = 66;
            charttinfo.rgb[3, 0] = 50;
            charttinfo.rgb[3, 1] = 59;
            charttinfo.rgb[3, 2] = 247;
            charttinfo.rgb[3, 3] = 104;
            charttinfo.rgb[4, 0] = 255;
            charttinfo.rgb[4, 1] = 130;
            charttinfo.rgb[4, 2] = 250;
            charttinfo.rgb[4, 3] = 159;
            charttinfo.rgb[5, 0] = 50;
            charttinfo.rgb[5, 1] = 0;
            charttinfo.rgb[5, 2] = 0;
            charttinfo.rgb[5, 3] = 255;
            charttinfo.rgb[6, 0] = 255;
            charttinfo.rgb[6, 1] = 48;
            charttinfo.rgb[6, 2] = 142;
            charttinfo.rgb[6, 3] = 206;
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
            charttinfo.rgb[0, 0] = 255;
            charttinfo.rgb[0, 1] = 4;
            charttinfo.rgb[0, 2] = 114;
            charttinfo.rgb[0, 3] = 30;
            charttinfo.rgb[1, 0] = 50;
            charttinfo.rgb[1, 1] = 7;
            charttinfo.rgb[1, 2] = 177;
            charttinfo.rgb[1, 3] = 47;
            charttinfo.rgb[2, 0] = 255;
            charttinfo.rgb[2, 1] = 10;
            charttinfo.rgb[2, 2] = 246;
            charttinfo.rgb[2, 3] = 66;
            charttinfo.rgb[3, 0] = 50;
            charttinfo.rgb[3, 1] = 59;
            charttinfo.rgb[3, 2] = 247;
            charttinfo.rgb[3, 3] = 104;
            charttinfo.rgb[4, 0] = 255;
            charttinfo.rgb[4, 1] = 130;
            charttinfo.rgb[4, 2] = 250;
            charttinfo.rgb[4, 3] = 159;
            charttinfo.rgb[5, 0] = 50;
            charttinfo.rgb[5, 1] = 0;
            charttinfo.rgb[5, 2] = 0;
            charttinfo.rgb[5, 3] = 255;
            charttinfo.rgb[6, 0] = 255;
            charttinfo.rgb[6, 1] = 48;
            charttinfo.rgb[6, 2] = 142;
            charttinfo.rgb[6, 3] = 206;
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
            Q_EPS.OpenData(COD.Values, 7, 7);
            charttinfo.nSeries = 7;
            charttinfo.nvalues = 7;
            charttinfo.perend = "perend_Q";
            charttinfo.colName[0] = "eps_q";
            charttinfo.colName[1] = "epscon_q";
            charttinfo.colName[2] = "epsd_q";
            charttinfo.colName[3] = "epsdc_q";
            charttinfo.colName[4] = "epsnd_q";
            charttinfo.colName[5] = "dps_q";
            charttinfo.colName[6] = "dpst_q";
            charttinfo.rgb[0, 0] = 255;
            charttinfo.rgb[0, 1] = 4;
            charttinfo.rgb[0, 2] = 114;
            charttinfo.rgb[0, 3] = 30;
            charttinfo.rgb[1, 0] = 50;
            charttinfo.rgb[1, 1] = 7;
            charttinfo.rgb[1, 2] = 177;
            charttinfo.rgb[1, 3] = 47;
            charttinfo.rgb[2, 0] = 255;
            charttinfo.rgb[2, 1] = 10;
            charttinfo.rgb[2, 2] = 246;
            charttinfo.rgb[2, 3] = 66;
            charttinfo.rgb[3, 0] = 50;
            charttinfo.rgb[3, 1] = 59;
            charttinfo.rgb[3, 2] = 247;
            charttinfo.rgb[3, 3] = 104;
            charttinfo.rgb[4, 0] = 255;
            charttinfo.rgb[4, 1] = 130;
            charttinfo.rgb[4, 2] = 250;
            charttinfo.rgb[4, 3] = 159;
            charttinfo.rgb[5, 0] = 50;
            charttinfo.rgb[5, 1] = 0;
            charttinfo.rgb[5, 2] = 0;
            charttinfo.rgb[5, 3] = 255;
            charttinfo.rgb[6, 0] = 255;
            charttinfo.rgb[6, 1] = 48;
            charttinfo.rgb[6, 2] = 142;
            charttinfo.rgb[6, 3] = 206;
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
            charttinfo.colors.Insert(0, Color.Green);
            charttinfo.colors.Insert(1, Color.LightGreen);
            charttinfo.colors.Insert(2, Color.DarkGreen);
            charttinfo.colors.Insert(3, Color.Red);
            charttinfo.colors.Insert(4, Color.DarkRed);
            charttinfo.colors.Insert(5, Color.Blue);
            charttinfo.colors.Insert(6, Color.DeepSkyBlue);
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
            Q_CFL.OpenData(COD.Values, 7, 7);
            charttinfo.nSeries = 7;
            charttinfo.nvalues = 7;
            charttinfo.perend = "perend_Q";
            charttinfo.colName[0] = "tco_q";
            charttinfo.colName[1] = "tci_q";
            charttinfo.colName[2] = "tcf_q";
            charttinfo.colName[3] = "dep_cf_q";
            charttinfo.colName[4] = "ce_q";
            charttinfo.colName[5] = "cfps_q";
            charttinfo.colName[6] = "fcfps_q";
            charttinfo.colors.Insert(0, Color.Green);
            charttinfo.colors.Insert(1, Color.LightGreen);
            charttinfo.colors.Insert(2, Color.DarkGreen);
            charttinfo.colors.Insert(3, Color.Red);
            charttinfo.colors.Insert(4, Color.DarkRed);
            charttinfo.colors.Insert(5, Color.Blue);
            charttinfo.colors.Insert(6, Color.DeepSkyBlue);
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
                            chart.Value[j, 0 + (ii - i)] = Convert.ToDouble(item);
                            //objwriter.Write(item);
                        }
                        else
                        {
                            //chart.Value[j, 0 + (ii - i)] =  null;
                        
                        }
                    }
                    chart.Series[j].LineWidth = 2;
                if (charttinfo.colors.Count<=0)
                    chart.Series[j].Color = System.Drawing.Color.FromArgb(charttinfo.rgb[j, 0], charttinfo.rgb[j, 1], charttinfo.rgb[j, 2], charttinfo.rgb[j, 3]);
                else
                    chart.Series[j].Color = charttinfo.colors[j];

                    chart.Series[j].Legend = charttinfo.legend[j];
                }

            }

    }
}
