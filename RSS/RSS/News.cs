using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSS
{
    class News
    {
        //Adres RSS: http://rss.wp.pl/s.kina.index.html

        public int IdNews { get; set; }
        public string TitleOfNews { get; set; }
        public DateTime DateAddNews { get; set; }
        public string Message { get; set; }
        public string NameOfChannel { get; set; }
    }
}
