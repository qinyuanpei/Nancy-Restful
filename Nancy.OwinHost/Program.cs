using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;
using Microsoft.Owin.Hosting;

namespace Nancy.OwinHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseURL = "http://localhost:2345";

            var options = new StartOptions();
            options.Urls.Add(baseURL);

            using (WebApp.Start<Startup>(options))
            {
                Console.WriteLine(string.Format("Server is runing at {0}...", baseURL));
                Console.ReadKey();
            }
            
            
        }
    }
}
