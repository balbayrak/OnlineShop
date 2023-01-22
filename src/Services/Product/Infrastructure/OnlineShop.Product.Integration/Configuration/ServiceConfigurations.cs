using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Integration.Configuration;
using OnlineShop.Integration.Correlation;
using OnlineShop.Product.Integration.Consumers;
using System.Reflection;

namespace OnlineShop.Product.Integration.Configuration
{
    public static class ServiceConfigurations
    {
        public static void AddProductIntegrationConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIntegrationConfigurations(configuration, "MassTransit",
                   (IRegistrationConfigurator configurator) =>
                   {
                       configurator.AddConsumers(Assembly.GetExecutingAssembly());
                   },
                (IBusControl busControl, IServiceProvider provider) =>
                {
                    busControl.ConnectReceiveEndpoint(ProductMessageQueueConst.ProductSyncEventQueueName,
                                                      endpointConfigurator => { endpointConfigurator.Consumer<ProductSyncConsumer>(provider); });
                });
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(IntegrationCorrelationIdBehaviour<,>));
        }
    }
}
