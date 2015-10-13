using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RSS
{
    public class Category
    {
        public int CategoryID { get; private set; }
        public string Name { get; private set; }
        public List<News> News { get; private set; }

        public Category()
        {
            News = new List<News>();
        }

        public Category(int categoryId, string name)
        {
            News = new List<News>();
            this.CategoryID = categoryId;
            this.Name = name;
        }


        public void AddNews(News news)
        {
            News.Add(news);
        }
    
    }
}
