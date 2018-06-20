using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Util
{
    public static class Const
    {
        public static string ConnectionString => string.Format(ConfigurationManager.ConnectionStrings["Investor"].ConnectionString, Environment.MachineName);

        public static List<string> DBFPaths => ConfigurationManager.AppSettings["DBFPaths"].Split(';').ToList();

        public static List<string> TableNames => ConfigurationManager.AppSettings["TableNames"].Split(',').ToList();
    }
}
