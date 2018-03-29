using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Nancy.Owin;
using Owin;

[assembly: OwinStartup(typeof(Nancy.Greet.Startup))]

namespace Nancy.Greet
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configuration
        /// </summary>
        /// <param name="app">IAppBuilder</param>
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy();
        }
    }
}
