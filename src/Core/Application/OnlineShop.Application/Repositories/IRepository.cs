using OnlineShop.Application.Dto;
using OnlineShop.Application.Wrappers;
using OnlineShop.Domain;
using System.Linq.Expressions;

namespace OnlineShop.Application.Repositories
{
    public interface IRepository<TEntity, TSearchDto> : ICommandRepository<TEntity>, IReadOnlyRepository<TEntity, TSearchDto>
       where TEntity : class, IEntity
       where TSearchDto : PagedSearchDto
    {
    }
}
