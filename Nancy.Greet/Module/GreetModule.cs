using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.Greet;
using System.Collections.Concurrent;
using Nancy.Greet.Models;
using System.Threading;
using Nancy.Security;

namespace Nancy.Greet.Module
{
    /// <summary>
    /// Greet模块
    /// </summary>
    public class GreetModule : NancyModule
    {
        private ConcurrentBag<UserEntry> _users = new ConcurrentBag<UserEntry>();

        /// <summary>
        /// 构造函数
        /// </summary>
        public GreetModule() : base("/api")
        {
            //this.RequiresAuthentication();

            // GET: /api/Greet/
            Get(@"/Greet",_ =>
            {
                var data = new
                {
                    URL = "/api/Greet",
                    Host = "Console",
                    Message = "欢迎使用NancyFX",
                    Provider = "NancyFX",
                    Description = "这是一个使用NancyFX开发的Web API"
                };
                return Response.AsJson(data);
            });

            // GET: /api/Greet/{user}
            Get(@"/Greet/{user}", parameter =>
            {
                string message = string.Format("欢迎来到Nancy的世界，{0}!", parameter.user);
                return Response.AsJson(new { Message = message });
            });

            // POST: /api/Greet/User/Create
            Post(@"/Greet/User/Create", _ =>
            {
                dynamic form = Request.Form;
                string uName = form.name;
                string uEmail = form.email;
                _users.Add(new UserEntry() { Name = uName, Email = uEmail });

                var data = new
                {
                    Name = uName,
                    Email = uEmail,
                    CreateTime = DateTime.Now,
                    Message = "成功创建新用户!"
                };
                return Response.AsJson(data);
            });

            // GET: /api/Greet/User/{user}
            Get(@"/Greet/User/{user}", parameter =>
            {
                string uName = parameter.name;
                var user = _users.FirstOrDefault(e => e.Name == uName);
                if (user == null) return Response.AsJson(new { Message = "当前用户不存在!" });
                return Response.AsJson(user);
            });
        }
    }
}
