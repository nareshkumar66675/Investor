using Investor.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Util
{
    public static class DBOperation
    {
        public static DataTable GetValuesByTicker(string ticker)
        {
            SqlConnection sqlConn;
            SqlDataAdapter sqlAdapter;
            DataSet dataSet;
            string qString;
            qString = " select " + "si_ci.company, si_ci.ticker, "
                            + "si_date.perend_q1, si_date.perend_q2, si_date.perend_q3, si_date.perend_q4, si_date.perend_q5, si_date.perend_q6, si_date.perend_q7, si_date.perend_q8, "
                            + "si_date.perend_y1, si_date.perend_y2, si_date.perend_y3, si_date.perend_y4, si_date.perend_y5, si_date.perend_y6, si_date.perend_y7, "
                            + "si_isq.sales_q1, si_isq.sales_q2, si_isq.sales_q3, si_isq.sales_q4, si_isq.sales_q5, si_isq.sales_q6, si_isq.sales_q7, si_isq.sales_q8, "
                            + "si_isq.cgs_q1, si_isq.cgs_q2, si_isq.cgs_q3, si_isq.cgs_q4, si_isq.cgs_q5, si_isq.cgs_q6, si_isq.cgs_q7, si_isq.cgs_q8, "
                            + "si_isq.totexp_q1, si_isq.totexp_q2, si_isq.totexp_q3, si_isq.totexp_q4, si_isq.totexp_q5, si_isq.totexp_q6, si_isq.totexp_q7, si_isq.totexp_q8, "
                            + "si_isq.epsd_q1, si_isq.epsd_q2, si_isq.epsd_q3, si_isq.epsd_q4, si_isq.epsd_q5, si_isq.epsd_q6, si_isq.epsd_q7, si_isq.epsd_q8, "
                            + "si_isq.eps_q1, si_isq.eps_q2, si_isq.eps_q3, si_isq.eps_q4, si_isq.eps_q5, si_isq.eps_q6, si_isq.eps_q7, si_isq.eps_q8, "
                            + "si_isq.epscon_q1, si_isq.epscon_q2, si_isq.epscon_q3, si_isq.epscon_q4, si_isq.epscon_q5, si_isq.epscon_q6, si_isq.epscon_q7, si_isq.epscon_q8, "
                            + "si_isq.epsdc_q1, si_isq.epsdc_q2, si_isq.epsdc_q3, si_isq.epsdc_q4, si_isq.epsdc_q5, si_isq.epsdc_q6, si_isq.epsdc_q7, si_isq.epsdc_q8, "
                            + "si_isq.epsnd_q1, si_isq.epsnd_q2, si_isq.epsnd_q3, si_isq.epsnd_q4, si_isq.epsnd_q5, si_isq.epsnd_q6, si_isq.epsnd_q7, si_isq.epsnd_q8, "
                            + "si_isq.dps_q1, si_isq.dps_q2, si_isq.dps_q3, si_isq.dps_q4, si_isq.dps_q5, si_isq.dps_q6, si_isq.dps_q7, si_isq.dps_q8, "
                            + "si_isq.dpst_q1, si_isq.dpst_q2, si_isq.dpst_q3, si_isq.dpst_q4, si_isq.dpst_q5, si_isq.dpst_q6, si_isq.dpst_q7, si_isq.dpst_q8, "
                            + "si_isq.ebit_q1, si_isq.ebit_q2, si_isq.ebit_q3, si_isq.ebit_q4, si_isq.ebit_q5, si_isq.ebit_q6, si_isq.ebit_q7, si_isq.ebit_q8, "
                            + "si_isq.netinc_q1, si_isq.netinc_q2, si_isq.netinc_q3, si_isq.netinc_q4, si_isq.netinc_q5, si_isq.netinc_q6, si_isq.netinc_q7, si_isq.netinc_q8,"
                            + "si_isq.dep_q1, si_isq.dep_q2, si_isq.dep_q3, si_isq.dep_q4, si_isq.dep_q5, si_isq.dep_q6, si_isq.dep_q7, si_isq.dep_q8,"
                            + "si_isq.rd_q1, si_isq.rd_q2, si_isq.rd_q3, si_isq.rd_q4, si_isq.rd_q5, si_isq.rd_q6, si_isq.rd_q7, si_isq.rd_q8,"
                            + "si_isq.int_q1, si_isq.int_q2, si_isq.int_q3, si_isq.int_q4, si_isq.int_q5, si_isq.int_q6, si_isq.int_q7, si_isq.int_q8,"
                            + "si_isq.uninc_q1, si_isq.uninc_q2, si_isq.uninc_q3, si_isq.uninc_q4, si_isq.uninc_q5, si_isq.uninc_q6, si_isq.uninc_q7, si_isq.uninc_q8,"
                            + "si_isq.othinc_q1, si_isq.othinc_q2, si_isq.othinc_q3, si_isq.othinc_q4, si_isq.othinc_q5, si_isq.othinc_q6, si_isq.othinc_q7, si_isq.othinc_q8,"
                            + "si_isq.intno_q1, si_isq.intno_q2, si_isq.intno_q3, si_isq.intno_q4, si_isq.intno_q5, si_isq.intno_q6, si_isq.intno_q7, si_isq.intno_q8,"
                            + "si_isq.inctax_q1, si_isq.inctax_q2, si_isq.inctax_q3, si_isq.inctax_q4, si_isq.inctax_q5, si_isq.inctax_q6, si_isq.inctax_q7, si_isq.inctax_q8,"
                            + "si_isq.adjust_q1, si_isq.adjust_q2, si_isq.adjust_q3, si_isq.adjust_q4, si_isq.adjust_q5, si_isq.adjust_q6, si_isq.adjust_q7, si_isq.adjust_q8,"
                            + "si_isq.xord_q1, si_isq.xord_q2, si_isq.xord_q3, si_isq.xord_q4, si_isq.xord_q5, si_isq.xord_q6, si_isq.xord_q7, si_isq.xord_q8,"
                            + "si_isa.sales_y1, si_isa.sales_y2, si_isa.sales_y3, si_isa.sales_y4, si_isa.sales_y5, si_isa.sales_y6, si_isa.sales_y7, "
                            + "si_isa.cgs_y1, si_isa.cgs_y2, si_isa.cgs_y3, si_isa.cgs_y4, si_isa.cgs_y5, si_isa.cgs_y6, si_isa.cgs_y7, "
                            + "si_isa.totexp_y1, si_isa.totexp_y2, si_isa.totexp_y3, si_isa.totexp_y4, si_isa.totexp_y5, si_isa.totexp_y6, si_isa.totexp_y7, "
                            + "si_isa.netinc_y1, si_isa.netinc_y2, si_isa.netinc_y3, si_isa.netinc_y4, si_isa.netinc_y5, si_isa.netinc_y6, si_isa.netinc_y7, "
                            + "si_isa.epsd_y1, si_isa.epsd_y2, si_isa.epsd_y3, si_isa.epsd_y4, si_isa.epsd_y5, si_isa.epsd_y6, si_isa.epsd_y7, "
                            + "si_isa.eps_y1, si_isa.eps_y2, si_isa.eps_y3, si_isa.eps_y4, si_isa.eps_y5, si_isa.eps_y6, si_isa.eps_y7, "
                            + "si_isa.epscon_y1, si_isa.epscon_y2, si_isa.epscon_y3, si_isa.epscon_y4, si_isa.epscon_y5, si_isa.epscon_y6, si_isa.epscon_y7, "
                            + "si_isa.epsdc_y1, si_isa.epsdc_y2, si_isa.epsdc_y3, si_isa.epsdc_y4, si_isa.epsdc_y5, si_isa.epsdc_y6, si_isa.epsdc_y7, "
                            + "si_isa.epsnd_y1, si_isa.epsnd_y2, si_isa.epsnd_y3, si_isa.epsnd_y4, si_isa.epsnd_y5, si_isa.epsnd_y6, si_isa.epsnd_y7, "
                            + "si_isa.dps_y1, si_isa.dps_y2, si_isa.dps_y3, si_isa.dps_y4, si_isa.dps_y5, si_isa.dps_y6, si_isa.dps_y7, "
                            + "si_isa.dpst_y1, si_isa.dpst_y2, si_isa.dpst_y3, si_isa.dpst_y4, si_isa.dpst_y5, si_isa.dpst_y6, si_isa.dpst_y7, "
                            + "si_isa.ebit_y1, si_isa.ebit_y2, si_isa.ebit_y3, si_isa.ebit_y4, si_isa.ebit_y5, si_isa.ebit_y6, si_isa.ebit_y7, "
                            + "si_isa.dep_y1, si_isa.dep_y2, si_isa.dep_y3, si_isa.dep_y4, si_isa.dep_y5, si_isa.dep_y6, si_isa.dep_y7,"
                            + "si_isa.rd_y1, si_isa.rd_y2, si_isa.rd_y3, si_isa.rd_y4, si_isa.rd_y5, si_isa.rd_y6, si_isa.rd_y7,"
                            + "si_isa.int_y1, si_isa.int_y2, si_isa.int_y3, si_isa.int_y4, si_isa.int_y5, si_isa.int_y6, si_isa.int_y7,"
                            + "si_isa.uninc_y1, si_isa.uninc_y2, si_isa.uninc_y3, si_isa.uninc_y4, si_isa.uninc_y5, si_isa.uninc_y6, si_isa.uninc_y7,"
                            + "si_isa.othinc_y1, si_isa.othinc_y2, si_isa.othinc_y3, si_isa.othinc_y4, si_isa.othinc_y5, si_isa.othinc_y6, si_isa.othinc_y7,"
                            + "si_isa.intno_y1, si_isa.intno_y2, si_isa.intno_y3, si_isa.intno_y4, si_isa.intno_y5, si_isa.intno_y6, si_isa.intno_y7,"
                            + "si_isa.inctax_y1, si_isa.inctax_y2, si_isa.inctax_y3, si_isa.inctax_y4, si_isa.inctax_y5, si_isa.inctax_y6, si_isa.inctax_y7,"
                            + "si_isa.adjust_y1, si_isa.adjust_y2, si_isa.adjust_y3, si_isa.adjust_y4, si_isa.adjust_y5, si_isa.adjust_y6, si_isa.adjust_y7,"
                            + "si_isa.xord_y1, si_isa.xord_y2, si_isa.xord_y3, si_isa.xord_y4, si_isa.xord_y5, si_isa.xord_y6, si_isa.xord_y7 "
                            // Cashflow Quarterly
                            + ",tco_q1,tco_q2,tco_q3,tco_q4,tco_q5,tco_q6,tco_q7,tco_q8 "
                            + ",ce_q1,ce_q2,ce_q3,ce_q4,ce_q5,ce_q6,ce_q7,ce_q8 "
                            + ",tci_q1,tci_q2,tci_q3,tci_q4,tci_q5,tci_q6,tci_q7,tci_q8 "
                            + ",tcf_q1,tcf_q2,tcf_q3,tcf_q4,tcf_q5,tcf_q6,tcf_q7,tcf_q8 "
                            + ",dep_cf_q1,dep_cf_q2,dep_cf_q3,dep_cf_q4,dep_cf_q5,dep_cf_q6,dep_cf_q7,dep_cf_q8 "
                            + ",cfps_q1,cfps_q2,cfps_q3,cfps_q4,cfps_q5,cfps_q6,cfps_q7,cfps_q8 "
                            + ",fcfps_q1,fcfps_q2,fcfps_q3,fcfps_q4,fcfps_q5,fcfps_q6,fcfps_q7,fcfps_q8 "
                            + ",divpaid_q1,divpaid_q2,divpaid_q3,divpaid_q4,divpaid_q5,divpaid_q6,divpaid_q7,divpaid_q8 "
                            + ",ere_q1,ere_q2,ere_q3,ere_q4,ere_q5,ere_q6 ,ere_q7,ere_q8"
                            // Cashflow Annual
                            + ",tco_y1, tco_y2, tco_y3, tco_y4, tco_y5, tco_y6, tco_y7 "
                            + ", ce_y1, ce_y2, ce_y3, ce_y4, ce_y5, ce_y6, ce_y7 "
                            + ", tci_y1, tci_y2, tci_y3, tci_y4, tci_y5, tci_y6, tci_y7 "
                            + ",tcf_y1,tcf_y2,tcf_y3,tcf_y4,tcf_y5,tcf_y6,tcf_y7 "
                            + ",dep_cf_y1, dep_cf_y2, dep_cf_y3, dep_cf_y4, dep_cf_y5, dep_cf_y6, dep_cf_y7 "
                            + ", cfps_y1, cfps_y2, cfps_y3, cfps_y4, cfps_y5, cfps_y6, cfps_y7 "
                            + ", fcfps_y1, fcfps_y2, fcfps_y3, fcfps_y4, fcfps_y5, fcfps_y6,fcfps_y7 "
                            + ",divpaid_y1,divpaid_y2,divpaid_y3,divpaid_y4,divpaid_y5,divpaid_y6,divpaid_y7 "
                            + ",ere_y1,ere_y2,ere_y3,ere_y4,ere_y5,ere_y6 ,ere_y7,"
                            // PL - Continued
                            + "gopinc_q1,gopinc_q2,gopinc_q3,gopinc_q4,gopinc_q5,gopinc_q6,gopinc_q7,gopinc_q8, "
                            + "nit_q1,nit_q2,nit_q3,nit_q4,nit_q5,nit_q6,nit_q7,nit_q8,"
                            + "gopinc_y1,gopinc_y2,gopinc_y3,gopinc_y4,gopinc_y5,gopinc_y6,gopinc_y7,"
                            + "nit_y1,nit_y2,nit_y3,nit_y4,nit_y5,nit_y6,nit_y7, "
                            //PL Operating Expense = Tot Operating Expense - Cost of Goods Sold
                            //Quartertly
                            + "CAST(ISNULL(totexp_q1, 0) AS NUMERIC(22, 2)) - CAST(ISNULL(cgs_q1, 0) AS NUMERIC(22, 2)) as opexp_q1,"
                            + "CAST(ISNULL(totexp_q2, 0) AS NUMERIC(22, 2)) - CAST(ISNULL(cgs_q2, 0) AS NUMERIC(22, 2)) as opexp_q2,"
                            + "CAST(ISNULL(totexp_q3, 0) AS NUMERIC(22, 2)) - CAST(ISNULL(cgs_q3, 0) AS NUMERIC(22, 2)) as opexp_q3,"
                            + "CAST(ISNULL(totexp_q4, 0) AS NUMERIC(22, 2)) - CAST(ISNULL(cgs_q4, 0) AS NUMERIC(22, 2)) as opexp_q4,"
                            + "CAST(ISNULL(totexp_q5, 0) AS NUMERIC(22, 2)) - CAST(ISNULL(cgs_q5, 0) AS NUMERIC(22, 2)) as opexp_q5,"
                            + "CAST(ISNULL(totexp_q6, 0) AS NUMERIC(22, 2)) - CAST(ISNULL(cgs_q6, 0) AS NUMERIC(22, 2)) as opexp_q6,"
                            + "CAST(ISNULL(totexp_q7, 0) AS NUMERIC(22, 2)) - CAST(ISNULL(cgs_q7, 0) AS NUMERIC(22, 2)) as opexp_q7,"
                            + "CAST(ISNULL(totexp_q8, 0) AS NUMERIC(22, 2)) - CAST(ISNULL(cgs_q8, 0) AS NUMERIC(22, 2)) as opexp_q8,"
                            //Yearly
                            + "CAST(ISNULL(totexp_y1, 0) AS NUMERIC(22, 2)) - CAST(ISNULL(cgs_y1, 0) AS NUMERIC(22, 2)) as opexp_y1,"
                            + "CAST(ISNULL(totexp_y2, 0) AS NUMERIC(22, 2)) - CAST(ISNULL(cgs_y2, 0) AS NUMERIC(22, 2)) as opexp_y2,"
                            + "CAST(ISNULL(totexp_y3, 0) AS NUMERIC(22, 2)) - CAST(ISNULL(cgs_y3, 0) AS NUMERIC(22, 2)) as opexp_y3,"
                            + "CAST(ISNULL(totexp_y4, 0) AS NUMERIC(22, 2)) - CAST(ISNULL(cgs_y4, 0) AS NUMERIC(22, 2)) as opexp_y4,"
                            + "CAST(ISNULL(totexp_y5, 0) AS NUMERIC(22, 2)) - CAST(ISNULL(cgs_y5, 0) AS NUMERIC(22, 2)) as opexp_y5,"
                            + "CAST(ISNULL(totexp_y6, 0) AS NUMERIC(22, 2)) - CAST(ISNULL(cgs_y6, 0) AS NUMERIC(22, 2)) as opexp_y6,"
                            + "CAST(ISNULL(totexp_y7, 0) AS NUMERIC(22, 2)) - CAST(ISNULL(cgs_y7, 0) AS NUMERIC(22, 2)) as opexp_y7"
                            + " from "
                            + "si_ci join si_isq on si_ci.company_id = si_isq.company_id join "
                            + "si_isa on si_isq.company_id = si_isa.company_id join "
                            + "si_date on si_isa.company_id = si_date.company_id "
                            +"join si_cfq on si_isa.company_id = si_cfq.company_id "
                            +"join si_cfa on si_isa.company_id = si_cfa.company_id "
                            + " where si_ci.ticker ='"+ ticker + "'";

            using (sqlConn = new SqlConnection(Const.ConnectionString))
            {
                sqlAdapter = new SqlDataAdapter(qString, sqlConn);
                dataSet = new DataSet();
                sqlAdapter.Fill(dataSet);
            }

            return dataSet.Tables[0];
        }

        public static DataTable GetBalanaceSheet(string ticker)
        {
            SqlConnection sqlConn;
            SqlDataAdapter sqlAdapter;
            DataSet dataSet;
            string query = $@"select si_ci.company, 
                    si_ci.ticker, si_date.perend_q1, si_date.perend_q2, si_date.perend_q3, si_date.perend_q4, si_date.perend_q5, si_date.perend_q6, si_date.perend_q7, 
                    si_date.perend_q8, si_date.perend_y1, si_date.perend_y2, si_date.perend_y3, si_date.perend_y4, si_date.perend_y5, si_date.perend_y6, si_date.perend_y7, 
                    si_bsa.*,si_bsq.* 
                    from si_ci 
                    inner join si_date on si_ci.company_id=si_date.company_id 
                    inner join si_bsa on si_ci.company_id=si_bsa.company_id 
                    inner join si_bsq on si_ci.company_id=si_bsq.company_id 
                    where si_ci.ticker = '{ticker}'";
            using (sqlConn = new SqlConnection(Const.ConnectionString))
            {
                sqlAdapter = new SqlDataAdapter(query, sqlConn);
                dataSet = new DataSet();
                sqlAdapter.Fill(dataSet);
            }

            return dataSet.Tables[0];
        }

        public static DataTable GetTickers()
        {
            DataSet tickerDS;
            using (SqlConnection sqlConn = new SqlConnection(Const.ConnectionString))
            {
                string tickerQuery = "select LTRIM(RTRIM(ticker)) as ticker from si_ci order by ticker";
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(tickerQuery, sqlConn);
                tickerDS = new DataSet();
                sqlAdapter.Fill(tickerDS);
            }

            return tickerDS.Tables[0];
        }

        public static DataTable GetTableFromDbf(string tableName)
        {
            string dbfDirectory = GetDBFDirectory(tableName);
            string constr = $"Provider=VFPOLEDB;Data Source={dbfDirectory};"; //Extended Properties=dBASE IV;User ID=Admin;Password=;
            using (OleDbConnection con = new OleDbConnection(constr))
            {
                string sqlQuery = $"select * from {tableName}";// + fileName;
                OleDbCommand cmd = new OleDbCommand(sqlQuery, con);
                con.Open();
                DataSet ds = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(ds);
                var tab = ds.Tables[0];

                //DataTable schemaInfo = con.GetSchema(); // available schemas
                //foreach (DataRow row in schemaInfo.Rows)
                //{
                //    string schema = (string)row[0];

                //    DataTable t = con.GetSchema(schema);

                //}
                return tab;
            }
        }

        private static string GetDBFDirectory(string tableName)
        {
            foreach (var dbfPath in Const.DBFPaths)
            {
                if (File.Exists(Path.Combine(dbfPath, tableName + ".dbf")))
                    return dbfPath;
            }
            return null;
        }
    }
}
