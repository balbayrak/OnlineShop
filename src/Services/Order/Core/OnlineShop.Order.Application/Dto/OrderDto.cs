using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Order.Application.Dto
{
    public class OrderDto
    {
        public string BuyerId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
