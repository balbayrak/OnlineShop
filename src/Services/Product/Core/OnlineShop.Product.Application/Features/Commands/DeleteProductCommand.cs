using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OnlineShop.Application.Common;
using OnlineShop.Application.Features.Commands;
using OnlineShop.Application.Wrappers;
using OnlineShop.Product.Application.Exceptions.Product;
using OnlineShop.Product.Application.Repositories;

namespace OnlineShop.Product.Application.Features.Commands
{
    public class DeleteProductCommand : IRequest<ServiceResponse<bool>>,ICorrelated
    {
        public Guid CorrelationId { get; set; }
        public Guid ProductId { get; set; }

        public DeleteProductCommand(Guid productId)
        {
            ProductId = productId;
            CorrelationId = Guid.NewGuid();
        }

        public DeleteProductCommand(Guid productId,Guid correlationId)
        {
            ProductId = productId;
            CorrelationId = correlationId;
        }

        public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ServiceResponse<bool>>
        {
            private readonly ILogger<DeleteProductCommand> _logger;
            private readonly IProductRepository _productRepository;

            public DeleteProductCommandHandler(IProductRepository productRepository, ILogger<DeleteProductCommand> logger)
            {
                _productRepository = productRepository;
                _logger = logger;
            }

            public async Task<ServiceResponse<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                _logger.LogInformation($"DeleteProductCommand start with correlationId:{request.CorrelationId.ToString("N")}");

                var checkProduct = await _productRepository.GetAsync(request.ProductId);
                if (checkProduct != null)
                {
                    await _productRepository.DeleteAsync(request.ProductId, true);

                    _logger.LogInformation($"DeleteProductCommand ends with correlationId:{request.CorrelationId.ToString("N")}");
                  
                    return new ServiceResponse<bool>
                    {
                        IsSuccess = true,
                        Value = true
                    };
                }
                else
                {
                    _logger.LogInformation($"Product not found with productId:{request.ProductId}");

                    throw new ProductNotFoundException();
                }
            }
        }
    }
}
