using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSS
{
    public static class LinksDB
    {
        public static List<Region> GetChannels()
        {
            return new List<Region>
            {    
                    new Region (1, "Bielsko - Biała", "http://film.wp.pl/rss.xml?id=7"),
                    new Region (2, "Bydgoszcz", "http://film.wp.pl/rss.xml?id=10"),
                    new Region (3, "Gdańsk", "http://film.wp.pl/rss.xml?id=27"),
                    new Region (4, "Gdynia", "http://film.wp.pl/rss.xml?id=28"),
                    new Region (5, "Katowice", "http://film.wp.pl/rss.xml?id=44"),
                    new Region (6, "Lublin", "http://film.wp.pl/rss.xml?id=60"),
                    new Region (7, "Łódź", "http://film.wp.pl/rss.xml?id=135"),
                    new Region (8, "Olsztyn", "http://film.wp.pl/rss.xml?id=71"),
                    new Region (9, "Poznań", "http://film.wp.pl/rss.xml?id=81"),
                    new Region (10, "Rzeszów", "http://film.wp.pl/rss.xml?id=94"),
                    new Region (11, "Sopot", "http://film.wp.pl/rss.xml?id=100"),
                    new Region (12, "Szczecin", "http://film.wp.pl/rss.xml?id=106"),
                    new Region (13, "Toruń", "http://film.wp.pl/rss.xml?id=118"),
                    new Region (14, "Warszawa", "http://film.wp.pl/rss.xml?id=123"),
                    new Region (15, "Wrocław", "http://film.wp.pl/rss.xml?id=127"),
                    new Region (16, "Zakopane", "http://film.wp.pl/rss.xml?id=130")
            };
        }


    }
}
