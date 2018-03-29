using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nancy.Caching.SQLite
{
    public class CachingModel
    {
        public string ID { get; set; }
        public string ItemKey { get; set; }
        public string ItemValue { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
