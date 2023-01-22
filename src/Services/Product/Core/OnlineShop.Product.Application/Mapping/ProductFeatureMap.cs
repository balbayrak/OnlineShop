using AutoMapper;
using OnlineShop.Product.Application.Dto.ProductFeature;
using OnlineShop.Product.Domain.Models;

namespace OnlineShop.Product.Application.Mapping
{
    public class ProductFeatureMap : Profile
    {
        public ProductFeatureMap()
        {
            CreateMap<ProductFeature, ProductFeatureDto>().ReverseMap();
        }
    }
}
