using MassTransit;
using OnlineShop.Integration.Configuration;
using OrderReflectionService.Consumers;
using OrderReflectionService.ElasticServices;
using System.Reflection;

namespace OrderReflectionService.Configuration
{
    public static class ServiceConfigurations
    {
        public static void AddOrderIntegrationConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IOrderReflectService,OrderReflectService>();

            services.AddIntegrationConfigurations(configuration, "MassTransit",
                   (IRegistrationConfigurator configurator) =>
                   {
                       configurator.AddConsumers(Assembly.GetExecutingAssembly());
                   },
                (IBusControl busControl, IServiceProvider provider) =>
                {
                    busControl.ConnectReceiveEndpoint(OrderMessageQueueConst.OrderSyncEventQueueName,
                                                      endpointConfigurator => { endpointConfigurator.Consumer<OrderSyncConsumer>(provider); });
                });
        }
    }
}
