using OnlineShop.Application.Repositories;
using OnlineShop.Customer.Application.Dto;

namespace OnlineShop.Customer.Application.Repositories
{
    public interface ICustomerReadOnlyRepository : IReadOnlyRepository<Domain.Models.Customer, CustomerSearchDto>
    {
    }
}
