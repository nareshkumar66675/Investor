using Portfolio.Portfolio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Portfolio
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();

            List<string> tickers = new List<string>(new string[] { "fvv", "vfv" });

            PortfolioUCModel portfolioUCModel = new PortfolioUCModel("Portfolio Name", tickers);

            //for (int i = 0; i < 6; i++)
            {
                DashboardTblLyt.ColumnCount = 3;
                DashboardTblLyt.RowCount = 2;

                DashboardTblLyt.Controls.Add(new PortfolioUC(portfolioUCModel), 0, 0);
                DashboardTblLyt.Controls.Add(new PortfolioUC(portfolioUCModel), 1, 0);
                DashboardTblLyt.Controls.Add(new PortfolioUC(portfolioUCModel), 2, 0);
                DashboardTblLyt.Controls.Add(new PortfolioUC(portfolioUCModel), 0, 1);
                DashboardTblLyt.Controls.Add(new PortfolioUC(portfolioUCModel), 1, 1);
                DashboardTblLyt.Controls.Add(new PortfolioUC(portfolioUCModel), 2, 1);
            }
        }
    }
}
