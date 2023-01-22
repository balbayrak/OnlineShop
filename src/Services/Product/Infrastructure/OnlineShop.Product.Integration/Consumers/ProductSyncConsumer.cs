using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using OnlineShop.DistributedLock;
using OnlineShop.Integration;
using OnlineShop.Product.Application.Dto.Product;
using OnlineShop.Product.Application.Features.Commands;
using OnlineShop.Product.Application.Features.Queries.Product;
using OnlineShop.Product.IntegrationEvents;

namespace OnlineShop.Product.Integration.Consumers
{
    public class ProductSyncConsumer : IConsumer<ProductSyncEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IIntegrationEventPublisher _integrationPublisher;
        private readonly IDistributedLockManager _distributedLockManager;
        private readonly ILogger<ProductSyncConsumer> _logger;
        public ProductSyncConsumer(IMediator mediator,
            IMapper mapper,
            IIntegrationEventPublisher integrationPublisher,
            IDistributedLockManager distributedLockManager,
            ILogger<ProductSyncConsumer> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _integrationPublisher = integrationPublisher;
            _distributedLockManager = distributedLockManager;
            _logger = logger;
        }

        private string ProductOperationLockKey(Guid productId) => $"product-operation-lock-{productId}";

        public async Task Consume(ConsumeContext<ProductSyncEvent> context)
        {
            _logger.LogInformation($"ProductSyncConsumer started sync product info. CorrelatioId:{context.Message.CorrelationId.ToString("N")}");
            ProductSyncEvent productSyncEvent = context.Message;
            await ProductQuantityChanged(productSyncEvent);

            _logger.LogInformation($"ProductSyncConsumer completed sync product info. CorrelatioId:{context.Message.CorrelationId.ToString("N")}");
        }

        private async Task ProductQuantityChanged(ProductSyncEvent productSyncEvent)
        {
            foreach (var productItem in productSyncEvent.ProductSyncItems)
            {
                var query = new GetByIdProductQuery(productItem.ProductId);
                var productResult = await _mediator.Send(query);
                if (productResult.IsSuccess && productResult.Value != null)
                {
                    var productDto = productResult.Value;
                    var updateProductDto = _mapper.Map<UpdateProductDto>(productDto);

                    await _distributedLockManager.LockAsync(ProductOperationLockKey(productItem.ProductId),
                               async () =>
                               {
                                   updateProductDto.Quantity = productDto.Quantity - productItem.Count;

                                   var query = new UpdateProductCommand(updateProductDto);
                                   await _mediator.Send(query);

                                   var orderSyncEvent = new OrderSyncEvent();

                                   orderSyncEvent.BuyerId = productSyncEvent.BuyerId;
                                   orderSyncEvent.Buyer = productSyncEvent.Buyer;
                                   orderSyncEvent.ProductName = productResult.Value.Name;
                                   orderSyncEvent.OrderCreationTime = DateTime.Now;

                                   _integrationPublisher.AddEvent(orderSyncEvent);
                                   await _integrationPublisher.Publish();
                               });
                }
            }
        }
    }
}
