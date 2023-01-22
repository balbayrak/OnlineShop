using OnlineShop.Application.Common;
using OnlineShop.Persistence.Repository.Mongo.Configuration;
using OnlineShop.Persistence.Repository.Settings;
using OnlineShop.Product.Application.Repositories;

using OnlineShop.Product.Persistence.Repositories.Mongo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OnlineShop.Product.Integration.Configuration;

namespace OnlineShop.Product.Persistence.Configuration
{
    public static class ServiceConfigurations
    {
        public static void AddPersistenceConfigurations(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddPersistenceMongoBaseConfigurations();

            #region Database

            ProductMongoDbMapping.ConfigureMapping();

            services.AddScoped<IProductRepository, ProductMongoRepository>();
            services.AddScoped<IProductReadOnlyRepository, ProductMongoRepository>();
            services.AddScoped<IProductCommandRepository, ProductMongoRepository>();

            services.Configure<DatabaseSettings>(configuration.GetSection("DatabaseSettings"));

            services.AddSingleton<IDataBaseSettings>(sp =>
            {
                return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
            });

            #endregion

            #region IntegrationEventPublisher

            services.AddProductIntegrationConfigurations(configuration);

            #endregion
        }
    }
}
