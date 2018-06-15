using Investor.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Util
{
    public static class Database
    {
        public static DataTable GetValuesByTicker(string ticker)
        {
            SqlConnection sqlConn ;
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
                            + " ,si_cfq.*,si_cfa.* "
                            + "from "
                            + "si_ci join si_isq on si_ci.company_id = si_isq.company_id join "
                            + "si_isa on si_isq.company_id = si_isa.company_id join "
                            + "si_date on si_isa.company_id = si_date.company_id "
                            +"join si_cfq on si_isa.company_id = si_cfq.company_id "
                            +"join si_cfa on si_isa.company_id = si_cfa.company_id "
                            + " where si_ci.ticker ='"+ticker
                        + "' order by si_ci.ticker";

            using (sqlConn = new SqlConnection(Const.ConnectionString))
            {
                sqlAdapter = new SqlDataAdapter(qString, sqlConn);
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
    }
}
