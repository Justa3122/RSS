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
        public List<News> newsList = new List<News>();
        public Channel channelInfo;
        private XmlReader _xmlReader;

        /// <summary>
        /// Wczytuje najnowsze wiadomości i dodaje je do list newsList
        /// </summary>
        /// <param name="channelLink">Link do kanału, z którego zostaną pobrane wiadomości</param>
        public void ReadNews(string channelLink)
        {
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
                            channelInfo.title = _xmlReader.Value.Trim();
                            break;
                        case "link":
                            _xmlReader.Read();
                            channelInfo.link = _xmlReader.Value.Trim();
                            break;
                        case "description":
                            _xmlReader.Read();
                            channelInfo.description = _xmlReader.Value.Trim();
                            break;
                        case "language":
                            _xmlReader.Read();
                            channelInfo.language = _xmlReader.Value.Trim();
                            break;
                        case "copyright":
                            _xmlReader.Read();
                            channelInfo.copyright = _xmlReader.Value.Trim();
                            break;
                        case "pubDate":
                            _xmlReader.Read();
                            channelInfo.pubdate = _xmlReader.Value.Trim();
                            break;
                        case "generator":
                            _xmlReader.Read();
                            channelInfo.generator = _xmlReader.Value.Trim();
                            break;
                        case "webMaster":
                            _xmlReader.Read();
                            channelInfo.webmaster = _xmlReader.Value.Trim();
                            return;
                    }
                }
            }
        }
    }
}
