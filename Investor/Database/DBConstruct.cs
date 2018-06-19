using Investor.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
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


        private TableSpec GetTableSpec(string line)
        {
            TableSpec tableSpec = new TableSpec();

            var data = line.Split('\t').ToList();
            tableSpec.FileName = data[0]; // File name
            tableSpec.TableName = data[1];
            tableSpec.PrimaryColumn = data[2];
            tableSpec.Columns = new List<string>();
            tableSpec.Columns.AddRange(data.GetRange(3, data.Count - 3));

            return tableSpec;
        }
    }
}
