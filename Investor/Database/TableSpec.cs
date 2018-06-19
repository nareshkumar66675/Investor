using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Database
{
    public class TableSpec
    {
        public string FileName { get; set; }

        public string TableName { get; set; }

        public string PrimaryColumn { get; set; }

        public List<string> Columns { get; set; }
    }
}
