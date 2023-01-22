using OnlineShop.Application.Dto;

namespace OnlineShop.Customer.Application.Dto
{
    public class CustomerSearchDto : PagedSearchDto
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
