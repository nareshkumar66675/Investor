using Portfolio.Database.Portfolio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Portfolio.Portfolio
{
    public partial class PortfolioForm : Form
    {
        public PortfolioFormModel PortfolioFormData { get; set; }
        public PortfolioForm(PortfolioFormModel portfolioFormModel)
        {
            InitializeComponent();

            PortfolioFormData = portfolioFormModel;
            this.Text = PortfolioFormData.PortfolioName;
            PrtfNameLbl.Text = PortfolioFormData.PortfolioName;

            InitializePortfolio();
        }

        private void InitializePortfolio()
        {
            var prtfData = PortfolioAccess.GetPortfolioData(PortfolioFormData.PortfolioID);

            PortfolioGV.DataSource = prtfData;
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var result = PortfolioAccess.DeletePortfolio(PortfolioFormData.PortfolioID);

                if (result)
                {
                    MessageBox.Show(this, "Portfolio Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Portfolio Deletion Failed: "+ ex.Message, "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class PortfolioFormModel
    {
        public int PortfolioID { get; set; }
        public string PortfolioName { get; set; }
    }
}
