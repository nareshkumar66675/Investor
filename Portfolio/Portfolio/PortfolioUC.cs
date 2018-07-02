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
            TickerListView.Scrollable = true;
            TickerListView.View = View.Details;
            TickerListView.HeaderStyle = ColumnHeaderStyle.None;
            portfolioUCModel.Tickers.ForEach(ticker =>
            {
                ListViewItem item = new ListViewItem(ticker);
                TickerListView.Items.Add(ticker);
                //TickerListView.Items.Add(item);
            });

            TickerListView.Refresh();
            PortfolioUCData = portfolioUCModel;
            if (HasChildren)
                AddOnMouseClickHandlerRecursive(Controls);
        }

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
    }
    public class PortfolioUCModel
    {
        public int PortfolioId { get; set; }
        public string PortfolioName { get; set; }
        public List<string> Tickers { get; set; }

        public PortfolioUCModel()
        {

        }

        public PortfolioUCModel(string portfolioName, List<string> tickers)
        {
            this.PortfolioName = portfolioName;
            this.Tickers = tickers;
        }
    }
}
