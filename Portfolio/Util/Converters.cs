using Portfolio.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Util
{
    public static class Converters
    {
        public static PortfolioFormModel PortfolioFormToUC(this PortfolioUCModel portfolioUCModel)
        {
            PortfolioFormModel portfolioFormModel = new PortfolioFormModel();

            portfolioFormModel.PortfolioID = portfolioUCModel.PortfolioId;
            portfolioFormModel.PortfolioName = portfolioUCModel.PortfolioName;

            return portfolioFormModel;
        }
    }
}
