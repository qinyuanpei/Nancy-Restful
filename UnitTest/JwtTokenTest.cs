using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy.Jwt;

namespace UnitTest
{
    [TestClass]
    public class JwtTokenTest
    {
        [TestMethod]
        public void Test_GenerateToken()
        {
            var user = "PayneQin";
            var token = JwtManager.GenerateToken(user);
        }
    }
}
