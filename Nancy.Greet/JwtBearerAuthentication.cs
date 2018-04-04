using Nancy.Bootstrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.Jwt;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Nancy.Security;

namespace Nancy.Greet
{
    public static class JwtBearerAuthentication
    {
        public static void EnableJwtBearerAuthentication(this IPipelines pipeline, JwtBearerAuthenticationConfiguration configuration)
        {
            pipeline.BeforeRequest.AddItemToStartOfPipeline(HandleRequestBefore(configuration));
            pipeline.AfterRequest.AddItemToEndOfPipeline(HandleRequestAfter(configuration));
        }

        private static Func<NancyContext, Response> HandleRequestBefore(JwtBearerAuthenticationConfiguration configuration)
        {
            return context =>
            {

            };

        }

        private static Func<NancyContext, Response> HandleRequestAfter(JwtBearerAuthenticationConfiguration configuration)
        {

        }

        private static void ValidateToken(NancyContext context)
        {
            var jwtToken = context.Request.Headers["Authorization"].FirstOrDefault() ?? string.Empty;

            if (!jwtToken.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase)) return;
            jwtToken = jwtToken.Substring("Bearer ".Length);

            if (string.IsNullOrWhiteSpace(jwtToken)) return;
            context.CurrentUser = JwtManager.ValidateToken(jwtToken);
        }
    }
}
