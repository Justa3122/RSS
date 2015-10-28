using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSS
{
    public class Region
    {
        public int RegionID { get; private set; }
        public string RegionName { get; private set; }
        public string LinkToChannel { get; private set; }
        public IList<News> News { get; private set; }
        RSSReader rs;

        public Region()
        {

        }
        public Region(int regionID, string regionName, string linkToChannel)
        {
            this.RegionID = regionID;
            this.RegionName = regionName;
            this.LinkToChannel = linkToChannel;
            rs = new RSSReader(linkToChannel);
            News = rs.ReadNews();
        }


    }
}
