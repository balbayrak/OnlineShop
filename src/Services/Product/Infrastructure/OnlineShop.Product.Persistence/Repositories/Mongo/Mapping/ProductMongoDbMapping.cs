using OnlineShop.Product.Persistence.Repositories.Mongo.Mapping;
using MongoDB.Bson.Serialization;
using OnlineShop.Persistence.Repository.Mongo.Mapping;

namespace OnlineShop.Product.Persistence.Repositories.Mongo
{
    public class ProductMongoDbMapping 
    {
        public static void ConfigureMapping()
        {
            MongoDbMapping.Configure();

            BsonClassMap.RegisterClassMap<ProductMap>();
        }
    }
}
