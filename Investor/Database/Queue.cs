using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Database
{
    public enum Status
    {
        NotStarted,
        InProgress,
        RetrievedData,
        InsertedData,
        Completed,
        Failed
    }
    public static class Queue
    {
        static Queue()
        {
            Collection = new BlockingCollection<TableData>(5);
        }
        public static BlockingCollection<TableData> Collection { get; set; } 
    }

    public class TableData
    {
        public TableData() => Status = Status.NotStarted;

        public TableSpec TableSpec { get; set; } 

        public Status Status { get; set; }

        public string CreateTableScript { get; set; }

        public DataTable Data { get; set; }
    }
}
