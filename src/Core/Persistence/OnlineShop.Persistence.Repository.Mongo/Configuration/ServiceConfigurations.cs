using OnlineShop.Application.Repositories;
using OnlineShop.Persistence.Repository.Mongo.Context;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineShop.Persistence.Repository.Mongo.Configuration
{
    public static class ServiceConfigurations
    {
        public static void AddPersistenceMongoBaseConfigurations(this IServiceCollection services)
        {
            services.AddScoped<IMongoContext, MongoContext>();
            services.AddScoped<IUnitOfWork, MongoUnitOfWork>();
        }
    }
}
