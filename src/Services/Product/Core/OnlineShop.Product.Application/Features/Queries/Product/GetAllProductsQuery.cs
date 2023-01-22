using AutoMapper;
using MediatR;
using OnlineShop.Application.Wrappers;
using OnlineShop.Product.Application.Dto.Product;
using OnlineShop.Product.Application.Repositories;

namespace OnlineShop.Product.Application.Features.Queries.Product
{
    public class GetAllProductsQuery : IRequest<PagedResponse<List<ProductDto>>>
    {
        public ProductSearchDto ProductSearchDto { get; set; }

        public GetAllProductsQuery(ProductSearchDto productSearchDto)
        {
            ProductSearchDto = productSearchDto;
        }
        public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, PagedResponse<List<ProductDto>>>
        {
            private readonly IProductReadOnlyRepository _productRepository;
            private readonly IMapper _mapper;
            public GetAllProductsHandler(IMapper mapper,
                IProductReadOnlyRepository productRepository)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }
            public async Task<PagedResponse<List<ProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var productListResponse = await _productRepository.GetAllAsync(request.ProductSearchDto, cancellationToken);
                var productDtos = _mapper.Map<List<ProductDto>>(productListResponse.Value);

                return new PagedResponse<List<ProductDto>>
                {
                    Value = productDtos,
                    IsSuccess = true,
                    TotalCount = productListResponse.TotalCount
                };
            }
        }
    }
}
