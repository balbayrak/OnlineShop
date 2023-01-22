using OnlineShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Customer.Domain.Models
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public Address Address { get; set; }
    }
}
