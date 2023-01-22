namespace OnlineShop.Order.Application.Dto
{
    public class OrderCreateDto
    {
        public Guid BuyerId { get; set; }
        public string BuyerNameSurname { get; set; }
        public IEnumerable<OrderItemDto> Items { get; set; }
    }
}
