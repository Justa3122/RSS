using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSS
{
    public class DataBase: DbContext
    {

        public DbSet<Category> Categories { get; set; }

        void AddNews()//zapisywanie komunikatow tych, ktorych jeszcze nie ma (sprawdzanie po ID)
        {
        }
        void DeleteNews()//zostawiamy 10 najnowszych komunikatow, reszte usuwamy
        {
        }
    }
}
