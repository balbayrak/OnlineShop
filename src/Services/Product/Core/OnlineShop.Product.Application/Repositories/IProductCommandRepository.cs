using OnlineShop.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Product.Application.Repositories
{
    public interface IProductCommandRepository : ICommandRepository<Domain.Models.Product>
    {
    }
}
