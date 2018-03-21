using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nancy.Caching.EF
{
    class CachingModel
    {
        public string itemKey { get; set; }
        public string ItemValue { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
