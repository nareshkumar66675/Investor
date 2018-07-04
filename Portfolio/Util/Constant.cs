using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Util
{
    public static class Constant
    {
        public static string ConnectionString = string.Format(ConfigurationManager.ConnectionStrings["Investor"].ConnectionString, Environment.MachineName);
        public const int DashboardColumnCount = 3;
        public const string FeedURL = "https://feeds.finance.yahoo.com/rss/2.0/headline";
        public const string FeedParameter = "?s={0}";
    }
}
