using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.External.Order.Application.DataService;
using OnlineShop.External.Order.Persistence.DataService.ElasticSearch;

namespace OnlineShop.External.Order.Persistence.Configuration
{
    public static class ServiceConfigurations
    {
        public static void AddPersistenceConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IOrderReflectService, OrderReflectService>();
            services.AddTransient<IOrderDataService, OrderDataService>();
        }
    }
}
