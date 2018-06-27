using Portfolio.Database.Portfolio;
using Portfolio.Portfolio;
using Portfolio.Util;
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

            InitializeDashboard();

        }

        private void InitializeDashboard()
        {
            var prtfData = PortfolioAccess.GetPortfolioDataForDashboard();

            var prtfDataList = prtfData.AsEnumerable()
                               .GroupBy(x => new { ID= x.Field<int>("PortfolioID"),PortfolionName= x.Field<string>("PortfolioName") })
                               .Select(grp => new PortfolioUCModel
                               {
                                   PortfolioId = grp.Key.ID,
                                   PortfolioName = grp.Key.PortfolionName,
                                   Tickers = grp.Select(ticker => ticker.Field<string>("Ticker")).ToList()
                                }).ToList();

            // Set Table Size
            DashboardTblLyt.ColumnCount = Constant.DashboardColumnCount;
            DashboardTblLyt.RowCount = (prtfDataList.Count + Constant.DashboardColumnCount - 1) / Constant.DashboardColumnCount;

            prtfDataList.ForEach(prtf =>
            {
                DashboardTblLyt.Controls.Add(new PortfolioUC(prtf));
            });

        }
    }
}
