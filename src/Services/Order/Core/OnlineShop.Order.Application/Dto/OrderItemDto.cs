using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Order.Application.Dto
{
    public class OrderItemDto
    {
        public Guid ProductId { get; set; }
        public int Count { get; set; }
    }
}
