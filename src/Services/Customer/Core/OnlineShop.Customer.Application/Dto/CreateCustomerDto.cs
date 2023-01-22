namespace OnlineShop.Customer.Application.Dto
{
    public class CreateCustomerDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public AddressDto Address { get; set; }
    }
}
