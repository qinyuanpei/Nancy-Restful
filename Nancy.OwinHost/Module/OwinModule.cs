using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nancy.OwinHost.Module
{
    public class OwinModule : NancyModule
    {
        public OwinModule() : base(@"/api")
        {
            // GET: /api/Greet/
            Get[@"/Owin"] = _ =>
            {
                var data = new
                {
                    URL = "/api/Owin",
                    Host = "Owin",
                    Message = "欢迎使用NancyFX",
                    Provider = "NancyFX",
                    Description = "这是一个使用NancyFX开发,运行在Owin上的Web API"
                };
                return Response.AsJson(data);
            };
        }
    }
}
