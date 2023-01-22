using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.External.Order.Application.Dto
{
    public class OrderData
    {
        public string Buyer { get; set; }
        public string ProductName { get; set; }
        public DateTime OrderCreationTime { get; set; }
    }
}
