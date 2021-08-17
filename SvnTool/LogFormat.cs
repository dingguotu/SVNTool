using System;
using System.ComponentModel;

namespace SvnTool
{
    public class LogFormat
    {
        [DisplayName("作者")]
        public string author { get; set; }
        [DisplayName("文件路径")]
        public string fileName { get; set; }
        [DisplayName("增加的行数")]
        public int appendLines { get; set; }
        [DisplayName("删除的行数")]
        public int removeLines { get; set; }
        [DisplayName("总行数")]
        public int totalLines { get; set; }
        [DisplayName("签入时间")]
        public DateTime checkTime { get; set; }
    }

    public class LogSummary
    {
        [DisplayName("作者")]
        public string author { get; set; }
        [DisplayName("增加的行数")]
        public int appendLines { get; set; }
        [DisplayName("删除的行数")]
        public int removeLines { get; set; }
        [DisplayName("总行数")]
        public int totalLines { get; set; }
    }
}
