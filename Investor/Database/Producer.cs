using Investor.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Database
{
    public class Producer
    {
        public async Task Start(List<TableSpec> tableSpecs)
        {
            foreach (var tableSpec in tableSpecs)
            {
                var result = await ProduceData(tableSpec);

                Queue.Collection.TryAdd(result);
            }

            Queue.Collection.CompleteAdding();
        }

        private async Task<TableData> ProduceData(TableSpec tableSpec)
        {
            TableData tableData = new TableData();

            Action action = () =>
               {
                   var createScript = Task.Factory.StartNew(() => CreateInsertScript(tableSpec));

                   var getData = Task.Factory.StartNew(() => GetDataFromDBF(tableSpec));

                   createScript.Wait();
                   getData.Wait();

                   tableData.TableSpec = tableSpec;
                   tableData.CreateTableScript = createScript.Result;
                   tableData.Data = getData.Result;
                   tableData.Status = Status.RetrievedData;

               };
            await Task.Run(action);

            return tableData;
        }

        private string CreateInsertScript(TableSpec tableSpec)
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

        private DataTable GetDataFromDBF(TableSpec tableSpec)
        {
            return DBOperation.GetTableFromDbf(tableSpec.TableName);
        }
    }
}
