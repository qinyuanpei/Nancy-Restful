using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using Microsoft.Owin.Hosting;

namespace AspNet.Owin.Jwt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var baseURL = "http://localhost:1234";
            var opts = new StartOptions(baseURL);
            
            using (WebApp.Start<Startup>(opts))
            {
                Console.WriteLine(string.Format("Server is runing at {0}...", baseURL));
                Console.ReadLine();
            }
        }
    }
}