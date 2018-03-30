using System;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Owin;
using Nancy.Owin;
using Microsoft.Owin;


[assembly: OwinStartup(typeof(Nancy.OwinHost.Startup))]

namespace Nancy.OwinHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy();
        }
    }
}
