
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using OnlineShop.Customer.Application.Configuration;
using OnlineShop.Customer.Persistence.Configuration;
using OnlineShop.Persistence.Repository.Settings;
using OnlineShop.WebApi.Configuration;
using OnlineShop.WebApi.Logging;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

var logger = LoggingConfigurator.ConfigureLogging();
var loggerFactory = new LoggerFactory().AddSerilog(logger);

builder.Host.UseSerilog(logger);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowedOriginPolicy",
                      builder =>
                      {
                          builder.AllowAnyHeader()
                                 .AllowAnyMethod()
                                 .AllowAnyOrigin();
                      });
});


builder.Services.AddApplicationConfigurations();

builder.Services.AddPersistenceConfigurations(builder.Configuration);


var databaseSettingOption = builder.Configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();

builder.Services.AddHealthChecks()

    .AddNpgSql(
    npgsqlConnectionString: databaseSettingOption.ConnectionString,
    name: "Order Db Check",
    failureStatus: HealthStatus.Unhealthy | HealthStatus.Degraded,
    tags: new string[] { "orderdb-postgresql" });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

#region Middlewares

app.UseGeneralExceptionMiddleware();
app.UseTraceIdMiddleware();

#endregion

app.UseCors("AllowedOriginPolicy");

#region Db Migrator

await app.RunMigratorAsync();

#endregion


app.MapControllers();


app.UseHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();
