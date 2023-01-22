using OnlineShop.Domain;

namespace OnlineShop.Persistence.Repository
{
    public abstract class BaseRepository<TEntity> where TEntity : class, IEntity
    {
    }
}