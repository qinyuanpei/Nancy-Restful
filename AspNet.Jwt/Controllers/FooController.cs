using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AspNet.Jwt.Attributes;
using AspNet.Jwt.Models;

namespace AspNet.Jwt.Controllers
{
    [JwtAuthorize]
    public class FooController : ApiController
    {
        [HttpGet]
        public Bar Get()
        {
            var user = ControllerContext.RequestContext.Principal;
            return new Bar() { Owner = "PayneQin" };
        }
    }
}
