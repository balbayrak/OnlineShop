using MediatR;
using OnlineShop.Application.Configuration;
using OnlineShop.Application.Features.Behaviours;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace OnlineShop.Order.Application.Configuration
{
    public static class ServiceConfigurations
    {
        public static void AddApplicationConfigurations(this IServiceCollection services)
        {
            services.AddApplicationBaseConfigurations(Assembly.GetExecutingAssembly());
        }
    }
}
