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
    }
}
