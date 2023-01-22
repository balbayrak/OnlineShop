using OnlineShop.Domain;

namespace OnlineShop.Order.Domain.Models
{
    public class Order : BaseEntity
    {
        public Guid BuyerId { get; set; }
        public IEnumerable<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
