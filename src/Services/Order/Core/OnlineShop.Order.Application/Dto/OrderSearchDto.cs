using OnlineShop.Application.Dto;

namespace OnlineShop.Order.Application.Dto
{
    public class OrderSearchDto : PagedSearchDto
    {
        public string BuyerId { get; set; }
    }
}
