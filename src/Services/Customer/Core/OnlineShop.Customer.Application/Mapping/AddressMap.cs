using AutoMapper;
using OnlineShop.Customer.Application.Dto;
using OnlineShop.Customer.Domain.Models;

namespace OnlineShop.Customer.Application.Mapping
{
    public class AddressMap : Profile
    {
        public AddressMap()
        {
            CreateMap<AddressDto, Address>().ReverseMap();
        }
    }
}
