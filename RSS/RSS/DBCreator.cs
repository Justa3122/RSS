using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSS
{
    /// <summary>
    /// Tworzenie i wypełanianie bazy danych, przechowującej dane pobierane z kanału RSS
    /// </summary>
    public class DBCreator
    {
        public NewsDB db { get; private set; }

        public DBCreator()
        {
            InsertToDB();
        }


        private void InsertToDB()
        {
            try
            {
                db = new NewsDB(false);
                var fromDb = from n in db.News
                        from r in db.Region
                        select new
                        {
                            tytul = n.TitleOfNews,
                            linkacz = r.LinkToChannel
                        };

               foreach (var r in GetRegions())
                {
                    foreach (var n in r.News)
                    {
                            bool isInDatabase = false;
                            foreach (var fd in fromDb)
                            {
		                        if (fd.linkacz == r.LinkToChannel && fd.tytul == n.TitleOfNews)
                                {
                                    isInDatabase = true;
                                }
                            }
                            if (!isInDatabase)
                            {
                                db.Region.Add(r);
                            }
                    }
                }
                db.SaveChanges();
            }
            catch (Exception)
            {
                try
                {
                    db = new NewsDB(true);
                    var fromDb = from n in db.News
                                 from r in db.Region
                                 select new
                                 {
                                     tytul = n.TitleOfNews,
                                     linkacz = r.LinkToChannel
                                 };
                    foreach (var r in GetRegions())
                    {
                        foreach (var n in r.News)
                        {
                            bool isInDatabase = false;
                            foreach (var fd in fromDb)
                            {
                                if (fd.linkacz == r.LinkToChannel && fd.tytul == n.TitleOfNews)
                                {
                                    isInDatabase = true;
                                }
                            }
                            if (!isInDatabase)
                            {
                                db.Region.Add(r);
                            }
                        }
                    }
                    db.SaveChanges();
                }
                catch (Exception)
                {
                }
            }


        }
        private List<Region> GetRegions()
        {
            List<Region> regions = new List<Region>();
            foreach (var item in LinksDB.GetChannels())
                regions.Add(new Region(item.RegionID, item.RegionName,
                    item.LinkToChannel));

            return regions; 
            
        }

    }
   
}
