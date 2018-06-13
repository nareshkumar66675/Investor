
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using SoftwareFX.ChartFX;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        // dbf connection members
        public const string dbfDir = @"C:\Program Files (x86)\Stock Investor\Professional\";
        public string[] dbfDirs = new string[2];

        public Dictionary<string, string[]> dbfToTableDict;

        public const string dbfConnPre = "Provider=vfpoledb.1; Data Source=";

        // sql connection members
        public string sqlConnStr;
        public SqlConnection sqlConn;
        public SqlDataAdapter sqlAdapter;
        public DataSet dataSet;

        // query constants
        public const string tickerQuery = "select LTRIM(RTRIM(ticker)) as ticker from si_ci order by ticker";

        // consts
        public const int nYears = 7;
        public const int nQuarters = 8;
        public const int TABLE_NAME_IND = 0;
        public const int PK_NAME_IND = 1;
        public const int COLSPEC_IND = 2;
        public struct CharttInfo
        {
            public int nSeries;
            public int nvalues; // # of values in easch series
            public string[] colName;
            public string[] legend;
            public int[] linewidth;
            public int[,] rgb;
            public string perend;
        }



        // md5 hash object
        public MD5 md5;
        public MainForm()
        {
            InitializeComponent();
            // initialize sql db connection
            sqlConnStr = "Data Source=" + Environment.MachineName + @"\SQLEXPRESS;Initial Catalog=Investor;Integrated Security=True";
            sqlConn = new SqlConnection(sqlConnStr);
            try
            {
                sqlConn.Open();
            }
            catch (Exception ex)
            {
                //sqlConnStr = "Server=" + Interaction.InputBox("Enter server name/address:") + "; Database=Investor; User Id=" + Interaction.InputBox("Enter user name:") + "; Password=" + Interaction.InputBox("Enter password:") + ";";
                //try
                //{
                //    sqlConn = new SqlConnection(sqlConnStr);
                //    sqlConn.Open();
                //}
                //catch (InvalidOperationException exc)
                //{
                //    Interaction.MsgBox("Unable to connect to given server, please restart the program");
                //    return;
                //}
                //catch (SqlException exc)
                //{
                //    Interaction.MsgBox("Entered an invalid password or it needs to be reset. Do this and restart the program.");
                //    return;
                //}
                //catch (Exception exc)
                //{
                //    Interaction.MsgBox("Unknown error. Please try again.");
                //}
                throw ex;
            }

            // initialize the dbf directory names
            dbfDirs[0] = dbfDir + @"Static\";
            dbfDirs[1] = dbfDir + @"Dbfs\";

            // initialize the dbfToTableDict which holds an association between the dbf filename, table name, table primary key name, and SQL types for each column
            dbfToTableDict = new Dictionary<string, string[]>();

            foreach (var line in System.IO.File.ReadAllLines(@"overallstructure.txt"))
            {
                string[] cols = line.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                dbfToTableDict.Add(cols[0], new List<string>(cols).GetRange(1, cols.Length - 1).ToArray());
            }

            // initialize md5
            md5 = MD5.Create();

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
                           + "from "
                            + "si_ci join si_isq on si_ci.company_id = si_isq.company_id join "
                            + "si_isa on si_isq.company_id = si_isa.company_id join "
                            + "si_date on si_isa.company_id = si_date.company_id "
                        + "order by si_ci.ticker";

            sqlAdapter = new SqlDataAdapter(qString, sqlConn);
            dataSet = new DataSet();
            sqlAdapter.Fill(dataSet);

            // initialize the ticker combobox with ticker symbols queried from the DB with the sqlAdapter
            sqlAdapter = new SqlDataAdapter(tickerQuery, sqlConn);
            DataSet tickerDS;
            tickerDS = new DataSet();
            sqlAdapter.Fill(tickerDS);

            tickerComboBox.DataSource = tickerDS.Tables[0];
            tickerComboBox.ValueMember = "ticker";
            tickerComboBox.DisplayMember = "ticker";


            // close sqlconn
            sqlConn.Close();
        }

        private byte[] getHashForRow(DataRow row) // returns the computed hash value for the datarow, returns a 128-bit (16-byte) byte array
        {
            string dataStr = "";
            // get the value of each column as a concatenated string
            foreach (var col in row.ItemArray)
                dataStr = dataStr + col.ToString();
            // return the hash value for the string
            return md5.ComputeHash(System.Text.Encoding.Unicode.GetBytes(dataStr));
        }

        private void dbfToSQLTables()
        {
            System.IO.FileInfo fileInfo;
            string fileName;
            string tableName;

            //Collection threads = new Collection();

            // disable buttons
            updateButton.Enabled = false;

            // iterate through each directory with dbf files
            foreach (string dir in dbfDirs)
            {
                {
                    //var withBlock = My.Computer;
                    foreach (string file in Directory.GetFiles(dir))
                    {
                        fileInfo = Microsoft.VisualBasic.FileIO.FileSystem.GetFileInfo(file.ToString());
                        if (fileInfo.Extension.ToLower() == ".dbf")
                        {
                            fileName = fileInfo.Name;
                            tableName = fileInfo.Name.Replace(fileInfo.Extension, "");
                            // skip if file is not in the dbf spec dictionary
                            if (dbfToTableDict.ContainsKey(fileName))
                            {
                                processLabel.Text = fileName + " transferring to " + tableName + " table, please wait...";
                                processLabel.Refresh();
                                System.Threading.Thread t = new System.Threading.Thread(() => dbfToSQLTable(dbfConnPre + dir, sqlConnStr, fileName));
                                t.Start();
                                t.Join();
                            }
                        }
                    }
                }
            }

            // 'wait for threads to complete
            // For Each t As Threading.Thread In threads
            // t.Join()
            // Next

            // reenable buttons
            updateButton.Enabled = true;

            // remove text and alert the completion of the transfer
            processLabel.Text = "";
            // Interaction.MsgBox("Transfer complete");
            MessageBox.Show("Transfer complete");
        }

        private void dbfToSQLTable(string dbfConnString, string sqlConnString, string dbfFileName)
        {

            // check if table spec exists
            if ((!dbfToTableDict.ContainsKey(dbfFileName)))
            {
                Console.WriteLine("Error: there is no table specification in the overall-structure.txt, tab-delimited file for dbf file: " + dbfFileName);
                return;
            }

            // table specification from dictionary
            string[] tableSpec = dbfToTableDict[dbfFileName];
            string table = tableSpec[TABLE_NAME_IND];
            string pk = tableSpec[PK_NAME_IND];
            string[] colSpec = new List<string>(tableSpec).GetRange(COLSPEC_IND, tableSpec.Length - 2).ToArray();

            // connections
            System.Data.OleDb.OleDbConnection dbfC = new System.Data.OleDb.OleDbConnection(dbfConnString);
            SqlConnection sqlC = new SqlConnection(sqlConnString);

            // opem connections
            dbfC.Open();
            sqlC.Open();

            // commands
            System.Data.OleDb.OleDbCommand dbfCommand = new System.Data.OleDb.OleDbCommand("select * from " + table, dbfC);
            SqlCommand sqlCommand = new SqlCommand("select * from " + table, sqlC);
            SqlCommand sqlTableExistsCommand = new SqlCommand("select * from sys.tables where name = '" + table + "' and type = 'U'", sqlC);
            SqlCommand sqlCreateTableCommand = new SqlCommand();

            // adapters
            System.Data.OleDb.OleDbDataAdapter dbfA = new System.Data.OleDb.OleDbDataAdapter(dbfCommand);
            SqlDataAdapter sqlA = new SqlDataAdapter(sqlTableExistsCommand);

            // dataset
            DataSet sqlDs = new DataSet();  // for getting records in the sql database
            DataSet dbfDs = new DataSet();  // for getting records in the dbf table
            DataSet ds = new DataSet();     // for generic queries

            // first fill the dataset to see if the table already exists
            sqlA.Fill(ds);

            // if the table doesn't exist, then create it
            if (!(ds.Tables[0].Rows.Count > 0))
            {
                string commStr = "create table " + table + " (";
                foreach (string col in colSpec)
                    commStr = commStr + col + ", ";
                commStr = commStr + "PRIMARY KEY (" + pk + "));";

                // set the command to create the table and execute it
                sqlCreateTableCommand.CommandText = commStr;
                sqlCreateTableCommand.Connection = sqlC;
                sqlCreateTableCommand.ExecuteNonQuery();
            }

            // clear the generic dataset
            ds.Reset();

            // change the sql adapter command
            sqlA.SelectCommand = sqlCommand;

            // now create the command builder
            SqlCommandBuilder sqlCommBuild = new SqlCommandBuilder(sqlA);

            // set the sql commands from the command builder
            sqlA.UpdateCommand = sqlCommBuild.GetUpdateCommand();
            sqlA.InsertCommand = sqlCommBuild.GetInsertCommand();
            sqlA.DeleteCommand = sqlCommBuild.GetDeleteCommand();

            // fill the schema for the sql dataset so the primary key is set
            // sqlA.FillSchema(sqlDs, SchemaType.Source, table)

            // fill the sql table schema to the dataset table schema
            sqlA.FillSchema(sqlDs, SchemaType.Source, table);

            // fill the datasets
            sqlA.Fill(sqlDs, table);
            dbfA.Fill(dbfDs);

            // for iterating through datatables
            DataRow newRow;
            DataRow oldRow;
            DataColumnCollection colHeaders = sqlDs.Tables[0].Columns;

            // update the sqlDs to contain the data in the dbfDs dataset
            foreach (DataRow rec in dbfDs.Tables[0].Rows)
            {
                oldRow = sqlDs.Tables[0].Rows.Find(rec[pk]);
                newRow = sqlDs.Tables[0].NewRow();
                if ((oldRow == null) || (!(BitConverter.ToString((byte[])oldRow["md5"]) == BitConverter.ToString(getHashForRow(rec)))))
                {
                    //delete the old row if exists
                    if ((oldRow != null))
                    {
                        oldRow.Delete();
                    }
                    //now for each column name, copy it's data from the dbf rec to the newRow in the sql dataset
                    foreach (DataColumn colHeader in colHeaders)
                    {
                        //if it is the md5 column, then calculate the hash value as a 128-bit byte array (16 bytes)
                        newRow[colHeader.ColumnName] = colHeader.ColumnName == "md5" ? getHashForRow(rec) : rec[colHeader.ColumnName];
                    }
                    //add the new row
                    sqlDs.Tables[0].Rows.Add(newRow);
                }
            }

            // name the ds table
            // sqlDs.Tables(0).TableName = table

            // create ds to db table mapping
            // sqlA.TableMappings.Add(table, table)

            // use dataset to update the table in the sql database
            Console.WriteLine("The number of rows updated: " + sqlA.Update(sqlDs, table));

            // close all connections
            dbfC.Close();
            sqlC.Close();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            dbfToSQLTables();
        }

        private void viewChartButton_Click(object sender, EventArgs e)
        {
            CharttInfo charttinfo = new CharttInfo();
            charttinfo.colName = new string[12];
            charttinfo.legend = new string[12];
            charttinfo.rgb = new int[12, 4];

            //create the chartview form
            var FundamentalCharts = new FundamentalCharts();
            //populate charts with data from the dataset
            DataRow[] selectedRows = null;
            //array of rows which will hold the row(s) selected
            //to store value of column
            object item = null;

            //get the dataset row with the given ticker
            selectedRows = dataSet.Tables[0].Select("ticker = '" + tickerComboBox.Text + "'");

            //   Start ChartForm ------------------------------------------------------------------------------------
            ////goto EndChartForm;mmcmc
            ChartForm chartForm = new ChartForm();

            chartForm.quarterlyChart.OpenData(COD.Values, 5, nYears);
            //set annual sales chart properties
            chartForm.quarterlyChart.Series[0].Legend = "Sales";
            chartForm.quarterlyChart.Series[1].Legend = "CGS";
            chartForm.quarterlyChart.Series[2].Legend = "TotOpExp";
            chartForm.quarterlyChart.Series[3].Legend = "EBit";
            chartForm.quarterlyChart.Series[4].Legend = "NetInc";
            chartForm.quarterlyChart.AxisY.LabelsFormat.Format = AxisFormat.Currency;
            chartForm.quarterlyChart.AxisX.TickMark = TickMark.Outside;
            // 'chartForm.QuarterlyChart.AxisX.LabelAngle = 45

            //set annualChart x-axis labels
            for (int i = nYears; i >= 1; i += -1)
            {
                item = selectedRows[0]["perend_y" + i.ToString()];
                if (((!object.ReferenceEquals(item, DBNull.Value)) && (!(i % 2 == 0))))
                {
                    chartForm.quarterlyChart.AxisX.Label[0 + (nYears - i)] = System.DateTime.Parse(item.ToString()).ToString("MM/yy");
                }
                else
                {
                    chartForm.quarterlyChart.AxisX.Label[0 + (nYears - i)] = "";
                }
            }

            // get sales
            for (int i = nYears; i >= 1; i += -1)
            {
                item = selectedRows[0]["sales_y" + i.ToString()];
                if (((!object.ReferenceEquals(item, DBNull.Value))))
                {
                    chartForm.quarterlyChart.Value[0, 0 + (nYears - i)] = Convert.ToDouble(item);
                    chartForm.quarterlyChart.Series[0].LineWidth = 3;
                    chartForm.quarterlyChart.Series[0].Color = System.Drawing.Color.FromArgb(50, 255, 0, 0);
                    chartForm.quarterlyChart.Series[0].LineWidth = 3;
                }
                else
                {
                    chartForm.quarterlyChart.Value[0, 0 + (nYears - i)] = 0; //null;
                }
            }

            //now get the annual cgs
            for (int i = nYears; i >= 1; i += -1)
            {
                item = selectedRows[0]["cgs_y" + i.ToString()];
                if (((!object.ReferenceEquals(item, DBNull.Value))))
                {
                    chartForm.quarterlyChart.Value[1, 0 + (nYears - i)] = Convert.ToDouble(item);
                    chartForm.quarterlyChart.Series[1].Color = System.Drawing.Color.Yellow;
                    chartForm.quarterlyChart.Series[1].LineWidth = 4;
                }
                else
                {
                    chartForm.quarterlyChart.Value[1, 0 + (nYears - i)] = 0;// null;
                }
            }

            //next the annual totextp
            for (int i = nYears; i >= 1; i += -1)
            {
                item = selectedRows[0]["totexp_y" + i.ToString()];
                if (((!object.ReferenceEquals(item, DBNull.Value))))
                {
                    chartForm.quarterlyChart.Value[2, 0 + (nYears - i)] = Convert.ToDouble(item);
                    chartForm.quarterlyChart.Series[2].LineWidth = 5;
                }
                else
                {
                    chartForm.quarterlyChart.Value[2, 0 + (nYears - i)] = 0;// null;
                }
            }

            //next the Net Income
            for (int i = nYears; i >= 1; i += -1)
            {
                item = selectedRows[0]["ebit_y" + i.ToString()];
                if (((!object.ReferenceEquals(item, DBNull.Value))))
                {
                    chartForm.quarterlyChart.Value[3, 0 + (nYears - i)] = Convert.ToDouble(item);
                    chartForm.quarterlyChart.Series[3].LineWidth = 6;
                }
                else
                {
                    chartForm.quarterlyChart.Value[3, 0 + (nYears - i)] = 0;//; null;
                }
            }

            //next the Net Income
            for (int i = nYears; i >= 1; i += -1)
            {
                item = selectedRows[0]["netinc_y" + i.ToString()];
                if (((!object.ReferenceEquals(item, DBNull.Value))))
                {
                    chartForm.quarterlyChart.Value[4, 0 + (nYears - i)] = Convert.ToDouble(item);
                    chartForm.quarterlyChart.Series[4].LineWidth = 6;
                }
                else
                {
                    chartForm.quarterlyChart.Value[4, 0 + (nYears - i)] = 0; //;null;
                }
            }
            chartForm.quarterlyChart.CloseData(COD.Values);
        EndChartForm:

            // End ChartForm --------------------------------------------------------------------------------------------


            // Start Annual ------------------------------------------------------------------------
            //Dim FundamentalCharts As New FundamentalCharts

            FundamentalCharts.Annual_PL.OpenData(COD.Values, 5, nYears);

            //  goto skipAnnual;
            //set annual sales chart properties
            FundamentalCharts.Annual_PL.Series[0].Legend = "Sales";
            FundamentalCharts.Annual_PL.Series[1].Legend = "CGS";
            FundamentalCharts.Annual_PL.Series[2].Legend = "TotOpExp";
            FundamentalCharts.Annual_PL.Series[3].Legend = "EBit";
            FundamentalCharts.Annual_PL.Series[4].Legend = "NetInc";
            FundamentalCharts.Annual_PL.AxisY.LabelsFormat.Format = AxisFormat.Currency;
            FundamentalCharts.Annual_PL.AxisX.TickMark = TickMark.Outside;
            //FundamentalCharts.Annual_PL.AxisX.LabelAngle = 45
            FundamentalCharts.Annual_PL.MarkerShape = MarkerShape.None;

            //set annualChart x-axis labels
            for (int i = nYears; i >= 1; i += -1)
            {
                item = selectedRows[0]["perend_y" + i.ToString()];
                if (((!object.ReferenceEquals(item, DBNull.Value)) && (!(i % 2 == 0))))
                {
                    FundamentalCharts.Annual_PL.AxisX.Label[0 + (nYears - i)] = System.DateTime.Parse(item.ToString()).ToString("MM/yy");
                }
                else
                {
                    FundamentalCharts.Annual_PL.AxisX.Label[0 + (nYears - i)] = "";
                }
            }

            // get sales
            for (int i = nYears; i >= 1; i += -1)
            {
                item = selectedRows[0]["sales_y" + i.ToString()];
                if (((!object.ReferenceEquals(item, DBNull.Value))))
                {
                    FundamentalCharts.Annual_PL.Value[0, 0 + (nYears - i)] = Convert.ToDouble(item);
                    FundamentalCharts.Annual_PL.Series[0].LineWidth = 3;
                    FundamentalCharts.Annual_PL.Series[0].Color = System.Drawing.Color.FromArgb(50, 255, 0, 0);
                    FundamentalCharts.Annual_PL.Series[0].LineWidth = 3;
                }
                else
                {
                    FundamentalCharts.Annual_PL.Value[0, 0 + (nYears - i)] = 0; // null;
                }
            }

            //now get the annual cgs
            for (int i = nYears; i >= 1; i += -1)
            {
                item = selectedRows[0]["cgs_y" + i.ToString()];
                if (((!object.ReferenceEquals(item, DBNull.Value))))
                {
                    FundamentalCharts.Annual_PL.Value[1, 0 + (nYears - i)] = Convert.ToDouble(item);
                    FundamentalCharts.Annual_PL.Series[1].Color = System.Drawing.Color.Yellow;
                    FundamentalCharts.Annual_PL.Series[1].LineWidth = 4;
                }
                else
                {
                    FundamentalCharts.Annual_PL.Value[1, 0 + (nYears - i)] = 0; // null;
                }
            }

            //next the annual totextp
            for (int i = nYears; i >= 1; i += -1)
            {
                item = selectedRows[0]["totexp_y" + i.ToString()];
                if (((!object.ReferenceEquals(item, DBNull.Value))))
                {
                    FundamentalCharts.Annual_PL.Value[2, 0 + (nYears - i)] = Convert.ToDouble(item);
                    FundamentalCharts.Annual_PL.Series[2].LineWidth = 5;
                }
                else
                {
                    FundamentalCharts.Annual_PL.Value[2, 0 + (nYears - i)] = 0; // null;
                }
            }

            //next the Net Income
            for (int i = nYears; i >= 1; i += -1)
            {
                item = selectedRows[0]["ebit_y" + i.ToString()];
                if (((!object.ReferenceEquals(item, DBNull.Value))))
                {
                    FundamentalCharts.Annual_PL.Value[3, 0 + (nYears - i)] = Convert.ToDouble(item);
                    FundamentalCharts.Annual_PL.Series[3].LineWidth = 6;
                }
                else
                {
                    FundamentalCharts.Annual_PL.Value[3, 0 + (nYears - i)] = 0; // null;
                }
            }

            //next the Net Income
            for (int i = nYears; i >= 1; i += -1)
            {
                item = selectedRows[0]["netinc_y" + i.ToString()];
                if (((!object.ReferenceEquals(item, DBNull.Value))))
                {
                    FundamentalCharts.Annual_PL.Value[4, 0 + (nYears - i)] = Convert.ToDouble(item);
                    FundamentalCharts.Annual_PL.Series[4].LineWidth = 6;
                }
                else
                {
                    FundamentalCharts.Annual_PL.Value[4, 0 + (nYears - i)] = 0; // null;
                }
            }
            FundamentalCharts.Annual_PL.CloseData(COD.Values);
        skipAnnual:


            //End Annual ------------------------------------------------------------------------------------------------



            //Now start Quarterly Charts --------------------------------------------------------------------------------
            FundamentalCharts.Q_PL.OpenData(COD.Values, 5, nQuarters);

            //goto skipp;

            //quarterly chart properties
            FundamentalCharts.Q_PL.Series[0].Legend = "Sales";
            FundamentalCharts.Q_PL.Series[1].Legend = "CGS";
            FundamentalCharts.Q_PL.Series[2].Legend = "Totexp";
            FundamentalCharts.Q_PL.Series[3].Legend = "ebit";
            FundamentalCharts.Q_PL.Series[4].Legend = "netinc";

            FundamentalCharts.Q_PL.AxisY.LabelsFormat.Format = AxisFormat.Currency;
            FundamentalCharts.Q_PL.AxisX.TickMark = TickMark.Outside;
            FundamentalCharts.Q_PL.AxisX.LabelAngle = 45;

            //set quarterlyChart x-axis labels

            for (int i = nQuarters; i >= 1; i += -1)
            {
                item = selectedRows[0]["perend_q" + i.ToString()];
                if (((!object.ReferenceEquals(item, DBNull.Value)) && (i % 2 == 0)))
                {
                    FundamentalCharts.Q_PL.AxisX.Label[0 + (nQuarters - i)] = System.DateTime.Parse(item.ToString()).ToString("MM/yyyy");
                }
                else
                {
                    FundamentalCharts.Q_PL.AxisX.Label[0 + (nQuarters - i)] = "";
                }
            }

            //quarterly sales
            for (int i = nQuarters; i >= 1; i += -1)
            {
                item = selectedRows[0]["sales_q" + i.ToString()];
                if (((!object.ReferenceEquals(item, DBNull.Value))))
                {
                    FundamentalCharts.Q_PL.Value[0, 0 + (nQuarters - i)] = Convert.ToDouble(item);
                }
                else
                {
                    FundamentalCharts.Q_PL.Value[0, 0 + (nQuarters - i)] = 0; // null;
                }
            }

            //quarterly cgs
            for (int i = nQuarters; i >= 1; i += -1)
            {
                item = selectedRows[0]["cgs_q" + i.ToString()];
                if (((!object.ReferenceEquals(item, DBNull.Value))))
                {
                    FundamentalCharts.Q_PL.Value[1, 0 + (nQuarters - i)] = Convert.ToDouble(item);
                }
                else
                {
                    FundamentalCharts.Q_PL.Value[1, 0 + (nQuarters - i)] = 0; // null;
                }
            }

            //  quarterly totextp
            for (int i = nQuarters; i >= 1; i += -1)
            {
                item = selectedRows[0]["totexp_q" + i.ToString()];
                if (((!object.ReferenceEquals(item, DBNull.Value))))
                {
                    FundamentalCharts.Q_PL.Value[2, 0 + (nQuarters - i)] = Convert.ToDouble(item);
                }
                else
                {
                    FundamentalCharts.Q_PL.Value[2, 0 + (nQuarters - i)] = 0; // null;
                }
            }

            //  quarterly ebit
            for (int i = nQuarters; i >= 1; i += -1)
            {
                item = selectedRows[0]["ebit_q" + i.ToString()];
                if (((!object.ReferenceEquals(item, DBNull.Value))))
                {
                    FundamentalCharts.Q_PL.Value[3, 0 + (nQuarters - i)] = Convert.ToDouble(item);
                }
                else
                {
                    FundamentalCharts.Q_PL.Value[3, 0 + (nQuarters - i)] = 0; // null;
                }
            }

            //  quarterly netinc
            for (int i = nQuarters; i >= 1; i += -1)
            {
                item = selectedRows[0]["netinc_q" + i.ToString()];
                if (((!object.ReferenceEquals(item, DBNull.Value))))
                {
                    FundamentalCharts.Q_PL.Value[4, 0 + (nQuarters - i)] = Convert.ToDouble(item);
                }
                else
                {
                    FundamentalCharts.Q_PL.Value[4, 0 + (nQuarters - i)] = 0; // null;
                }
            }
        skipp:

            // FundamentalCharts.Q_PL.CloseData(COD.Values)

            //set form title and label
            FundamentalCharts.Text = tickerComboBox.Text;
            // FundamentalCharts.tickerLabel.Text = Trim(selectedRows(0).Item("company").ToString()) & " - " & tickerComboBox.Text

            //
            //goTo temp
            //Plot Quarterly
            charttinfo.nSeries = 5;
            charttinfo.nvalues = 8;
            charttinfo.perend = "perend_q";
            charttinfo.colName[0] = "sales_q";
            charttinfo.colName[1] = "cgs_q";
            charttinfo.colName[2] = "totexp_q";
            charttinfo.colName[3] = "ebit_q";
            charttinfo.colName[4] = "netinc_q";
            charttinfo.rgb[0, 0] = 255;
            charttinfo.rgb[0, 1] = 0;
            charttinfo.rgb[0, 2] = 255;
            charttinfo.rgb[0, 3] = 0;
            charttinfo.rgb[1, 0] = 50;
            charttinfo.rgb[1, 1] = 255;
            charttinfo.rgb[1, 2] = 0;
            charttinfo.rgb[1, 3] = 0;
            charttinfo.rgb[2, 0] = 255;
            charttinfo.rgb[2, 1] = 255;
            charttinfo.rgb[2, 2] = 0;
            charttinfo.rgb[2, 3] = 0;
            charttinfo.rgb[3, 0] = 50;
            charttinfo.rgb[3, 1] = 0;
            charttinfo.rgb[3, 2] = 0;
            charttinfo.rgb[3, 3] = 255;
            charttinfo.rgb[4, 0] = 255;
            charttinfo.rgb[4, 1] = 0;
            charttinfo.rgb[4, 2] = 0;
            charttinfo.rgb[4, 3] = 255;
            charttinfo.legend[0] = "Sales";
            charttinfo.legend[1] = "CGS";
            charttinfo.legend[2] = "OpExp";
            charttinfo.legend[3] = "EBIT";
            charttinfo.legend[4] = "NetInc";
            PlotChart(selectedRows, FundamentalCharts.Q_PL, charttinfo);

            //Plot Annual
            charttinfo.nSeries = 5;
            charttinfo.nvalues = 7;
            charttinfo.perend = "perend_y";
            charttinfo.colName[0] = "sales_y";
            charttinfo.colName[1] = "cgs_y";
            charttinfo.colName[2] = "totexp_y";
            charttinfo.colName[3] = "ebit_y";
            charttinfo.colName[4] = "netinc_y";
            charttinfo.rgb[0, 0] = 255;
            charttinfo.rgb[0, 1] = 0;
            charttinfo.rgb[0, 2] = 255;
            charttinfo.rgb[0, 3] = 0;
            charttinfo.rgb[1, 0] = 50;
            charttinfo.rgb[1, 1] = 255;
            charttinfo.rgb[1, 2] = 0;
            charttinfo.rgb[1, 3] = 0;
            charttinfo.rgb[2, 0] = 255;
            charttinfo.rgb[2, 1] = 255;
            charttinfo.rgb[2, 2] = 0;
            charttinfo.rgb[2, 3] = 0;
            charttinfo.rgb[3, 0] = 50;
            charttinfo.rgb[3, 1] = 0;
            charttinfo.rgb[3, 2] = 0;
            charttinfo.rgb[3, 3] = 255;
            charttinfo.rgb[4, 0] = 255;
            charttinfo.rgb[4, 1] = 0;
            charttinfo.rgb[4, 2] = 0;
            charttinfo.rgb[4, 3] = 255;
            charttinfo.legend[0] = "Sales";
            charttinfo.legend[1] = "CGS";
            charttinfo.legend[2] = "OpExp";
            charttinfo.legend[3] = "EBIT";
            charttinfo.legend[4] = "NetInc";
            PlotChart(selectedRows, FundamentalCharts.Annual_PL, charttinfo);
        temp:
            //Plot Annual Expenses
            FundamentalCharts.A_Exp.OpenData(COD.Values, 10, 7);
            charttinfo.nSeries = 7;
            charttinfo.nvalues = 7;
            charttinfo.perend = "perend_y";
            charttinfo.colName[0] = "eps_q";
            charttinfo.colName[1] = "epscon_q";
            charttinfo.colName[2] = "epsd_q";
            charttinfo.colName[3] = "epsdc_q";
            charttinfo.colName[4] = "epsnd_q";
            charttinfo.colName[5] = "dps_q";
            charttinfo.colName[6] = "dpst_q";
            charttinfo.rgb[0, 0] = 255;
            charttinfo.rgb[0, 1] = 4;
            charttinfo.rgb[0, 2] = 114;
            charttinfo.rgb[0, 3] = 30;
            charttinfo.rgb[1, 0] = 50;
            charttinfo.rgb[1, 1] = 7;
            charttinfo.rgb[1, 2] = 177;
            charttinfo.rgb[1, 3] = 47;
            charttinfo.rgb[2, 0] = 255;
            charttinfo.rgb[2, 1] = 10;
            charttinfo.rgb[2, 2] = 246;
            charttinfo.rgb[2, 3] = 66;
            charttinfo.rgb[3, 0] = 50;
            charttinfo.rgb[3, 1] = 59;
            charttinfo.rgb[3, 2] = 247;
            charttinfo.rgb[3, 3] = 104;
            charttinfo.rgb[4, 0] = 255;
            charttinfo.rgb[4, 1] = 130;
            charttinfo.rgb[4, 2] = 250;
            charttinfo.rgb[4, 3] = 159;
            charttinfo.rgb[5, 0] = 50;
            charttinfo.rgb[5, 1] = 0;
            charttinfo.rgb[5, 2] = 0;
            charttinfo.rgb[5, 3] = 255;
            charttinfo.rgb[6, 0] = 255;
            charttinfo.rgb[6, 1] = 48;
            charttinfo.rgb[6, 2] = 142;
            charttinfo.rgb[6, 3] = 206;
            charttinfo.legend[0] = "eps";
            charttinfo.legend[1] = "epsC";
            charttinfo.legend[2] = "epsD";
            charttinfo.legend[3] = "espDC";
            charttinfo.legend[4] = "espDN";
            charttinfo.legend[5] = "divT";
            charttinfo.legend[6] = "divNS";
            PlotChart(selectedRows, FundamentalCharts.A_Exp, charttinfo);
            FundamentalCharts.A_Exp.CloseData(COD.Values);

            //Plot Annual EPS
            FundamentalCharts.A_EPS.OpenData(COD.Values, 7, 7);
            charttinfo.nSeries = 7;
            charttinfo.nvalues = 7;
            charttinfo.perend = "perend_y";
            charttinfo.colName[0] = "eps_y";
            charttinfo.colName[1] = "epscon_y";
            charttinfo.colName[2] = "epsd_y";
            charttinfo.colName[3] = "epsdc_y";
            charttinfo.colName[4] = "epsnd_y";
            charttinfo.colName[5] = "dps_y";
            charttinfo.colName[6] = "dpst_y";
            charttinfo.rgb[0, 0] = 255;
            charttinfo.rgb[0, 1] = 4;
            charttinfo.rgb[0, 2] = 114;
            charttinfo.rgb[0, 3] = 30;
            charttinfo.rgb[1, 0] = 50;
            charttinfo.rgb[1, 1] = 7;
            charttinfo.rgb[1, 2] = 177;
            charttinfo.rgb[1, 3] = 47;
            charttinfo.rgb[2, 0] = 255;
            charttinfo.rgb[2, 1] = 10;
            charttinfo.rgb[2, 2] = 246;
            charttinfo.rgb[2, 3] = 66;
            charttinfo.rgb[3, 0] = 50;
            charttinfo.rgb[3, 1] = 59;
            charttinfo.rgb[3, 2] = 247;
            charttinfo.rgb[3, 3] = 104;
            charttinfo.rgb[4, 0] = 255;
            charttinfo.rgb[4, 1] = 130;
            charttinfo.rgb[4, 2] = 250;
            charttinfo.rgb[4, 3] = 159;
            charttinfo.rgb[5, 0] = 50;
            charttinfo.rgb[5, 1] = 0;
            charttinfo.rgb[5, 2] = 0;
            charttinfo.rgb[5, 3] = 255;
            charttinfo.rgb[6, 0] = 255;
            charttinfo.rgb[6, 1] = 48;
            charttinfo.rgb[6, 2] = 142;
            charttinfo.rgb[6, 3] = 206;
            charttinfo.legend[0] = "eps";
            charttinfo.legend[1] = "epsC";
            charttinfo.legend[2] = "epsD";
            charttinfo.legend[3] = "espDC";
            charttinfo.legend[4] = "espDN";
            charttinfo.legend[5] = "divT";
            charttinfo.legend[6] = "divNS";
            PlotChart(selectedRows, FundamentalCharts.A_EPS, charttinfo);
            FundamentalCharts.A_EPS.CloseData(COD.Values);

            //Plot Quarterly EPS
            FundamentalCharts.Q_EPS.OpenData(COD.Values, 7, 7);
            charttinfo.nSeries = 7;
            charttinfo.nvalues = 7;
            charttinfo.perend = "perend_Q";
            charttinfo.colName[0] = "eps_q";
            charttinfo.colName[1] = "epscon_q";
            charttinfo.colName[2] = "epsd_q";
            charttinfo.colName[3] = "epsdc_q";
            charttinfo.colName[4] = "epsnd_q";
            charttinfo.colName[5] = "dps_q";
            charttinfo.colName[6] = "dpst_q";
            charttinfo.rgb[0, 0] = 255;
            charttinfo.rgb[0, 1] = 4;
            charttinfo.rgb[0, 2] = 114;
            charttinfo.rgb[0, 3] = 30;
            charttinfo.rgb[1, 0] = 50;
            charttinfo.rgb[1, 1] = 7;
            charttinfo.rgb[1, 2] = 177;
            charttinfo.rgb[1, 3] = 47;
            charttinfo.rgb[2, 0] = 255;
            charttinfo.rgb[2, 1] = 10;
            charttinfo.rgb[2, 2] = 246;
            charttinfo.rgb[2, 3] = 66;
            charttinfo.rgb[3, 0] = 50;
            charttinfo.rgb[3, 1] = 59;
            charttinfo.rgb[3, 2] = 247;
            charttinfo.rgb[3, 3] = 104;
            charttinfo.rgb[4, 0] = 255;
            charttinfo.rgb[4, 1] = 130;
            charttinfo.rgb[4, 2] = 250;
            charttinfo.rgb[4, 3] = 159;
            charttinfo.rgb[5, 0] = 50;
            charttinfo.rgb[5, 1] = 0;
            charttinfo.rgb[5, 2] = 0;
            charttinfo.rgb[5, 3] = 255;
            charttinfo.rgb[6, 0] = 255;
            charttinfo.rgb[6, 1] = 48;
            charttinfo.rgb[6, 2] = 142;
            charttinfo.rgb[6, 3] = 206;
            charttinfo.legend[0] = "eps";
            charttinfo.legend[1] = "epsC";
            charttinfo.legend[2] = "epsD";
            charttinfo.legend[3] = "espDC";
            charttinfo.legend[4] = "espDN";
            charttinfo.legend[5] = "divT";
            charttinfo.legend[6] = "divNS";
            PlotChart(selectedRows, FundamentalCharts.Q_EPS, charttinfo);
            FundamentalCharts.Q_EPS.CloseData(COD.Values);



            FundamentalCharts.Show();
            FundamentalCharts.Q_PL.CloseData(COD.Values);
        }
        private void PlotChart(DataRow[] selectedRows, SoftwareFX.ChartFX.Chart chart, CharttInfo charttinfo)
        {
            // Dim selectedrows As DataRow
            object item = null;
            int ii = 0;
            int iii = 0;
            int j = 0;

            string file_name = @"C:\Naresh\Projects\investor-2015\test.txt";
            using (System.IO.StreamWriter objwriter = new System.IO.StreamWriter(file_name))
            {
                ii = charttinfo.nvalues;
                iii = charttinfo.nSeries;
                j = 1;

                //set x-axis labels
                for (int i = ii; i >= 1; i += -1)
                {
                    item = selectedRows[0][charttinfo.perend + i.ToString()];
                    if (((!object.ReferenceEquals(item, DBNull.Value)) && (!(i % 2 == 0))))
                    {
                        chart.AxisX.Label[0 + (ii - i)] = System.DateTime.Parse(item.ToString()).ToString("MM/yy");
                    }
                    else
                    {
                        chart.AxisX.Label[0 + (ii - i)] = "";
                    }
                }
                chart.AxisY.LabelsFormat.Format = AxisFormat.Currency;
                chart.AxisX.TickMark = TickMark.Outside;
                chart.AxisX.LabelAngle = 0;



                //charttinfo.nSeries Step -1 'charttinfo.nSeries - 1  ' 2 To 2  '1 To charttinfo.nSeries
                for (j = 0; j <= (iii - 1); j++)
                {
                    //quarterly totextp
                    for (int i = ii; i >= 1; i += -1)
                    {
                        //stringg = charttinfo.colName(j)
                        item = selectedRows[0][charttinfo.colName[j] + i.ToString()];
                        if (((!object.ReferenceEquals(item, DBNull.Value))))
                        {
                            chart.Value[j, 0 + (ii - i)] = Convert.ToDouble(item);
                            objwriter.Write(item);
                        }
                        else
                        {
                            chart.Value[j, 0 + (ii - i)] = 0; // null;
                        }
                    }
                    objwriter.Write(Environment.NewLine);
                    chart.Series[j].LineWidth = 3;
                    chart.Series[j].Color = System.Drawing.Color.FromArgb(charttinfo.rgb[j, 0], charttinfo.rgb[j, 1], charttinfo.rgb[j, 2], charttinfo.rgb[j, 3]);
                    chart.Series[j].Legend = charttinfo.legend[j];
                }
            }
            
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            //start creating the query and dataset
            string queryString = null;
            queryString = "Select ticker, company, business from si_ci where business Like ";
            DataSet queryDS = null;
            queryDS = new DataSet();

            //check that there is at least some text entered in the first query box
            if ((string.IsNullOrEmpty(queryText1.Text)))
            {
                MessageBox.Show("There must be text entered To search");
                return;
            }

            //create query string
            queryString += "'%" + queryText1.Text + "%' ";
            if ((andOption1.Checked | orOption1.Checked) & (!string.IsNullOrEmpty(queryText2.Text)))
            {
                queryString += andOption1.Checked ? "and " : "or " + "business like '%" + queryText2.Text + "%' ";
            }
            if ((andOption2.Checked | orOption2.Checked) & (!string.IsNullOrEmpty(queryText3.Text)))
            {
                queryString += andOption1.Checked ? "and " : "or " + "business like '%" + queryText2.Text + "%' ";
            }

            //run the query
            sqlAdapter.SelectCommand.CommandText = queryString;
            sqlAdapter.Fill(queryDS);

            //now create the new query window with the gridview having the query result as the data source
            QueryForm queryWindow = null;
            queryWindow = new QueryForm();
            queryWindow.gridView.DataSource = queryDS.Tables[0];

            //update the count
            queryWindow.countLabel.Text = queryDS.Tables[0].Rows.Count.ToString();

            //finally show the queryWindows
            queryWindow.Show();

            //resize columns to max width
            queryWindow.gridView.AutoResizeColumns();
        }
    }
}
