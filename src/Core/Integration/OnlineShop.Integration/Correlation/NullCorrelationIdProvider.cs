using OnlineShop.Application.Tracing;

namespace OnlineShop.Integration.Correlation
{
    public class NullCorrelationIdProvider : ICorrelationIdProvider
    {
        public async ValueTask<Guid?> GetCorrelationIdAsync()
        {
            return null;
        }
    }
}
