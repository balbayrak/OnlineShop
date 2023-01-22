namespace OnlineShop.Application.Tracing
{
    public interface ICorrelationIdProvider
    {
        ValueTask<Guid?> GetCorrelationIdAsync();
    }
}
