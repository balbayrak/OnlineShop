using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderReflectionService.Models
{
    public class OrderInfo
    {
        public string Buyer { get; set; }
        public string ProductName { get; set; }
        public DateTime OrderCreationTime { get; set; }

        public OrderInfo()
        {

        }
    }
}
