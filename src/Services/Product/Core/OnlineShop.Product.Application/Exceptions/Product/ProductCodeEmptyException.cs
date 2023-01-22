using OnlineShop.Application.Exceptions;

namespace OnlineShop.Product.Application.Exceptions.Product
{
    public class ProductCodeEmptyException : ValidationException
    {
        public ProductCodeEmptyException() : base(ExceptionMessages.PRODUCT_CODE_EMPTY)
        {
        }
    }
}
