using OnlineShop.Product.Application.Dto.ProductFeature;

namespace OnlineShop.Product.Application.Dto.Product
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public ProductFeatureDto ProductFeature { get; set; }

    }
}
