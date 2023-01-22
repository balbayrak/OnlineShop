using Serilog;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;

namespace OrderReflectionService.Logging
{
    public static class LoggingConfigurator
    {
        private const string ELASTIC_CONFIGURATION_NAME = "ElasticConfiguration";

        public static ILoggingBuilder ConfigureLogger(this ILoggingBuilder loggingBuilder, IConfiguration configuration)
        {
            GetLoggerConfiguration(configuration)
                .CreateLogger();

            return loggingBuilder;
        }

        private static LoggerConfiguration GetLoggerConfiguration(IConfiguration configuration)
        {
            return new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .WriteTo.Elasticsearch(ConfigureElasticSearch(configuration))
                .ReadFrom.Configuration(configuration);

        }

        private static ElasticsearchSinkOptions ConfigureElasticSearch(IConfiguration configuration)
        {
            var elasticConf = configuration.GetSection(ELASTIC_CONFIGURATION_NAME);
            if (elasticConf is null)
            {
                throw new Exception($"{ELASTIC_CONFIGURATION_NAME} section not found in appsettings");
            }
            return new ElasticsearchSinkOptions(new Uri(elasticConf["Uri"]))
            {
                AutoRegisterTemplate = true,
                IndexFormat = elasticConf["IndexName"]

                //ModifyConnectionSettings = p =>
                //{
                //    p.BasicAuthentication(elasticConf["Username"], elasticConf["Password"]);
                //    p.ServerCertificateValidationCallback(CertificateValidations.AllowAll);
                //    return p;
                //}
            };
        }
    }
}
