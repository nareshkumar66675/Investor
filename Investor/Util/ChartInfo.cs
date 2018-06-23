using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Util
{
    public class LineStyle
    {
        public Color LineColor { get; set; }
        public DashStyle DashStyle { get; set; }

        public LineStyle(Color lineColor, DashStyle dashStyle)
        {
            LineColor = lineColor;
            DashStyle = dashStyle;
        }
    }
    public class ChartInfo
    {
        public int NSeries { get; set; }
        public int Nvalues { get; set; } // # of values in easch series
        public string[] colName;
        public string[] legend;
        public string Perend { get; set; }
        public List<LineStyle> LineStyles { get; set; }

        public ChartInfo()
        {
            colName = new string[12];
            legend = new string[12];
            LineStyles = new List<LineStyle>();
        }
    }
}
