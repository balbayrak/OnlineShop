using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OnlineShop.Application.Common;
using OnlineShop.Application.Wrappers;
using OnlineShop.Integration;
using OnlineShop.Order.Application.Dto;
using OnlineShop.Order.Application.Repositories;
using OnlineShop.Order.IntegrationEvent;
using OnlineShop.Product.IntegrationEvents;
using System.Reflection.Metadata.Ecma335;

namespace OnlineShop.Order.Application.Features.Commands.Order
{
    public class CreateOrderCommand : IRequest<ServiceResponse<Guid>>,ICorrelated
    {
        public OrderCreateDto orderCreateDto { get; set; }
        public Guid CorrelationId { get; set; }

        public CreateOrderCommand(OrderCreateDto dto)
        {
            orderCreateDto = dto;
            CorrelationId= Guid.NewGuid();
        }
        public CreateOrderCommand(OrderCreateDto dto,Guid correlationId)
        {
            orderCreateDto = dto;
            CorrelationId = correlationId;
        }

        public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, ServiceResponse<Guid>>
        {
            private readonly IOrderRepository _orderRepository;
            private readonly IMapper _mapper;

            private readonly IIntegrationEventPublisher _integrationEventPublisher;
            private readonly ILogger<CreateOrderCommand> _logger;
            public CreateOrderCommandHandler(IOrderRepository orderRepository,
                IMapper mapper, IIntegrationEventPublisher integrationEventPublisher, 
                ILogger<CreateOrderCommand> logger)
            {
                _orderRepository = orderRepository;
                _mapper = mapper;
                _integrationEventPublisher = integrationEventPublisher;
                _logger = logger;
            }

            public async Task<ServiceResponse<Guid>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
            {
                _logger.LogInformation($"CreateOrderCommand start with correlationId:{request.CorrelationId}");
                var order = _mapper.Map<Domain.Models.Order>(request.orderCreateDto);
                order = await _orderRepository.InsertAsync(order, true);

                if (order != null && order.Id != Guid.Empty)
                {
                    _logger.LogInformation($"CreateOrderCommand created orderId:{order.Id.ToString("N")}");
                    var productSyncEvent = new ProductSyncEvent(order.Id);

                    productSyncEvent.BuyerId = request.orderCreateDto.BuyerId;
                    productSyncEvent.Buyer = request.orderCreateDto.BuyerNameSurname;

                    productSyncEvent.ProductSyncItems = new List<ProductSyncItem>();
                    request.orderCreateDto.Items.ToList().ForEach(item =>
                    {
                        productSyncEvent.ProductSyncItems.Add(new ProductSyncItem { Count = item.Count, ProductId = item.ProductId });
                    });

                    _integrationEventPublisher.AddEvent(productSyncEvent);
                    await _integrationEventPublisher.Publish();

                    return new ServiceResponse<Guid>(order.Id);
                }

                return new ServiceResponse<Guid>
                {
                    IsSuccess = false,
                    Value = Guid.Empty
                };
            }
        }
    }
}
