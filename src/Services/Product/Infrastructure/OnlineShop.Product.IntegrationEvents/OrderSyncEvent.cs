using OnlineShop.Integration;

namespace OnlineShop.Product.IntegrationEvents
{
    public class OrderSyncEvent : IIntegrationEvent
    {
        public Guid BuyerId { get; set; }
        public string Buyer { get; set; }
        public string ProductName { get; set; }
        public DateTime OrderCreationTime { get; set; }
        public Guid CorrelationId { get; set; }
    }
}
