using Nest;
using OnlineShop.Application.Wrappers;

namespace OnlineShop.ElasticSearchService
{
    public interface IElasticService<T>
        where T : class, new()
    {
        IElasticClient ElasticClient { get; }
        Task<ServiceResponse<bool>> Insert(T data);
    }
}
