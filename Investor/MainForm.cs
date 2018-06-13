
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
using Investor.Util;

namespace Investor
{
    public class CharttInfo
    {
        public int nSeries;
        public int nvalues; // # of values in easch series
        public string[] colName;
        public string[] legend;
        public int[] linewidth;
        public int[,] rgb;
        public string perend;
    }
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



        // md5 hash object
        public MD5 md5;
        public MainForm()
        {
            InitializeComponent();
            // initialize sql db connection
            //sqlConnStr = "Data Source=" + Environment.MachineName + @"\SQLEXPRESS;Initial Catalog=Investor;Integrated Security=True";
            sqlConnStr = Const.ConnectionString; //string.Format(ConfigurationManager.ConnectionStrings["Investor"].ConnectionString, Environment.MachineName);
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
            FundamentalCharts fundamentalCharts = new FundamentalCharts();

            fundamentalCharts.ShowChart(tickerComboBox.Text);

            fundamentalCharts.Show();
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
