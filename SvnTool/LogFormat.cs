using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvnTool
{
    public class LogFormat
    {
        public string author { get; set; }
        public string fileName { get; set; }
        public int appendLines { get; set; }
        public int removeLines { get; set; }
        public int totalLines { get; set; }
        public DateTime checkTime { get; set; }
    }
}
