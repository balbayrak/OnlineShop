using OnlineShop.Application.Wrappers;
using OnlineShop.ElasticSearchService;
using OnlineShop.External.Order.Application.Dto;

namespace OnlineShop.External.Order.Persistence.DataService.ElasticSearch
{
    public interface IOrderReflectService
    {
        Task<ServiceResponse<List<OrderData>>> GetOrdersByDate(DateTime startDate,CancellationToken cancellationToken);
    }
}
