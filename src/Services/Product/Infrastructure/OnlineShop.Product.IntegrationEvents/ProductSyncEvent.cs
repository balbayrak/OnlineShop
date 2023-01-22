using OnlineShop.Integration;

namespace OnlineShop.Product.IntegrationEvents
{
    public class ProductSyncEvent : IIntegrationEvent
    {
        public Guid CorrelationId { get; set; }
        public Guid BuyerId { get; set; }
        public string Buyer { get; set; }
        public List<ProductSyncItem> ProductSyncItems { get; set; }

        public ProductSyncEvent()
        {

        }

        public ProductSyncEvent(Guid correlationId)
        {
            CorrelationId = correlationId;
        }


    }
}
