using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Util
{
    public class ChartInfo
    {
        public int nSeries;
        public int nvalues; // # of values in easch series
        public string[] colName;
        public string[] legend;
        public int[] linewidth;
        public int[,] rgb;
        public string perend;
    }
}
