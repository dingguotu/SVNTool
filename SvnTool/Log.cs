using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SvnTool
{
    [XmlRoot(ElementName = "log")]
    public class Log
    {
        [XmlElement(ElementName = "logentry")]
        public List<Logentry> Logentry { get; set; }
    }

    [XmlRoot(ElementName = "logentry")]
    public class Logentry
    {
        [XmlAttribute(AttributeName = "revision")]
        public int ReVision { get; set; }

        [XmlElement(ElementName = "author")]
        public Author Author { get; set; }

        [XmlElement(ElementName = "date")]
        public Date Date { get; set; }

        [XmlElement(ElementName = "paths")]
        public Paths Paths { get; set; }

        [XmlElement(ElementName = "msg")]
        public Msg Msg { get; set; }
    }

    [XmlRoot(ElementName = "author")]
    public class Author
    {
        [XmlText]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "date")]
    public class Date
    {
        [XmlText]
        public DateTime Value { get; set; }
    }

    [XmlRoot(ElementName = "paths")]
    public class Paths
    {
        [XmlElement(ElementName = "path")]
        public List<Path> Path { get; set; }
    }

    [XmlRoot(ElementName = "path")]
    public class Path
    {
        [XmlAttribute(AttributeName = "text-mods")]
        public string TextMods { get; set; }
        [XmlAttribute(AttributeName = "kind")]
        public string Kind { get; set; }
        [XmlAttribute(AttributeName = "action")]
        public string Action { get; set; }
        [XmlAttribute(AttributeName = "prop-mods")]
        public string PropMods { get; set; }
        [XmlText]
        public string Value { get; set; }

    }

    [XmlRoot(ElementName = "msg")]
    public class Msg
    {
        [XmlText]
        public string Value { get; set; }
    }
}
