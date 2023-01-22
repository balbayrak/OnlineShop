namespace OnlineShop.Product.Application.Exceptions
{
    public class ExceptionMessages
    {
        public const string PRODUCT_CREATEDTO_NOT_EMPTY = "createProductDto shouldn't be empty";
        public const string PRODUCT_UPDATEDTO_NOT_EMPTY = "updateProductDto shouldn't be empty";
        public const string PRODUCT_CODE_EMPTY = "Product code shouldn't be empty";
        public const string PRODUCT_NAME_EMPTY = "Product code shouldn't be empty";
        public const string PRODUCT_NOTFOUND = "Product not found";
        public const string PRODUCT_CODE_ALREADY_EXIST = "{0} productCode already exist";
    }
}
