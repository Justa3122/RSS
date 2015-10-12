using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RSS
{
    public class News
    {
        //Adres RSS: http://rss.wp.pl/s,kina,index.html
        public int NewsId { get; private set; }
        public string TitleOfNews { get; set; }
        public string Category { get; set; }
        public string LinkToWebsite { get; set; }
        public DateTime DateOfPublication { get; set; }
        public Description DescriptionOfNews { get; set; }

        public News()
        {

        }
        public News(int newsId, string title, string description, string link, string category, string pubdate)
        {
            this.NewsId = newsId;
            this.TitleOfNews = title;
            this.LinkToWebsite = link;
            this.Category = category;
            this.DateOfPublication = DateTime.Parse(pubdate);
            this.DescriptionOfNews = new Description(description);
        }
    }
}
