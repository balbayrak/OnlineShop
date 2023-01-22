using OnlineShop.Application.Exceptions;

namespace OnlineShop.Customer.Application.Exceptions
{
    public class CustomerNotFoundException : NotFoundException
    {
        public CustomerNotFoundException() : base(ExceptionMessages.CUSTOMER_NOTFOUND)
        {
        }
    }
}
