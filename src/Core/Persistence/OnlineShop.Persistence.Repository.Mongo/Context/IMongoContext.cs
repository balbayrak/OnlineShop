using MongoDB.Driver;

namespace OnlineShop.Persistence.Repository.Mongo.Context
{
    public interface IMongoContext : IDisposable
    {
        Task AddCommand(Func<Task> func);
        Task<int> SaveChanges();
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
