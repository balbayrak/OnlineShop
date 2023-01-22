using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OnlineShop.Application.Common;
using OnlineShop.Order.Application.Repositories;
using OnlineShop.Order.Integration.Configuration;
using OnlineShop.Order.Persistence.Repositories;
using OnlineShop.Order.Persistence.Repositories.EfCore.Context;
using OnlineShop.Order.Persistence.Repositories.EfCore.Migrator;
using OnlineShop.Persistence.Repository.EfCore.Configuration;
using OnlineShop.Persistence.Repository.EfCore.Migrator;
using OnlineShop.Persistence.Repository.Settings;

namespace OnlineShop.Order.Persistence.Configuration
{
    public static class ServiceConfigurations
    {
        public static void AddPersistenceConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            #region Database 

            var databaseSetting = new DatabaseSettings();
            configuration.GetSection("DatabaseSettings").Bind(databaseSetting);

            services.Configure<DatabaseSettings>(configuration.GetSection("DatabaseSettings"));

            services.AddSingleton<IDataBaseSettings>(sp =>
            {
                return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
            });

            services.AddPersistenceEfCoreBaseConfigurations<OrderDbContext>(option =>
            {
                option.ConnectionString = databaseSetting.ConnectionString;
                option.DatabaseType = DatabaseType.PostgreSQL;
            });

            services.AddScoped<IOrderRepository, OrderEfCoreRepository>();

            services.AddTransient<IEfCoreMigrator, OrderDbMigrator>();

            #endregion


            #region IntegrationEventPublisher

            services.AddOrderIntegrationConfigurations(configuration);

            #endregion

        }
    }
}
