using MassTransit;
using OnlineShop.Product.IntegrationEvents;
using OrderReflectionService.ElasticServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderReflectionService.Consumers
{
    public class OrderSyncConsumer : IConsumer<OrderSyncEvent>
    {
        private readonly IOrderReflectService _orderReflectService;
        private readonly ILogger<OrderSyncConsumer> _logger;
        public OrderSyncConsumer(IOrderReflectService orderReflectService, 
            ILogger<OrderSyncConsumer> logger)
        {
            _orderReflectService = orderReflectService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<OrderSyncEvent> context)
        {
            _logger.LogInformation($"OrderSyncConsumer started reflect order info. CorrelatioId:{context.Message.CorrelationId.ToString("N")}");
            
            await _orderReflectService.Insert(new Models.OrderInfo
            {
                Buyer = context.Message.Buyer,
                OrderCreationTime = context.Message.OrderCreationTime,
                ProductName = context.Message.ProductName
            });
            
            _logger.LogInformation($"OrderSyncConsumer completed reflect order info. CorrelatioId:{context.Message.CorrelationId.ToString("N")}");
        }
    }
}
