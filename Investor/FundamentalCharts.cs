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
        public Chart Q_PL;
        public FundamentalCharts()
        {
            InitializeComponent();
            this.Q_PL = Q_PL_Chart;
            //Me.ReportViewer1.RefreshReport()
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
            //var FundamentalCharts = new FundamentalCharts();
            //populate charts with data from the dataset
            DataRow[] selectedRows = null;
            //array of rows which will hold the row(s) selected
            //to store value of column
            object item = null;

            //get the dataset row with the given ticker
            selectedRows = dataTable.Select(); //dataSet.Tables[0].Select("ticker = '" + tickerComboBox.Text + "'");

            //   Start ChartForm ------------------------------------------------------------------------------------
            ////goto EndChartForm;mmcmc
            //    ChartForm chartForm = new ChartForm();

            //    chartForm.quarterlyChart.OpenData(COD.Values, 5, nYears);
            //    //set annual sales chart properties
            //    chartForm.quarterlyChart.Series[0].Legend = "Sales";
            //    chartForm.quarterlyChart.Series[1].Legend = "CGS";
            //    chartForm.quarterlyChart.Series[2].Legend = "TotOpExp";
            //    chartForm.quarterlyChart.Series[3].Legend = "EBit";
            //    chartForm.quarterlyChart.Series[4].Legend = "NetInc";
            //    chartForm.quarterlyChart.AxisY.LabelsFormat.Format = AxisFormat.Currency;
            //    chartForm.quarterlyChart.AxisX.TickMark = TickMark.Outside;
            //    // 'chartForm.QuarterlyChart.AxisX.LabelAngle = 45

            //    //set annualChart x-axis labels
            //    for (int i = nYears; i >= 1; i += -1)
            //    {
            //        item = selectedRows[0]["perend_y" + i.ToString()];
            //        if (((!object.ReferenceEquals(item, DBNull.Value)) && (!(i % 2 == 0))))
            //        {
            //            chartForm.quarterlyChart.AxisX.Label[0 + (nYears - i)] = System.DateTime.Parse(item.ToString()).ToString("MM/yy");
            //        }
            //        else
            //        {
            //            chartForm.quarterlyChart.AxisX.Label[0 + (nYears - i)] = "";
            //        }
            //    }

            //    // get sales
            //    for (int i = nYears; i >= 1; i += -1)
            //    {
            //        item = selectedRows[0]["sales_y" + i.ToString()];
            //        if (((!object.ReferenceEquals(item, DBNull.Value))))
            //        {
            //            chartForm.quarterlyChart.Value[0, 0 + (nYears - i)] = Convert.ToDouble(item);
            //            chartForm.quarterlyChart.Series[0].LineWidth = 3;
            //            chartForm.quarterlyChart.Series[0].Color = System.Drawing.Color.FromArgb(50, 255, 0, 0);
            //            chartForm.quarterlyChart.Series[0].LineWidth = 3;
            //        }
            //        else
            //        {
            //            chartForm.quarterlyChart.Value[0, 0 + (nYears - i)] = 0; //null;
            //        }
            //    }

            //    //now get the annual cgs
            //    for (int i = nYears; i >= 1; i += -1)
            //    {
            //        item = selectedRows[0]["cgs_y" + i.ToString()];
            //        if (((!object.ReferenceEquals(item, DBNull.Value))))
            //        {
            //            chartForm.quarterlyChart.Value[1, 0 + (nYears - i)] = Convert.ToDouble(item);
            //            chartForm.quarterlyChart.Series[1].Color = System.Drawing.Color.Yellow;
            //            chartForm.quarterlyChart.Series[1].LineWidth = 4;
            //        }
            //        else
            //        {
            //            chartForm.quarterlyChart.Value[1, 0 + (nYears - i)] = 0;// null;
            //        }
            //    }

            //    //next the annual totextp
            //    for (int i = nYears; i >= 1; i += -1)
            //    {
            //        item = selectedRows[0]["totexp_y" + i.ToString()];
            //        if (((!object.ReferenceEquals(item, DBNull.Value))))
            //        {
            //            chartForm.quarterlyChart.Value[2, 0 + (nYears - i)] = Convert.ToDouble(item);
            //            chartForm.quarterlyChart.Series[2].LineWidth = 5;
            //        }
            //        else
            //        {
            //            chartForm.quarterlyChart.Value[2, 0 + (nYears - i)] = 0;// null;
            //        }
            //    }

            //    //next the Net Income
            //    for (int i = nYears; i >= 1; i += -1)
            //    {
            //        item = selectedRows[0]["ebit_y" + i.ToString()];
            //        if (((!object.ReferenceEquals(item, DBNull.Value))))
            //        {
            //            chartForm.quarterlyChart.Value[3, 0 + (nYears - i)] = Convert.ToDouble(item);
            //            chartForm.quarterlyChart.Series[3].LineWidth = 6;
            //        }
            //        else
            //        {
            //            chartForm.quarterlyChart.Value[3, 0 + (nYears - i)] = 0;//; null;
            //        }
            //    }

            //    //next the Net Income
            //    for (int i = nYears; i >= 1; i += -1)
            //    {
            //        item = selectedRows[0]["netinc_y" + i.ToString()];
            //        if (((!object.ReferenceEquals(item, DBNull.Value))))
            //        {
            //            chartForm.quarterlyChart.Value[4, 0 + (nYears - i)] = Convert.ToDouble(item);
            //            chartForm.quarterlyChart.Series[4].LineWidth = 6;
            //        }
            //        else
            //        {
            //            chartForm.quarterlyChart.Value[4, 0 + (nYears - i)] = 0; //;null;
            //        }
            //    }
            //    chartForm.quarterlyChart.CloseData(COD.Values);
            //EndChartForm:

            // End ChartForm --------------------------------------------------------------------------------------------


            // Start Annual ------------------------------------------------------------------------
            //Dim FundamentalCharts As New FundamentalCharts

            Annual_PL.OpenData(COD.Values, 5, nYears);

            //  goto skipAnnual;
            //set annual sales chart properties
            Annual_PL.Series[0].Legend = "Sales";
            Annual_PL.Series[1].Legend = "CGS";
            Annual_PL.Series[2].Legend = "TotOpExp";
            Annual_PL.Series[3].Legend = "EBit";
            Annual_PL.Series[4].Legend = "NetInc";
            Annual_PL.AxisY.LabelsFormat.Format = AxisFormat.Currency;
            Annual_PL.AxisX.TickMark = TickMark.Outside;
            //FundamentalCharts.Annual_PL.AxisX.LabelAngle = 45
            Annual_PL.MarkerShape = MarkerShape.None;
            SetChartTitle(Annual_PL, "Annual - PL");

            //set annualChart x-axis labels
            for (int i = nYears; i >= 1; i += -1)
            {
                item = selectedRows[0]["perend_y" + i.ToString()];
                if (((!object.ReferenceEquals(item, DBNull.Value)) && (!(i % 2 == 0))))
                {
                    Annual_PL.AxisX.Label[0 + (nYears - i)] = System.DateTime.Parse(item.ToString()).ToString("MM/yy");
                }
                else
                {
                    Annual_PL.AxisX.Label[0 + (nYears - i)] = "";
                }
            }

            // get sales
            for (int i = nYears; i >= 1; i += -1)
            {
                item = selectedRows[0]["sales_y" + i.ToString()];
                if (((!object.ReferenceEquals(item, DBNull.Value))))
                {
                    Annual_PL.Value[0, 0 + (nYears - i)] = Convert.ToDouble(item);
                    Annual_PL.Series[0].LineWidth = 3;
                    Annual_PL.Series[0].Color = System.Drawing.Color.FromArgb(50, 255, 0, 0);
                    Annual_PL.Series[0].LineWidth = 3;
                }
                else
                {
                    Annual_PL.Value[0, 0 + (nYears - i)] = 0; // null;
                }
            }

            //now get the annual cgs
            for (int i = nYears; i >= 1; i += -1)
            {
                item = selectedRows[0]["cgs_y" + i.ToString()];
                if (((!object.ReferenceEquals(item, DBNull.Value))))
                {
                    Annual_PL.Value[1, 0 + (nYears - i)] = Convert.ToDouble(item);
                    Annual_PL.Series[1].Color = System.Drawing.Color.Yellow;
                    Annual_PL.Series[1].LineWidth = 4;
                }
                else
                {
                    Annual_PL.Value[1, 0 + (nYears - i)] = 0; // null;
                }
            }

            //next the annual totextp
            for (int i = nYears; i >= 1; i += -1)
            {
                item = selectedRows[0]["totexp_y" + i.ToString()];
                if (((!object.ReferenceEquals(item, DBNull.Value))))
                {
                    Annual_PL.Value[2, 0 + (nYears - i)] = Convert.ToDouble(item);
                    Annual_PL.Series[2].LineWidth = 5;
                }
                else
                {
                    Annual_PL.Value[2, 0 + (nYears - i)] = 0; // null;
                }
            }

            //next the Net Income
            for (int i = nYears; i >= 1; i += -1)
            {
                item = selectedRows[0]["ebit_y" + i.ToString()];
                if (((!object.ReferenceEquals(item, DBNull.Value))))
                {
                    Annual_PL.Value[3, 0 + (nYears - i)] = Convert.ToDouble(item);
                    Annual_PL.Series[3].LineWidth = 6;
                }
                else
                {
                    Annual_PL.Value[3, 0 + (nYears - i)] = 0; // null;
                }
            }

            //next the Net Income
            for (int i = nYears; i >= 1; i += -1)
            {
                item = selectedRows[0]["netinc_y" + i.ToString()];
                if (((!object.ReferenceEquals(item, DBNull.Value))))
                {
                    Annual_PL.Value[4, 0 + (nYears - i)] = Convert.ToDouble(item);
                    Annual_PL.Series[4].LineWidth = 6;
                }
                else
                {
                    Annual_PL.Value[4, 0 + (nYears - i)] = 0; // null;
                }
            }
            Annual_PL.CloseData(COD.Values);
            //skipAnnual:


            //End Annual ------------------------------------------------------------------------------------------------



            //Now start Quarterly Charts --------------------------------------------------------------------------------
            Q_PL.OpenData(COD.Values, 5, nQuarters);

            //goto skipp;

            //quarterly chart properties
            Q_PL.Series[0].Legend = "Sales";
            Q_PL.Series[1].Legend = "CGS";
            Q_PL.Series[2].Legend = "Totexp";
            Q_PL.Series[3].Legend = "ebit";
            Q_PL.Series[4].Legend = "netinc";

            Q_PL.AxisY.LabelsFormat.Format = AxisFormat.Currency;
            Q_PL.AxisX.TickMark = TickMark.Outside;
            Q_PL.AxisX.LabelAngle = 45;
            SetChartTitle(Q_PL, "Quarterly - PL");
            //set quarterlyChart x-axis labels

            for (int i = nQuarters; i >= 1; i += -1)
            {
                item = selectedRows[0]["perend_q" + i.ToString()];
                if (((!object.ReferenceEquals(item, DBNull.Value)) && (i % 2 == 0)))
                {
                    Q_PL.AxisX.Label[0 + (nQuarters - i)] = System.DateTime.Parse(item.ToString()).ToString("MM/yyyy");
                }
                else
                {
                    Q_PL.AxisX.Label[0 + (nQuarters - i)] = "";
                }
            }

            //quarterly sales
            for (int i = nQuarters; i >= 1; i += -1)
            {
                item = selectedRows[0]["sales_q" + i.ToString()];
                if (((!object.ReferenceEquals(item, DBNull.Value))))
                {
                    Q_PL.Value[0, 0 + (nQuarters - i)] = Convert.ToDouble(item);
                }
                else
                {
                    Q_PL.Value[0, 0 + (nQuarters - i)] = 0; // null;
                }
            }

            //quarterly cgs
            for (int i = nQuarters; i >= 1; i += -1)
            {
                item = selectedRows[0]["cgs_q" + i.ToString()];
                if (((!object.ReferenceEquals(item, DBNull.Value))))
                {
                    Q_PL.Value[1, 0 + (nQuarters - i)] = Convert.ToDouble(item);
                }
                else
                {
                    Q_PL.Value[1, 0 + (nQuarters - i)] = 0; // null;
                }
            }

            //  quarterly totextp
            for (int i = nQuarters; i >= 1; i += -1)
            {
                item = selectedRows[0]["totexp_q" + i.ToString()];
                if (((!object.ReferenceEquals(item, DBNull.Value))))
                {
                    Q_PL.Value[2, 0 + (nQuarters - i)] = Convert.ToDouble(item);
                }
                else
                {
                    Q_PL.Value[2, 0 + (nQuarters - i)] = 0; // null;
                }
            }

            //  quarterly ebit
            for (int i = nQuarters; i >= 1; i += -1)
            {
                item = selectedRows[0]["ebit_q" + i.ToString()];
                if (((!object.ReferenceEquals(item, DBNull.Value))))
                {
                    Q_PL.Value[3, 0 + (nQuarters - i)] = Convert.ToDouble(item);
                }
                else
                {
                    Q_PL.Value[3, 0 + (nQuarters - i)] = 0; // null;
                }
            }

            //  quarterly netinc
            for (int i = nQuarters; i >= 1; i += -1)
            {
                item = selectedRows[0]["netinc_q" + i.ToString()];
                if (((!object.ReferenceEquals(item, DBNull.Value))))
                {
                    Q_PL.Value[4, 0 + (nQuarters - i)] = Convert.ToDouble(item);
                }
                else
                {
                    Q_PL.Value[4, 0 + (nQuarters - i)] = 0; // null;
                }
            }
            //skipp:

            // FundamentalCharts.Q_PL.CloseData(COD.Values)

            //set form title and label
            Text = ticker;
            // FundamentalCharts.tickerLabel.Text = Trim(selectedRows(0).Item("company").ToString()) & " - " & tickerComboBox.Text

            //
            //goTo temp
            //Plot Quarterly
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

            //Plot Annual
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
            //temp:
            //Plot Annual Expenses
            A_Exp.OpenData(COD.Values, 10, 7);
            charttinfo.nSeries = 7;
            charttinfo.nvalues = 7;
            charttinfo.perend = "perend_y";
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
            PlotChart(selectedRows, A_Exp, charttinfo);
            SetChartTitle(A_Exp, "Annual - Exp");
            A_Exp.CloseData(COD.Values);

            //Plot Annual EPS
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

            //Plot Quarterly EPS
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

            Q_PL.CloseData(COD.Values);
        }

        private void PlotChart(DataRow[] selectedRows, SoftwareFX.ChartFX.Chart chart, ChartInfo charttinfo)
        {
            // Dim selectedrows As DataRow
            object item = null;
            int ii = 0;
            int iii = 0;
            int j = 0;

            //string file_name = @"C:\Naresh\Projects\investor-2015\test.txt";
            //using (System.IO.StreamWriter objwriter = new System.IO.StreamWriter(file_name))
            {
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
                            chart.Value[j, 0 + (ii - i)] = 0; // null;
                        }
                    }
                    //objwriter.Write(Environment.NewLine);
                    chart.Series[j].LineWidth = 3;
                    chart.Series[j].Color = System.Drawing.Color.FromArgb(charttinfo.rgb[j, 0], charttinfo.rgb[j, 1], charttinfo.rgb[j, 2], charttinfo.rgb[j, 3]);
                    chart.Series[j].Legend = charttinfo.legend[j];
                }
            }

        }

    }
}
