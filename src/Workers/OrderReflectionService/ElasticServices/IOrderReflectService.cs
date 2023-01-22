using OnlineShop.ElasticSearchService;
using OrderReflectionService.Models;

namespace OrderReflectionService.ElasticServices
{
    public interface IOrderReflectService : IElasticService<OrderInfo>
    {
    }
}
