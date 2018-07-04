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

            // Currently not used

            //WebRequest webRequest = new WebRequest();

            //var news = webRequest.GetNewsByTicker("A");

        }

        private void InitializeDashboard()
        {
            // Get Group & Portfolio Data from Database
            var groupData = PortfolioAccess.GetGroupDataForDashboard();

            // Groups the data and Create Objects
            var groupDataList = groupData.AsEnumerable()
                               .GroupBy(x => new { ID = x.Field<int>("GroupID"), PortfolionName = x.Field<string>("GroupName") })
                               .Select(grp => new GroupUCModel // Creates a List of Group Objects
                               {
                                   GroupID = grp.Key.ID,
                                   GroupName = grp.Key.PortfolionName,
                                   Portfolios = grp.Where(t=> t.Field<int?>("PortfolioID") != null)
                                   .Select(prtf => new PortfolioUCModel // Creates a list of Portfolio Objects
                                   {
                                       PortfolioId = prtf.Field<int>("PortfolioID"),
                                       PortfolioName = prtf.Field<string>("PortfolioName"),
                                       CategoryID = prtf.Field<int>("CategoryID"),
                                       CategoryColor = prtf.Field<string>("Color"),
                                   }).ToList()
                                }).OrderBy(t=>t.GroupID).ToList();

            DashboardTblLyt.Controls.Clear();

            DashboardTblLyt.ColumnCount = 1;
            DashboardTblLyt.RowCount = groupDataList.Count; // Set Row Count based on retrieved group count

            groupDataList.ForEach(grp =>
            {
                // Create GroupUserControl and add it into Dashboard Table Layout
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
