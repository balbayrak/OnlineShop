using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Order.IntegrationEvent
{
    public class BuyerOrderCreatedEvent
    {
        public string BuyerId { get; set; }
        public IEnumerable<OrderItemMessage> OrderItems { get; set; }
    }
}
