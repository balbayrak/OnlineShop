using OnlineShop.Persistence.Repository.EfCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.Repository.EfCore.Configuration
{
    public static class ServiceConfigurations
    {
        public static void AddPersistenceEfCoreBaseConfigurations<TDbContext>(this IServiceCollection services, Action<DatabaseOption> option)
            where TDbContext : DbContext
        {
            DataAccessLayerOptionBuilder builder = new DataAccessLayerOptionBuilder(services);
            builder.ConfigureDataAccessLayer<TDbContext>(option);

        }
    }
}
