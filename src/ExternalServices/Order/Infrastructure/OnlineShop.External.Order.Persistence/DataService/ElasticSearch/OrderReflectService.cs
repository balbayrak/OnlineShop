using Microsoft.Extensions.Configuration;
using OnlineShop.Application.Wrappers;
using OnlineShop.ElasticSearchService;
using OnlineShop.External.Order.Application.Dto;

namespace OnlineShop.External.Order.Persistence.DataService.ElasticSearch
{
    public class OrderReflectService : ElasticService<OrderData>, IOrderReflectService
    {
        public override string IndexName => "order-reflection-data";
        public OrderReflectService(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<ServiceResponse<List<OrderData>>> GetOrdersByDate(DateTime startDate,CancellationToken cancellationToken)
        {
            var response = await ElasticClient.SearchAsync<OrderData>(s => s
                                              .Index(IndexName)
                                              .From(0)
                                              .Size(10)
                                              .Query(q => q
                                              .DateRange(p=>p.Field(f=>f.OrderCreationTime).GreaterThan(startDate))), cancellationToken);

            if (response.IsValid)
            {
                ServiceResponse<List<OrderData>> serviceResponse = new ServiceResponse<List<OrderData>>();
                serviceResponse.IsSuccess = true;
                serviceResponse.Value = response.Documents.Select(p => new OrderData
                {
                    Buyer = p.Buyer,
                    OrderCreationTime = p.OrderCreationTime,
                    ProductName = p.ProductName
                }).ToList();

                return serviceResponse;
            }

            else
            {
                return new PagedResponse<List<OrderData>>
                {
                    IsSuccess = false
                };
            }
        }
    }
}
