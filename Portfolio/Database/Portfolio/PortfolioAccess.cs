using Portfolio.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Database.Portfolio
{
    public class PortfolioAccess
    {
        public static DataTable GetPortfolioDataForDashboard()
        {
            DataTable dataTable = new DataTable();

            string query = @"select 
                            prtf.PortfolioID,PortfolioName,
                            Ticker,Name 
                            from Portfolio prtf
                            LEFT JOIN Tickers tkr on prtf.PortfolioID=tkr.PortfolioID
                            ORDER BY prtf.PortfolioID";

            using (SqlConnection conn = new SqlConnection(Constant.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dataTable);
                    conn.Close();
                    da.Dispose(); 
                } 
            }

            return dataTable;
        }
    }
}
