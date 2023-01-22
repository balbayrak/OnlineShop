namespace OnlineShop.Order.Application.Dto
{
    public class OrderCreateDto
    {
        public string BuyerId { get; set; }
        public string BuyerNameSurname { get; set; }
        public IEnumerable<OrderItemDto> Items { get; set; }
    }
}
