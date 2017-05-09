using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace ConfiguringApps.Infrastructure
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ContentMiddleware
    {
        private readonly RequestDelegate _next;

        private UptimeService uptime;

        public ContentMiddleware(RequestDelegate next, UptimeService up)
        {
            _next = next;
            uptime = up;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToString() == "/middleware")
            {
                await httpContext.Response.WriteAsync("This is from the content middleware" + $"(uptime: {uptime.Uptime}ms)", Encoding.UTF8);
            }
            else
            {
                await _next.Invoke(httpContext);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ContentMiddlewareExtensions
    {
        public static IApplicationBuilder UseContentMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ContentMiddleware>();
        }
    }
}
