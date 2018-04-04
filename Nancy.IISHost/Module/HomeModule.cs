using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nancy.IISHost.Module
{
    public class HomeModule : NancyModule
    {
        public HomeModule() : base("/")
        {
            Get["/"] = parameter =>
            {
                var data = new
                {
                    Title = "首页",
                    Items = new List<string>() { "选项A", "选项B", "选项C", "选项D" },
                    Description = "这是一个使用Nancy开发的网页",
                };

                return View["Views/Home/Index", data];
            };
        }
    }
}