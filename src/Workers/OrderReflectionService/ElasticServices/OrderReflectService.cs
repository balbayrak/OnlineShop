using OnlineShop.ElasticSearchService;
using OrderReflectionService.Models;

namespace OrderReflectionService.ElasticServices
{
    public class OrderReflectService : ElasticService<OrderInfo>, IOrderReflectService
    {
        public override string IndexName => "order-reflection-data";
        public OrderReflectService(IConfiguration configuration) : base(configuration)
        {
        }

    }
}
