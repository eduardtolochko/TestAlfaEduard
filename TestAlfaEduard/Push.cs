using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace TestAlfaEduard
{
    internal class Push
    {
        public IEnumerable<Channel> ReadXMLDataBase()
        ///Read data from a file using a data model.
        {
            string path = @"data.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(Channels));

            StreamReader reader = new StreamReader(path);
            var channels = (Channels)serializer.Deserialize(reader);
            reader.Close();
            Console.WriteLine("Данные отлично считаны!");

            return channels.ChannelList.Where(p => p.category.Contains("Политика")).OrderBy(p => DateTime.Parse(p.pubDate));
        }

        public IEnumerable<Channel> ReadXMLRegular()
        {
            string path = @"data.xml";
            using (StreamReader reader = new StreamReader(path))
            {
                string channels = reader.ReadToEnd();
                Console.WriteLine(channels);

                string patterntitle = @"<title>(.*)</title>";

                Regex regextitle = new Regex(patterntitle);

                MatchCollection matchestitle = regextitle.Matches(channels);
                foreach (Match match in matchestitle)
                {
                    Console.WriteLine(match.Value.Replace("title", ""));
                }

                string patternlink = @"<link>(.*)</link>";

                Regex regexlink = new Regex(patternlink);

                MatchCollection matcheslink = regexlink.Matches(channels);
                foreach (Match match in matcheslink)
                {
                    Console.WriteLine(match.Value.Replace("link", ""));
                }

                string patterndeskription = @"<description>(.*)</description>";

                Regex regexdeskription = new Regex(patterndeskription);

                MatchCollection matchesdeskription = regexdeskription.Matches(channels);
                foreach (Match match in matchesdeskription)
                {
                    Console.WriteLine(match.Value.Replace("deskription", ""));
                }

                string patterncategory = @"<category>(.*)</category>";

                Regex regexcategory = new Regex(patterncategory);

                MatchCollection matchescategory = regexcategory.Matches(channels);
                foreach (Match match in matchescategory)
                {
                    Console.WriteLine(match.Value.Replace("category", ""));
                }

                string patternpubDate = @"<pubDate>(.*)</pubDate>";

                Regex regexpubDate = new Regex(patternpubDate);

                MatchCollection matchespubDate = regexpubDate.Matches(channels);
                foreach (Match match in matchespubDate)
                {
                    Console.WriteLine(match.Value.Replace("pubDate", "")); ;
                }

                var channelsList = new List<Channel>();

                channelsList.AddRange((IEnumerable<Channel>)matchestitle);
                channelsList.AddRange((IEnumerable<Channel>)matcheslink);
                channelsList.AddRange((IEnumerable<Channel>)matchesdeskription);
                channelsList.AddRange((IEnumerable<Channel>)matchescategory);
                channelsList.AddRange((IEnumerable<Channel>)matchespubDate);

                return channelsList.Where(p => p.category.Contains("Политика")).OrderBy(p => DateTime.Parse(p.pubDate));
            }
        }
    }
}