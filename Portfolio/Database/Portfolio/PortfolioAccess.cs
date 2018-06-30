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
                            Ticker,CompanyName 
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

        public static void CreatePortfolio(string PortfolioName, DataTable portfolioDT)
        {
            using (SqlConnection conn = new SqlConnection(Constant.ConnectionString))
            {
                conn.Open();
                var trans = conn.BeginTransaction("CreatePortfolio");
                try
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Portfolio(PortfolioName) output INSERTED.PortfolioID VALUES(@prtfName)", conn))
                    {
                        cmd.Transaction = trans;
                        cmd.Parameters.AddWithValue("@prtfName", PortfolioName);

                        int modified = (int)cmd.ExecuteScalar();

                        foreach (DataRow row in portfolioDT.Rows)
                        {
                            row["PortfolioID"] = modified;
                        }

                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, trans))
                        {
                            bulkCopy.DestinationTableName = "Tickers";
                            bulkCopy.WriteToServer(portfolioDT);
                        }
                        trans.Commit();
                    }
                }
                catch (Exception ex)
                {
                    trans.Rollback("CreatePortfolio");
                    throw ex;
                }
            }
        }
    }
}
