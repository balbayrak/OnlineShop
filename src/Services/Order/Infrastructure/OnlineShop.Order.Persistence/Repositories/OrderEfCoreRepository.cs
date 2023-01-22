using OnlineShop.Order.Application.Dto;
using OnlineShop.Order.Application.Repositories;
using OnlineShop.Order.Persistence.Repositories.EfCore.Context;
using OnlineShop.Persistence.Repository.EfCore;
using OnlineShop.Order.Domain.Models;

namespace OnlineShop.Order.Persistence.Repositories
{
    public class OrderEfCoreRepository : BaseEfCoreRepository<OrderDbContext, Domain.Models.Order, OrderSearchDto>, IOrderRepository
    {
        public OrderEfCoreRepository(OrderDbContext dbContext) : base(dbContext)
        {
        }
    }
}
