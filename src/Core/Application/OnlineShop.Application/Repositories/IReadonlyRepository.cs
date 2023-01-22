using OnlineShop.Application.Dto;
using OnlineShop.Application.Wrappers;
using OnlineShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Repositories
{
    public interface IReadOnlyRepository<TEntity, TSearchDto>
       where TEntity : class, IEntity
       where TSearchDto : PagedSearchDto
    {
        Task<PagedResponse<IReadOnlyList<TEntity>>> GetAllAsync(TSearchDto searchEntity, CancellationToken cancellationToken = default);
        Task<TEntity?> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> FilterBy(Expression<Func<TEntity, bool>> filterExpression, CancellationToken cancellationToken = default);
        Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> filterExpression, CancellationToken cancellationToken = default);
    }
}
