using OnlineShop.Application.Wrappers;
using OnlineShop.External.Order.Application.DataService;
using OnlineShop.External.Order.Application.Dto;

namespace OnlineShop.External.Order.Persistence.DataService.ElasticSearch
{
    public class OrderDataService : IOrderDataService
    {
        private readonly IOrderReflectService _orderReflectService;

        public OrderDataService(IOrderReflectService orderReflectService)
        {
            _orderReflectService = orderReflectService;
        }

        public Task<ServiceResponse<List<OrderData>>> GetOrderDataByDate(DateTime startDate, CancellationToken cancellationToken)
        {
           return _orderReflectService.GetOrdersByDate(startDate, cancellationToken);
        }
    }
}
