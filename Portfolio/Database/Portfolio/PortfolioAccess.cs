﻿using Portfolio.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Database.Portfolio
{
    public class PortfolioAccess
    {
        /// <summary>
        /// Get Group Data for Portfolio
        /// </summary>
        /// <returns>Group & Portfolio Data</returns>
        public static DataTable GetGroupDataForDashboard()
        {
            DataTable dataTable = new DataTable();

            string query = @"SELECT grp.GroupID, grp.Name as [GroupName],
                            prtf.Id as [PortfolioID],
                            prtf.Name as [PortfolioName],
                            ctgry.CategoryID, ctgry.Color
                        FROM Portfolio.[Group] grp
                        LEFT JOIN Portfolio.Portfolio prtf on grp.GroupID = prtf.GroupID
                        LEFT JOIN Portfolio.Category ctgry on ctgry.CategoryId = prtf.CategoryId";

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
                conn.Close();
            }

            return dataTable;
        }

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
                conn.Close();
            }

            return dataTable;
        }

        public static DataTable GetPortfolioData(int prtfID)
        {
            DataTable dataTable = new DataTable();

            string query = $@"select 
                            Ticker,CompanyName 
                            from Portfolio prtf
                            LEFT JOIN Tickers tkr on prtf.PortfolioID=tkr.PortfolioID
                            WHERE prtf.PortfolioID = {prtfID}
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
                conn.Close();
            }

            return dataTable;
        }

        public static bool DeletePortfolio(int portfolioID)
        {
            using (SqlConnection conn = new SqlConnection(Constant.ConnectionString))
            {
                conn.Open();
                var trans = conn.BeginTransaction("DeletePortfolio");
                try
                {
                    string deleteTickers = $"Delete from Tickers where PortfolioID=@prtfID";
                    using (SqlCommand cmd = new SqlCommand(deleteTickers, conn))
                    {
                        cmd.Transaction = trans;
                        cmd.Parameters.AddWithValue("@prtfID", portfolioID);
                        cmd.ExecuteNonQuery();
                    }

                    string deletePrtf = $"Delete from Portfolio where PortfolioID=@prtfID";
                    using (SqlCommand cmd = new SqlCommand(deletePrtf, conn))
                    {
                        cmd.Transaction = trans;
                        cmd.Parameters.AddWithValue("@prtfID", portfolioID);
                        cmd.ExecuteNonQuery();
                    }
                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback("DeletePortfolio");
                    //EventLog.WriteEntry("Investor","Delete Portfolio - " + ex.Message, EventLogEntryType.Error);
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
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
                    //EventLog.WriteEntry("Investor", "Create Portfolio - " + ex.Message, EventLogEntryType.Error);
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
