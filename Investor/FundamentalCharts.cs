using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FundamentalCharts : Form
    {
        public FundamentalCharts()
        {
            InitializeComponent();
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
        private void Annual_EPS_Load(System.Object sender, System.EventArgs e)
        {
        }

        private void A_EPS_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
