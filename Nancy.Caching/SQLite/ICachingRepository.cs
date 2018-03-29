using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nancy.Caching.SQLite
{
    interface ICachingRepository
    {
        void SetKey<T>(string key, T value) where T : class;
        T GetKey<T>(string key) where T : class;
    }
}
