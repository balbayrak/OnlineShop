using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Order.Application.Dto
{
    public class OrderDto
    {
        public Guid BuyerId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
