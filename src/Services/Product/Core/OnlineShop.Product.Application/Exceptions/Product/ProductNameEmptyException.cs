using OnlineShop.Application.Exceptions;

namespace OnlineShop.Product.Application.Exceptions.Product
{
    public class ProductNameEmptyException : ValidationException
    {
        public ProductNameEmptyException() : base(ExceptionMessages.PRODUCT_NAME_EMPTY)
        {
        }
    }
}
