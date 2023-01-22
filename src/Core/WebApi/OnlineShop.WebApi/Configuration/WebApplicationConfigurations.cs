﻿using OnlineShop.WebApi.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Primitives;

namespace OnlineShop.WebApi.Configuration
{
    public static class WebApplicationConfigurations
    {
        public static void UseGeneralExceptionMiddleware(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<GeneralExceptionMiddleware>();
        }

        public static void UseTraceIdMiddleware(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Use((async (httpContext, next) =>
            {
                if (httpContext.Request.Headers.TryGetValue("x-trace-id", out StringValues stringValues))
                {
                    httpContext.TraceIdentifier = stringValues;
                }

                httpContext.TraceIdentifier ??= Guid.NewGuid().ToString();
                await next();
            }));
        }
    }
}
