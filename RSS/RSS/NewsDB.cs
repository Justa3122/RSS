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
        public NewsDB(bool error) : base("Baza5")
        {
            if (error)
            {
                Database.SetInitializer<NewsDB>(new DropCreateDatabaseAlways<NewsDB>());
            }
        }
        public DbSet<News> niusiki { get; set; }
    }
}
