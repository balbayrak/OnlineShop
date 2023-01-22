using AutoMapper;
using FluentValidation.Validators;
using MediatR;
using Microsoft.Extensions.Logging;
using OnlineShop.Application.Common;
using OnlineShop.Application.Wrappers;
using OnlineShop.Product.Application.Dto.Product;
using OnlineShop.Product.Application.Exceptions.Product;
using OnlineShop.Product.Application.Repositories;

namespace OnlineShop.Product.Application.Features.Commands
{
    public class UpdateProductCommand : IRequest<ServiceResponse<ProductDto>>,ICorrelated
    {
        public Guid CorrelationId { get; set; }
        public UpdateProductDto updateProductDto { get; set; }

        public UpdateProductCommand(UpdateProductDto dto)
        {
            updateProductDto = dto;
            CorrelationId = Guid.NewGuid();
        }

        public UpdateProductCommand(UpdateProductDto dto,Guid correlationId)
        {
            updateProductDto = dto;
            CorrelationId = correlationId;
        }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ServiceResponse<ProductDto>>
        {
            private readonly ILogger<UpdateProductCommand> _logger;
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public UpdateProductCommandHandler(IProductRepository productRepository,
                IMapper mapper,
                ILogger<UpdateProductCommand> logger)
            {
                _productRepository = productRepository;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<ServiceResponse<ProductDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                _logger.LogInformation($"UpdateProductCommand start with correlationId:{request.CorrelationId.ToString("N")}");

                var checkProduct = await _productRepository.GetAsync(request.updateProductDto.Id);
                if (checkProduct != null)
                {
                    var product = _mapper.Map<Domain.Models.Product>(request.updateProductDto);
                    product = await _productRepository.UpdateAsync(product, true);
                    var dto = _mapper.Map<ProductDto>(product);

                    _logger.LogInformation($"UpdateProductCommand ends with correlationId:{request.CorrelationId.ToString("N")}");

                    return new ServiceResponse<ProductDto>
                    {
                        IsSuccess = true,
                        Value = dto
                    };
                }
                else
                {
                    _logger.LogInformation($"Product not found with productId:{request.updateProductDto.Id}");

                    throw new ProductNotFoundException();
                }
            }
        }
    }
}
