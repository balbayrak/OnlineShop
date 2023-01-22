using OnlineShop.Persistence.Repository.Mongo.Mapping;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace OnlineShop.Product.Persistence.Repositories.Mongo.Mapping
{
    public class ProductMap
    {
        public static void Configure()
        {
            BaseMongoEntityMap<OnlineShop.Product.Domain.Models.Product>.ConfigureEntity();

            BsonClassMap.RegisterClassMap<OnlineShop.Product.Domain.Models.Product>(map =>
            {
                map.MapMember(x => x.Name).SetIsRequired(true);
                map.MapMember(x => x.Price).SetIsRequired(true)
                .SetSerializer(new CharSerializer(BsonType.Decimal128)); ;


            });
        }
    }
}
