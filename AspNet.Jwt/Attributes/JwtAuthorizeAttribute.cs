using Nancy.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace AspNet.Jwt.Attributes
{
    public class JwtAuthorizeAttribute: AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var authHeader = actionContext.Request.Headers.Where(e => e.Key == "Authorization").Select(e=>e.Value.FirstOrDefault());
            var jwtToken = string.Empty;
            if (authHeader != null) jwtToken = authHeader.FirstOrDefault();

            if (string.IsNullOrEmpty(jwtToken)) return false;
            if (!jwtToken.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase)) return false;
            jwtToken = jwtToken.Substring("Bearer ".Length);

            if (string.IsNullOrWhiteSpace(jwtToken)) return false;
            actionContext.RequestContext.Principal = JwtManager.ValidateToken(jwtToken);

            return true;
        }
    }
}