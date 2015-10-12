using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RSS
{
    static class RSSReader
    {
        static void ReadNews(string channel)
        {
            XmlReader reader = XmlReader.Create(channel);
            News news;
            string title = "",
                   link = "",
                   category = "",
                   pubdate = "",
                   description = "";

            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    switch (reader.Name)
                    {
                        case "title":
                            reader.Read();
                            title = reader.Value.Trim();
                            break;
                        case "link":
                            reader.Read();
                            link = reader.Value.Trim();
                            break;
                        case "category":
                            reader.Read();
                            category = reader.Value.Trim();
                            break;
                        case "description":
                            reader.Read();
                            description = reader.Value.Trim();
                            break;
                        case "pubDate":
                            reader.Read();
                            pubdate = reader.Value.Trim();
                           // news = new News(title, description, link, category, pubdate); 
                            //Dopiero po wczytaniu elementu <pubDate> zostaje stworzony obiekt klasy,
                            //ponieważ ten element jest zawsze ostatnim elementem wiadomości
                            break;
                    }
                }
            }
            
        }
    }
}
