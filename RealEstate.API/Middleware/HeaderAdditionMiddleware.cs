using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace RealEstate.API.Middleware
{
    public class HeaderAdditionMiddleware
    {
        private readonly RequestDelegate _next;

        public HeaderAdditionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.Headers.Add("super_secret",new StringValues("abc"));
            await _next.Invoke(httpContext);
        }
    }
}
