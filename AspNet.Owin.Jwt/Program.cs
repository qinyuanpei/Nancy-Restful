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
        static void Main(string[] args)
        {
            var baseURL = "http://localhost:1234";
            using (WebApp.Start<Startup>(baseURL))
            {
                Console.WriteLine(string.Format("Server is runing at {0}...", baseURL));
            }
        }
    }
}