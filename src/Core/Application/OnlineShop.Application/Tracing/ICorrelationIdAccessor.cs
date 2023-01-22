namespace OnlineShop.Application.Tracing
{
    public interface ICorrelationIdAccessor
    {
        Task<string> GetCorrelationIdAsync();
    }
}
