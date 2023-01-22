using OnlineShop.Customer.Application.Dto;
using OnlineShop.Customer.Application.Repositories;
using OnlineShop.Customer.Persistence.Repositories.EfCore.Context;
using OnlineShop.Persistence.Repository.EfCore;

namespace OnlineShop.Customer.Persistence.Repositories
{
    public class CustomerEfCoreRepository : BaseEfCoreRepository<CustomerDbContext, Domain.Models.Customer, CustomerSearchDto>, ICustomerRepository,
        ICustomerCommandRepository, ICustomerReadOnlyRepository
    {
        public CustomerEfCoreRepository(CustomerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
