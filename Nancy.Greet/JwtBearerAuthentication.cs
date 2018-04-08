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
    /// <summary>
    /// JWT认证扩展
    /// </summary>
    public static class JwtBearerAuthentication
    {
        /// <summary>
        /// 启用JWT认证
        /// </summary>
        /// <param name="pipeline">Nancy管道</param>
        public static void EnableJwtBearerAuthentication(this IPipelines pipeline)
        {
            pipeline.BeforeRequest.AddItemToStartOfPipeline(HandleRequestBefore());
            pipeline.AfterRequest.AddItemToEndOfPipeline(HandleRequestAfter());
        }

        /// <summary>
        /// 启用JWT认证
        /// </summary>
        /// <param name="module">Nancy模块</param>
        public static void EnableJwtBearerAuthentication(this INancyModule module)
        {
            module.Before.AddItemToStartOfPipeline(HandleRequestBefore());
            module.After.AddItemToEndOfPipeline(HandleRequestAfter());
        }

        /// <summary>
        /// 请求前流程
        /// </summary>
        /// <returns></returns>
        private static Func<NancyContext, Response> HandleRequestBefore()
        {
            return context =>{
                ValidateToken(context);
                return null;
            };

        }

        /// <summary>
        /// 请求后流程
        /// </summary>
        /// <returns></returns>
        private static Action<NancyContext>HandleRequestAfter()
        {
            return context =>
            {
                if (context.Response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    context.Response.WithHeader("WWW-Authenticate", "Bearer");
                }
            };
        }

        /// <summary>
        /// 验证Toeken
        /// </summary>
        /// <param name="context">Nancy上下文</param>
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
