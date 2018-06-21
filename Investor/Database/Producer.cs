using Investor.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Database
{
    /// <summary>
    /// Creates DB Objects
    /// Based on the TableSpec produces table data
    ///    i) Creates Drop & Insert Script
    ///   ii) Reads Data from Dbf files 
    /// </summary>
    public class Producer
    {
        /// <summary>
        /// Starts the Process
        /// </summary>
        /// <param name="tableSpecs">Table Specification</param>
        /// <returns></returns>
        public async Task Start(List<TableSpec> tableSpecs)
        {
            foreach (var tableSpec in tableSpecs)
            {
                // Wait untill the data is ready
                var result = await ProduceData(tableSpec);

                // Add the data to the Queue for further processing
                Queue.Collection.TryAdd(result);
            }

            // Mark Queue as Complete - No more adding
            Queue.Collection.CompleteAdding();
        }

        private async Task<TableData> ProduceData(TableSpec tableSpec)
        {
            TableData tableData = new TableData();

            //Asynchronous Task
            Action action = () =>
               {
                   // Create Insert Script Asynchronously
                   var createScript = Task.Factory.StartNew(() => CreateTableScript(tableSpec));

                   // Read data from dbf Asynchronously
                   var getData = Task.Factory.StartNew(() => GetDataFromDBF(tableSpec));

                   // Wait for all tasks to complete
                   createScript.Wait();
                   getData.Wait();

                   // Store the data 
                   tableData.TableSpec = tableSpec;
                   tableData.CreateTableScript = createScript.Result;
                   tableData.Data = getData.Result;
                   tableData.Status = Status.RetrievedData;

               };
            await Task.Run(action);

            return tableData;
        }

        /// <summary>
        /// Create Drop & Create Script
        /// Based on the columns provided
        /// </summary>
        /// <param name="tableSpec">Table Specification</param>
        /// <returns>SQL Script</returns>
        private string CreateTableScript(TableSpec tableSpec)
        {
            StringBuilder script = new StringBuilder();

            script.Append($@"IF OBJECT_ID('{tableSpec.TableName}', 'U') IS NOT NULL 
            DROP TABLE {tableSpec.TableName}; ");
            script.AppendLine($"CREATE TABLE {tableSpec.TableName} ( ");
            foreach (var column in tableSpec.Columns)
            {
                script.Append(column);
                script.Append(',');
            }
            script.Append($"PRIMARY KEY ({tableSpec.PrimaryColumn}));");

            return script.ToString();
        }

        /// <summary>
        /// Get Data From DBF
        /// </summary>
        /// <param name="tableSpec">Table Specification</param>
        /// <returns>Data</returns>
        private DataTable GetDataFromDBF(TableSpec tableSpec)
        {
            return DBOperation.GetTableFromDbf(tableSpec.TableName);
        }
    }
}
