using OnlineShop.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Customer.Application.Repositories
{
    public interface ICustomerCommandRepository : ICommandRepository<Domain.Models.Customer>
    {
    }
}
