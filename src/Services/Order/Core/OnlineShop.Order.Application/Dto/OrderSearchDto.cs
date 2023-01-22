using OnlineShop.Application.Dto;

namespace OnlineShop.Order.Application.Dto
{
    public class OrderSearchDto : PagedSearchDto
    {
        public Guid BuyerId { get; set; }
    }
}
