using OnlineShop.Application.Repositories;
using OnlineShop.Customer.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Customer.Application.Repositories
{
    public interface ICustomerRepository : IRepository<Domain.Models.Customer, CustomerSearchDto>
    {
    }
}
