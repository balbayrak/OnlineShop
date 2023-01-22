using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OnlineShop.Application.Common;
using OnlineShop.Customer.Application.Repositories;
using OnlineShop.Customer.Persistence.Repositories;
using OnlineShop.Customer.Persistence.Repositories.EfCore.Context;
using OnlineShop.Customer.Persistence.Repositories.EfCore.Migrator;
using OnlineShop.Persistence.Repository.EfCore.Configuration;
using OnlineShop.Persistence.Repository.EfCore.Migrator;
using OnlineShop.Persistence.Repository.Settings;

namespace OnlineShop.Customer.Persistence.Configuration
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

            services.AddPersistenceEfCoreBaseConfigurations<CustomerDbContext>(option =>
            {
                option.ConnectionString = databaseSetting.ConnectionString;
                option.DatabaseType = DatabaseType.PostgreSQL;
            });

            services.AddScoped<ICustomerRepository, CustomerEfCoreRepository>();
            services.AddScoped<ICustomerReadOnlyRepository, CustomerEfCoreRepository>();
            services.AddScoped<ICustomerCommandRepository, CustomerEfCoreRepository>();

            services.AddTransient<IEfCoreMigrator, CustomerDbMigrator>();

            #endregion
        }
    }
}
