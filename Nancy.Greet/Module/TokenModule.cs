using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.Jwt;

namespace Nancy.Greet.Module
{
    public class TokenModule : NancyModule
    {
        public TokenModule() : base(@"/api")
        {
            Get(@"/token/{user}", parameters =>
            {
                string user = parameters.user;
                var token = JwtManager.GenerateToken(user);
                return Response.AsJson(token);
            });
        }
    }
}
