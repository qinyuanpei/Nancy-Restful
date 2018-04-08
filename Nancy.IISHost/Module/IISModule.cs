using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace Nancy.IISHost.Module
{
    public class IISModule : NancyModule
    {
        public IISModule() : base("/api")
        {
            Get("/iis",_ =>
            {
                var data = new
                {
                    URL = "/api/IIS",
                    Host = "IIS",
                    Message = "欢迎使用NancyFX",
                    Provider = "NancyFX",
                    Description = "这是一个使用NancyFX开发的,运行在IIS上的Web API"
                };
                return Response.AsJson(data);
            });
        }
    }
}