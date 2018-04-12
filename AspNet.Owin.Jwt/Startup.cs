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
            //配置OAuth2 Server选项
            var serverOpts = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                Provider = new OAuthAuthorizationServerProvider(),
                AuthenticationMode = AuthenticationMode.Active,
                TokenEndpointPath = new PathString("/oauth/token"),
                AuthorizeEndpointPath = new PathString("/oauth/authorize"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
            };

            //启用OAuth2 Server
            app.UseOAuthAuthorizationServer(serverOpts);

            ////配置
            //var bearerOpts = new OAuthBearerAuthenticationOptions()
            //{

            //};
            //app.UseOAuthBearerAuthentication(bearerOpts);
        }
    }
}
