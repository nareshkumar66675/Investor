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

    public partial class PortfolioUC : UserControl
    {
        public PortfolioUCModel PortfolioUCData { get; set; }
        public PortfolioUC(PortfolioUCModel portfolioUCModel)
        {
            InitializeComponent();

            PortfolioNameLbl.Text = portfolioUCModel.PortfolioName;
            PortfolioNameLbl.BackColor = ColorTranslator.FromHtml(portfolioUCModel.CategoryColor);
            //tickerlistview.scrollable = true;
            //tickerlistview.view = view.details;
            //tickerlistview.headerstyle = columnheaderstyle.none;
            //portfolioucmodel.tickers.foreach (ticker =>
            // {
            //     listviewitem item = new listviewitem(ticker);
            //     tickerlistview.items.add(ticker);
            //     tickerlistview.items.add(item);
            // }) ;

            //tickerlistview.refresh();
            PortfolioUCData = portfolioUCModel;
            if (HasChildren)
                AddOnMouseClickHandlerRecursive(Controls);
        }

        /// <summary>
        /// On Click handler for all components present inside the User Control
        /// </summary>
        /// <param name="controls"></param>
        private void AddOnMouseClickHandlerRecursive(ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                control.MouseClick += PortfolioUC_MouseClick;

                if (control.HasChildren)
                    AddOnMouseClickHandlerRecursive(control.Controls);
            }
        }

        private void PortfolioUC_MouseClick(object sender, MouseEventArgs e)
        {
            var portfolioFormData = PortfolioUCData.PortfolioFormToUC();
            PortfolioForm portfolioForm = new PortfolioForm(portfolioFormData);
            portfolioForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

    /// <summary>
    /// Portfolio Model - used to send data from GroupUC to PortfolioUC
    /// </summary>
    public class PortfolioUCModel
    {
        public int PortfolioId { get; set; }

        public string PortfolioName { get; set; }

        public int CategoryID { get; set; }

        public string CategoryColor { get; set; }

    }
}
