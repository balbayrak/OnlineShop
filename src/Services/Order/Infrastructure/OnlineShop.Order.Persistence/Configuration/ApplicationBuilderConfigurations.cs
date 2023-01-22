using OnlineShop.Order.Persistence.Repositories.EfCore.Context;
using OnlineShop.Order.Persistence.Repositories.EfCore.Migrator;
using OnlineShop.Persistence.Repository.EfCore.Configuration;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Order.Persistence.Configuration
{
    public static class ApplicationBuilderConfigurations
    {
        public static async Task RunMigratorAsync(this IApplicationBuilder applicationBuilder)
        {
            await applicationBuilder.MigrateDbContextAsync<OrderDbMigrator, OrderDbContext>();
        }
    }
}
