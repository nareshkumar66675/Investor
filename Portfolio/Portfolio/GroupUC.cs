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
            
            // Set Row & Column Count
            GrpTblLyt.ColumnCount = Constant.PortfolioColumnCount;
            // Row count is set based on the number of portfolios
            GrpTblLyt.RowCount = (grpModel.Portfolios.Count + Constant.PortfolioColumnCount - 1) / Constant.PortfolioColumnCount;

            grpModel.Portfolios.ForEach(prtf =>
            {
                // Create a new Portfolio User Control and add it to GroupUserControl
                PortfolioUC portfolioUC = new PortfolioUC(prtf);
                //portfolioUC.Dock = DockStyle.Fill;
                GrpTblLyt.Controls.Add(portfolioUC);
            });
        }
    }

    /// <summary>
    /// Group UserControl Model
    /// Used to send data to this UserControl from Dashboard
    /// </summary>
    public class GroupUCModel
    {
        /// <summary>
        /// Group Id
        /// </summary>
        public int GroupID { get; set; }

        /// <summary>
        /// GroupName
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// List of Portfolios
        /// </summary>
        public List<PortfolioUCModel> Portfolios { get; set; }
    }
}
