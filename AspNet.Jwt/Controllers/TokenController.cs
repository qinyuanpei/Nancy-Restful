using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Nancy.Jwt;

namespace AspNet.Jwt.Controllers
{
    [AllowAnonymous]
    public class TokenController : ApiController
    {
        [Route("api/oauth/token")]
        public string  Get()
        {
            return JwtManager.GenerateToken("PayneQin");
        }
    }
}
