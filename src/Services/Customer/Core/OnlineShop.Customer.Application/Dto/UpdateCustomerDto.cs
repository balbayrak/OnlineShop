namespace OnlineShop.Customer.Application.Dto
{
    public class UpdateCustomerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public AddressDto Address { get; set; }
    }
}
