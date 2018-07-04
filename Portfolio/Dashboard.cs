using Portfolio.Database.Portfolio;
using Portfolio.FinanceFeed;
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

            WebRequest webRequest = new WebRequest();

            var news = webRequest.GetNewsByTicker("A");

        }

        private void InitializeDashboard()
        {
            var groupData = PortfolioAccess.GetGroupDataForDashboard();

            var groupDataList = groupData.AsEnumerable()
                               .GroupBy(x => new { ID = x.Field<int>("GroupID"), PortfolionName = x.Field<string>("GroupName") })
                               .Select(grp => new GroupUCModel
                               {
                                   GroupID = grp.Key.ID,
                                   GroupName = grp.Key.PortfolionName,
                                   Portfolios = grp.Where(t=> t.Field<int?>("PortfolioID") != null)
                                   .Select(prtf => new PortfolioUCModel
                                   {
                                       PortfolioId = prtf.Field<int>("PortfolioID"),
                                       PortfolioName = prtf.Field<string>("PortfolioName"),
                                       CategoryID = prtf.Field<int>("CategoryID"),
                                       CategoryColor = prtf.Field<string>("Color"),
                                   }).ToList()
                                }).OrderBy(t=>t.GroupID).ToList();

            DashboardTblLyt.Controls.Clear();

            // Set Table Size
            //DashboardTblLyt.ColumnCount = Constant.DashboardColumnCount;
            //DashboardTblLyt.RowCount = (prtfDataList.Count + Constant.DashboardColumnCount - 1) / Constant.DashboardColumnCount;

            DashboardTblLyt.ColumnCount = 1;
            DashboardTblLyt.RowCount = groupDataList.Count;

            groupDataList.ForEach(grp =>
            {
                GroupUC grpUC = new GroupUC(grp);
                grpUC.Dock = DockStyle.Fill;
                DashboardTblLyt.Controls.Add(grpUC);
            });

        }

        private void AddNewPrtfBtn_Click(object sender, EventArgs e)
        {
            AddPortfolio addPortfolio = new AddPortfolio();
            addPortfolio.Owner = this;
            addPortfolio.Show();
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            InitializeDashboard();
        }
    }
}
