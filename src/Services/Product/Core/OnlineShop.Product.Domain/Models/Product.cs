using OnlineShop.Domain;

namespace OnlineShop.Product.Domain.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public ProductFeature ProductFeature { get; set; }

    }
}
