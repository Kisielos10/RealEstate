using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace RealEstate.API.Middleware
{
    public class BearerTokenMiddleware
    {
        private readonly RequestDelegate _next;

        public BearerTokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Headers.TryGetValue("secret_token",out var value))
            {
                if (value == "123")
                {
                    await _next.Invoke(httpContext);
                }
            }
            httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
    }
}
