using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestAlfaEduard
{

    [Serializable()]
    public class Channel
    {
        [XmlElement("title")]
        public string title { get; set; }

        [XmlElement("link")]
        public string link { get; set; }

        [XmlElement("description")]
        public string description { get; set; }

        [XmlElement("category")]
        public string category { get; set; }

        [System.Xml.Serialization.XmlElement("pubDate")]
        public string pubDate { get; set; }
    }


    [XmlRootAttribute("channel")]
    public class Channels
    {
        [XmlElement("item")]
        public Channel[] ChannelList { get; set; }
    }

}
