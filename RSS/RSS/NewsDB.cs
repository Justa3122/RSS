using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSS
{
    public class NewsDB: DbContext
    {
        public NewsDB(bool error) : base("NewsDB")
        {
            if (error)
            {
                Database.SetInitializer<NewsDB>(new DropCreateDatabaseAlways<NewsDB>());
            }
        }
        public DbSet<Region> Region { get; set; }
        public DbSet<News> News { get; set; }

    }
}
