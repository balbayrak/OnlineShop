using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application.Configuration;
using System.Reflection;

namespace OnlineShop.External.Order.Application.Configuration
{
    public static class ServiceConfigurations
    {
        public static void AddApplicationConfigurations(this IServiceCollection services)
        {
            services.AddApplicationBaseConfigurations(Assembly.GetExecutingAssembly());
        }
    }
}
