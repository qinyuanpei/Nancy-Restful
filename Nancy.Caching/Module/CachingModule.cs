using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.Caching.SQLite;

namespace Nancy.Caching.Module
{
    public class CachingModule : NancyModule
    {
        private CachingRepository repository;

        public CachingModule() : base("/api")
        {
            repository = new CachingRepository("caching.db");
            Get["/Caching/{key}"] = parameter =>
            {
                string key = parameter.key;
                var value = repository.GetKey<string>(key);
                return Response.AsJson(value);
            };

            Post["/Caching/{key}"] = parameter =>
            {
                string key = parameter.key;
                string value = Request.Form.value;
                repository.SetKey<string>(key, value);
                return Response.AsJson(new { Message = "更新成功" });
            };
        }
    }
}
