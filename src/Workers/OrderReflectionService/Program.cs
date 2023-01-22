using Microsoft.Extensions.Logging;
using OrderReflectionService;
using OrderReflectionService.Configuration;
using OrderReflectionService.Logging;
using Serilog;


IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext,services) =>
    {
        IConfiguration configuration = hostContext.Configuration;
        services.AddOrderIntegrationConfigurations(configuration);
        services.AddHostedService<Worker>();
    })
    .ConfigureLogging((hostContext, builder) =>
    {
        builder.ConfigureLogger(hostContext.Configuration);
    })
    .UseSerilog()
   // .ConfigureLogging(loggingBuilder => loggingBuilder.AddSerilog(logger, dispose: true))
    //.UseSerilog(logger)
    .Build();


await host.RunAsync();