using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Portfolio.Util;

namespace Portfolio.Portfolio
{
    public partial class GroupUC : UserControl
    {
        private GroupUCModel grpModel;

        public GroupUC()
        {
            InitializeComponent();
        }

        public GroupUC(GroupUCModel grp)
        {
            this.grpModel = grp;
            InitializeComponent();

            InitializeGroup();
        }

        private void InitializeGroup()
        {
            GrpBox.Text = grpModel.GroupName;
            

            GrpTblLyt.ColumnCount = Constant.PortfolioColumnCount;
            GrpTblLyt.RowCount = (grpModel.Portfolios.Count + Constant.PortfolioColumnCount - 1) / Constant.PortfolioColumnCount;

            grpModel.Portfolios.ForEach(prtf =>
            {
                PortfolioUC portfolioUC = new PortfolioUC(prtf);
                portfolioUC.Dock = DockStyle.Fill;
                GrpTblLyt.Controls.Add(portfolioUC);
            });
        }
    }

    public class GroupUCModel
    {
        public int GroupID { get; set; }

        public string GroupName { get; set; }

        public List<PortfolioUCModel> Portfolios { get; set; }
    }
}
