using AutoMapper;
using OnlineShop.Product.Application.Dto.Product;

namespace OnlineShop.Product.Application.Mapping
{
    public class ProductMap : Profile
    {
        public ProductMap()
        {
            CreateMap<Domain.Models.Product,ProductDto>().ReverseMap();
            CreateMap<Domain.Models.Product, CreateProductDto>().ReverseMap();
            CreateMap<Domain.Models.Product, UpdateProductDto>().ReverseMap();
            CreateMap<ProductDto, UpdateProductDto>().ReverseMap();
        }
    }
}
