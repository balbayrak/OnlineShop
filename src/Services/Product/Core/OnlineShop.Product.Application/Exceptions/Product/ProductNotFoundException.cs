using OnlineShop.Application.Exceptions;

namespace OnlineShop.Product.Application.Exceptions.Product
{
    public class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException() : base(ExceptionMessages.PRODUCT_NOTFOUND)
        {
        }
    }
}
