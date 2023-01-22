namespace OnlineShop.Integration
{
    public abstract class BaseIntegrationEvent : IIntegrationEvent
    {
        public Guid CorrelationId { get; set; }
    }
}
