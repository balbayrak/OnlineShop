using OnlineShop.External.Order.Application.Configuration;
using OnlineShop.External.Order.Persistence.Configuration;
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


app.MapControllers();


//app.UseHealthChecks("/health", new HealthCheckOptions
//{
//    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
//});

app.Run();
