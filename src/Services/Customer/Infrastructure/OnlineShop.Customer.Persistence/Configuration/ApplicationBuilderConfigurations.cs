using Microsoft.AspNetCore.Builder;
using OnlineShop.Customer.Persistence.Repositories.EfCore.Context;
using OnlineShop.Customer.Persistence.Repositories.EfCore.Migrator;
using OnlineShop.Persistence.Repository.EfCore.Configuration;

namespace OnlineShop.Customer.Persistence.Configuration
{
    public static class ApplicationBuilderConfigurations
    {
        public static async Task RunMigratorAsync(this IApplicationBuilder applicationBuilder)
        {
            await applicationBuilder.MigrateDbContextAsync<CustomerDbMigrator, CustomerDbContext>();
        }
    }
}
