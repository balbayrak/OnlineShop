using OnlineShop.Application.Repositories;
using OnlineShop.Order.Application.Dto;

namespace OnlineShop.Order.Application.Repositories
{
    public interface IOrderRepository : IRepository<Domain.Models.Order, OrderSearchDto>
    {
    }
}
