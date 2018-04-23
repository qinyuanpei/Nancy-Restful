using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAuth2_Demo
{
    public partial class Startup
    {
        public void ConfigurationOAuth(IAppBuilder app)
        {
            //配置OAuth2 Server选项
            var serverOpts = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                Provider = new OAuthAuthorizationServerProvider(),
                AuthenticationMode = AuthenticationMode.Active,
                TokenEndpointPath = new PathString("/auth"),
                AuthorizeEndpointPath = new PathString("/authorize"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
            };

            //启用OAuth2 Server
            app.UseOAuthAuthorizationServer(serverOpts);
            //app.UseOAuthBearerTokens(serverOpts);

            //////配置
            //var bearerOpts = new OAuthBearerAuthenticationOptions()
            //{

            //};
            //app.UseOAuthBearerAuthentication(bearerOpts);
        }
    }
}