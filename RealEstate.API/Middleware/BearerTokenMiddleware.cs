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
            httpContext.Request.Headers.TryGetValue("secret_token",out var value);
            //TODO sprawdz czy jest token jezeli jest i ma dobra wartosc to nic a jeżeli nie ma to zwracam unathorized i przerwać *Shortcircuting*
            if (!(value=="secret_token" && string.IsNullOrWhiteSpace(value)))
            {
                return;
            }
            await _next.Invoke(httpContext);
        }
    }
}
