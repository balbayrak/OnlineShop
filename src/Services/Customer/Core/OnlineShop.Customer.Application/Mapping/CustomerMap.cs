using AutoMapper;
using OnlineShop.Customer.Application.Dto;

namespace OnlineShop.Customer.Application.Mapping
{
    public class CustomerMap : Profile
    {
        public CustomerMap()
        {
            CreateMap<CustomerDto, Domain.Models.Customer>().ReverseMap();
            CreateMap<CreateCustomerDto, Domain.Models.Customer>().ReverseMap();
        }
    }
}
