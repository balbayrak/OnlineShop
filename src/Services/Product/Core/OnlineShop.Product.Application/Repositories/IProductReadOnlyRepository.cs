using OnlineShop.Application.Repositories;
using OnlineShop.Product.Application.Dto.Product;

namespace OnlineShop.Product.Application.Repositories
{
    public interface IProductReadOnlyRepository : IReadOnlyRepository<Domain.Models.Product,ProductSearchDto>
    {
    }
}
