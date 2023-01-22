using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using OnlineShop.DistributedLock.Configuration;
using OnlineShop.Persistence.Repository.Settings;
using OnlineShop.Product.Application.Configuration;
using OnlineShop.Product.Persistence.Configuration;
using OnlineShop.WebApi.Configuration;
using OnlineShop.WebApi.Logging;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var logger = LoggingConfigurator.ConfigureLogging();
var loggerFactory = new LoggerFactory().AddSerilog(logger);

builder.Host.UseSerilog(logger);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistenceConfigurations(builder.Configuration);
builder.Services.AddApplicationConfigurations();
builder.Services.AddDistributionLockConfigurations(builder.Configuration, loggerFactory);


var databaseSettingOption = builder.Configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();


builder.Services.AddHealthChecks()

    .AddMongoDb(
    mongodbConnectionString: databaseSettingOption.ConnectionString,
    name: "MongoDb Check",
    failureStatus: HealthStatus.Unhealthy | HealthStatus.Degraded,
    tags: new string[] { "mongodb" });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.UseGeneralExceptionMiddleware();

app.MapControllers();

app.Lifetime.DisposeLockFactory();

app.UseHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();



