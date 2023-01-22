using AutoMapper;
using OnlineShop.Order.Application.Dto;
using OnlineShop.Order.Domain.Models;

namespace OnlineShop.Order.Application.Mapping
{
    public class OrderItemMap : Profile
    {
        public OrderItemMap()
        {
            CreateMap<OrderItemDto, OrderItem>().ReverseMap();
        }
    }
}
