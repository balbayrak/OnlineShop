using AutoMapper;
using OnlineShop.Order.Application.Dto;

namespace OnlineShop.Order.Application.Mapping
{
    public class OrderMap : Profile
    {
        public OrderMap()
        {
            CreateMap<OrderDto, OnlineShop.Order.Domain.Models.Order>().ReverseMap();
            CreateMap<OrderCreateDto, OnlineShop.Order.Domain.Models.Order>().ReverseMap();
        }
    }
}
