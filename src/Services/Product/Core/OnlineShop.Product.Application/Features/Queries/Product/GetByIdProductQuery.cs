using AutoMapper;
using MediatR;
using OnlineShop.Application.Wrappers;
using OnlineShop.Product.Application.Dto.Product;
using OnlineShop.Product.Application.Repositories;

namespace OnlineShop.Product.Application.Features.Queries.Product
{
    public class GetByIdProductQuery : IRequest<ServiceResponse<ProductDto>>
    {
        public Guid ProductId { get; set; }

        public GetByIdProductQuery(Guid productId)
        {
            ProductId = productId;
        }
        public class GetByIdProductHandler : IRequestHandler<GetByIdProductQuery, ServiceResponse<ProductDto>>
        {
            private readonly IProductReadOnlyRepository _productRepository;
            private readonly IMapper _mapper;
            public GetByIdProductHandler(IMapper mapper,
                IProductReadOnlyRepository productRepository)
            {
                _mapper = mapper;
                _productRepository = productRepository;
            }
            public async Task<ServiceResponse<ProductDto>> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetAsync(request.ProductId, cancellationToken);
                var productDto = _mapper.Map<ProductDto>(product);

                return new ServiceResponse<ProductDto>
                {
                    Value = productDto,
                    IsSuccess = true
                };
            }
        }
    }
}
