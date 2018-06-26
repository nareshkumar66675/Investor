﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Portfolio.Portfolio
{

    public partial class PortfolioUC : UserControl
    {

        public PortfolioUC(PortfolioUCModel portfolioUCModel)
        {
            InitializeComponent();

            PortfolioNameLbl.Text = portfolioUCModel.PortfolioName;

            portfolioUCModel.Tickers.ForEach(ticker =>
            {
                ListViewItem item = new ListViewItem(ticker);
                TickerListView.Items.Add(ticker);
                //TickerListView.Items.Add(item);
            });

            TickerListView.Refresh();
        }
    }
    public class PortfolioUCModel
    {
        public string PortfolioName { get; set; }
        public List<string> Tickers { get; set; }

        public PortfolioUCModel(string portfolioName, List<string> tickers)
        {
            this.PortfolioName = portfolioName;
            this.Tickers = tickers;
        }
    }
}
