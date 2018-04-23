using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Infrastructure;


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
                AuthenticationMode = AuthenticationMode.Active,
                TokenEndpointPath = new PathString("/auth"),
                AuthorizeEndpointPath = new PathString("/authorize"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = new OAuthAuthorizationServerProvider()
                {
                    OnValidateClientRedirectUri = ValidateClientRedirectUri,
                    OnValidateClientAuthentication = ValidateClientAuthentication,
                    OnGrantResourceOwnerCredentials = GrantResourceOwnerCredentials,
                    OnGrantClientCredentials = GrantClientCredetails
                },

                AuthorizationCodeProvider = new AuthenticationTokenProvider
                {
                    OnCreate = CreateAuthenticationCode,
                    OnReceive = ReceiveAuthenticationCode,
                },

                // Refresh token provider 创建和接收访问凭据访问凭据
                RefreshTokenProvider = new AuthenticationTokenProvider
                {
                    OnCreate = CreateRefreshToken,
                    OnReceive = ReceiveRefreshToken,
                }
            };
        }

        private void ReceiveRefreshToken(AuthenticationTokenReceiveContext obj)
        {
            throw new NotImplementedException();
        }

        private void CreateRefreshToken(AuthenticationTokenCreateContext obj)
        {
            throw new NotImplementedException();
        }

        private void ReceiveAuthenticationCode(AuthenticationTokenReceiveContext obj)
        {
            throw new NotImplementedException();
        }

        private void CreateAuthenticationCode(AuthenticationTokenCreateContext obj)
        {
            throw new NotImplementedException();
        }

        private Task GrantClientCredetails(OAuthGrantClientCredentialsContext arg)
        {
            throw new NotImplementedException();
        }

        private Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext arg)
        {
            throw new NotImplementedException();
        }

        private Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId;
            string clientSecret;
            if (context.TryGetBasicCredentials(out clientId, out clientSecret) ||
                context.TryGetFormCredentials(out clientId, out clientSecret))
            {
                if(clientId == "1234567890" && clientSecret == "1234567890"){
                    context.Validated();
                }
            }

            return Task.FromResult(0);
        }

        private Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext arg)
        {
            return Task.FromResult(0);
        }
    }
}
