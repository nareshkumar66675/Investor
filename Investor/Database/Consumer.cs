using Investor.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Database
{
    public class Consumer
    {
        public void Start()
        {
            while(!Queue.Collection.IsCompleted)
            {
                TableData tableData = null;
                Queue.Collection.TryTake(out tableData,1000);

                if(tableData !=null)
                {
                    ConsumeData(tableData);
                }
            }

            Queue.Collection = null;
        }

        private bool ConsumeData(TableData tableData)
        {
            bool status = true;
            try
            {
                DBOperation.ExecuteNonQuery(tableData.CreateTableScript);

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
