using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nancy.Caching.EF
{
    public class CachingModel
    {
        public string ItemKey { get; set; }
        public string ItemValue { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
