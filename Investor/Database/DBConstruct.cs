using Investor.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Database
{
    public class DBConstruct
    {
        public List<TableSpec> Specs { get; set; }

        public DBConstruct()
        {
            Specs = new List<TableSpec>();

        }

        /// <summary>
        /// Initializes the DB Construct - To Prepare for Database update
        /// </summary>
        public void Initialize()
        {
            //Read Table structure from Resource File
            var tableStructure = App.overall_structure;
            using (StringReader sr = new StringReader(tableStructure))
            {
                string line;
                
                while ((line = sr.ReadLine()) != null)
                {
                    Specs.Add(GetTableSpec(line));
                }
            }
        }

        public void StartDBUpdate(IProgress<int> progress)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Producer producer = new Producer();
            Consumer consumer = new Consumer();
            var tables = Specs; //Specs.Where(t => Const.TableNames.Any(x => x == t.TableName)).ToList();

            var produceTask = Task.Factory.StartNew(async () => await producer.Start(tables));

            var consumeTask = Task.Factory.StartNew(() => consumer.Start(progress));

            produceTask.Wait();
            consumeTask.Wait();
            sw.Stop();

            Console.WriteLine($"Elapsed : {sw.ElapsedMilliseconds}");
        }


        private TableSpec GetTableSpec(string line)
        {
            TableSpec tableSpec = new TableSpec();

            var data = line.Split(new string[] { "\t" },StringSplitOptions.RemoveEmptyEntries).ToList();
            tableSpec.FileName = data[0]; // File name
            tableSpec.TableName = data[1]; // Table Name
            tableSpec.PrimaryColumn = data[2]; // Primary Key Column Name
            tableSpec.Columns = new List<string>(); 
            tableSpec.Columns.AddRange(data.GetRange(3, data.Count - 3)); // List of columns with datatypes

            return tableSpec;
        }
    }
}
