using OrderReflectionService;
using OrderReflectionService.Configuration;


IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext,services) =>
    {
        IConfiguration configuration = hostContext.Configuration;
        services.AddOrderIntegrationConfigurations(configuration);
        services.AddHostedService<Worker>();
    })
    .Build();


await host.RunAsync();