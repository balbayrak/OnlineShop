using OnlineShop.Application.Repositories;
using OnlineShop.Persistence.Repository.Mongo.Context;

namespace OnlineShop.Persistence.Repository.Mongo
{
    public class MongoUnitOfWork : IUnitOfWork
    {
        private readonly IMongoContext _context;

        public MongoUnitOfWork(IMongoContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            var changeAmount = await _context.SaveChanges();

            return changeAmount > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
