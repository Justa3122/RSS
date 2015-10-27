using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSS
{
    public class News
    {
        public int NewsID { get; private set; }
        public string TitleOfNews { get; private set; }
        public string LinkToWebsite { get; private set; }
        public DateTime DateOfPublication { get; private set; }
        public Description DescriptionOfNews { get; private set; }

        public int RegionID { get; set; }
        public Region Region { get; set; }

        public News()
        {

        }
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
