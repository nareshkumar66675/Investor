using Investor.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Database
{
    /// <summary>
    /// Consumes the data present in the queue
    /// </summary>
    public class Consumer
    {
        /// <summary>
        /// Starts a Process which consumes the data
        /// </summary>
        public void Start(IProgress<int> progress)
        {
            int completedCount = 0;
            // Iterate until Queue is empty
            while(!Queue.Collection.IsCompleted)
            {
                TableData tableData = null;

                // Retrieve data from Queue
                Queue.Collection.TryTake(out tableData,1000);

                if(tableData !=null)
                {
                    ConsumeData(tableData);
                    completedCount++;
                    progress?.Report(completedCount);
                }
            }

            // Clears the Queue
            Queue.Clear();

        }

        /// <summary>
        /// Consumes the data
        ///     i) Executes the Script
        ///    ii) Insert the data to the table
        /// </summary>
        /// <param name="tableData">Data</param>
        /// <returns></returns>
        private bool ConsumeData(TableData tableData)
        {
            bool status = true;
            try
            {
                // Executes the Drop & Insert Script
                DBOperation.ExecuteNonQuery(tableData.CreateTableScript);

                // Inserts the data to table
                DBOperation.BulkInsert(tableData);
            }
            catch (Exception ex)
            {
                status = false;
                throw ex;
            }
            return status;

        }
    }
}
