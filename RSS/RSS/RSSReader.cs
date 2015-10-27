using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RSS
{
    public struct Channel
    {
        public string title,
                      link,
                      description,
                      language,
                      copyright,
                      pubdate,
                      generator,
                      webmaster;
    }

    public class RSSReader
    {
        public Channel channel1;

        public RSSReader(string channelLink)
        {
            this.channelLink = channelLink;
        }

        private string channelLink;
        private XmlReader _xmlReader;
                
        
        /// <summary>
        /// Wczytuje najnowsze wiadomości i dodaje je do list newsList
        /// </summary>
        /// <param name="channelLink">Link do kanału, z którego zostaną pobrane wiadomości</param>
        public List<News> ReadNews()
        {
            List<News> newsList = new List<News>();

            _xmlReader = XmlReader.Create(channelLink);
            while (_xmlReader.Read())
            {
                if (_xmlReader.IsStartElement())
                {
                    switch (_xmlReader.Name)
                    {
                        case "item":
                            newsList.Add(ReadItem());
                            break;
                        case "channel":
                            ReadChannelInformation();
                            break;
                    }
                }
            }
            return newsList;
        }

        private News ReadItem()
        {
            News news;
            string title1 = "",
                   link1 = "",
                   pubdate1 = "",
                   description1 = "";

            while (_xmlReader.Read())
            {
                if (_xmlReader.IsStartElement())
                {
                    switch (_xmlReader.Name)
                    {
                        case "title":
                            _xmlReader.Read();
                            title1 = _xmlReader.Value.Trim();
                            break;
                        case "link":
                            _xmlReader.Read();
                            link1 = _xmlReader.Value.Trim();
                            break;
                        case "description":
                            _xmlReader.Read();
                            description1 = _xmlReader.Value.Trim();
                            break;
                        case "pubDate":
                            _xmlReader.Read();
                            pubdate1 = _xmlReader.Value.Trim();
                            news = new News(1, title1, description1, link1, pubdate1);
                            return news;
                    }
                }
            }
            news = new News(1, title1, description1, link1, pubdate1);
            return news;
        
        }
        private void ReadChannelInformation()
        {
            while (_xmlReader.Read())
            {
                if (_xmlReader.IsStartElement())
                {
                    switch (_xmlReader.Name)
                    {
                        case "title":
                            _xmlReader.Read();
                            channel1.title = _xmlReader.Value.Trim();
                            break;
                        case "link":
                            _xmlReader.Read();
                            channel1.link = _xmlReader.Value.Trim();
                            break;
                        case "description":
                            _xmlReader.Read();
                            channel1.description = _xmlReader.Value.Trim();
                            break;
                        case "language":
                            _xmlReader.Read();
                            channel1.language = _xmlReader.Value.Trim();
                            break;
                        case "copyright":
                            _xmlReader.Read();
                            channel1.copyright = _xmlReader.Value.Trim();
                            break;
                        case "pubDate":
                            _xmlReader.Read();
                            channel1.pubdate = _xmlReader.Value.Trim();
                            break;
                        case "generator":
                            _xmlReader.Read();
                            channel1.generator = _xmlReader.Value.Trim();
                            break;
                        case "webMaster":
                            _xmlReader.Read();
                            channel1.webmaster = _xmlReader.Value.Trim();
                            return;
                    }
                }
            }
        }
    }
}
