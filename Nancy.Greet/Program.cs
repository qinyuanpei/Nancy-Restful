using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.Hosting.Self;

namespace Nancy.Greet
{
    class Program
    {
        static void Main(string[] args)
        {
            //定义Host配置
            var config = new HostConfiguration()
            {
                RewriteLocalhost = true,
                UrlReservations = new UrlReservations() { CreateAutomatically = true },
                EnableClientCertificates = false
            };

            //定义服务器地址及端口号
            var baseURL = "http://localhost:4050";

            //定义并启动Host
            using (var host = new NancyHost(config, new Uri(baseURL)))
            {
                host.Start();
                Console.WriteLine(string.Format("Server is runing at {0}...", baseURL));
                Console.ReadKey();
            }
        }
    }
}
