using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSS
{
    public class News
    {
        //Adres RSS: http://rss.wp.pl/s,kina,index.html

        public int NewsID { get; private set; }
        public string TitleOfNews { get; set; }
        public string LinkToWebsite { get; set; }
        public DateTime DateOfPublication { get; set; }
        public Description DescriptionOfNews { get; set; }

        public News(int newsId, string title, string description, string link, string pubdate)
        {
            this.NewsID = newsId;
            this.TitleOfNews = title;
            this.LinkToWebsite = link;
            this.DateOfPublication = DateTime.Parse(pubdate);
            this.DescriptionOfNews = new Description(description);
        }
    }
}
