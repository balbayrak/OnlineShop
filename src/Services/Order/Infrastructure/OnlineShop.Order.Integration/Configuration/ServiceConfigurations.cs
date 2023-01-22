using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Integration.Configuration;
using OnlineShop.Integration.Correlation;
using System.Reflection;

namespace OnlineShop.Order.Integration.Configuration
{
    public static class ServiceConfigurations
    {
        public static void AddOrderIntegrationConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIntegrationConfigurations(configuration, "MassTransit",
                (IRegistrationConfigurator configurator) =>
                {
                    configurator.AddConsumers(Assembly.GetExecutingAssembly());
                },
                  (IBusControl busControl, IServiceProvider provider) =>
                  {

                  });
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(IntegrationCorrelationIdBehaviour<,>));
        }
    }
}
