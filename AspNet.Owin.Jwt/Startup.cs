using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security.Cookies;


[assembly: OwinStartup(typeof(AspNet.Owin.Jwt.Startup))]

namespace AspNet.Owin.Jwt
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var opts = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                Provider = new OAuthAuthorizationServerProvider(),
                AuthenticationMode = AuthenticationMode.Active,
                TokenEndpointPath = new PathString("/oauth/token"),
                AuthorizeEndpointPath = new PathString("/oauth/authorize"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),

            };

            app.UseOAuthAuthorizationServer(opts);
        }
    }
}
