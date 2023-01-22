using MassTransit;
using Microsoft.Extensions.Logging;

namespace OnlineShop.Integration.Correlation
{
    public class CorrelationIdConsumeContextAccessor : ICorrelationIdConsumeContextAccessor
    {
        private readonly ILogger<CorrelationIdConsumeContextAccessor> _logger;
        private readonly ConsumeContext _consumeContext;
        public CorrelationIdConsumeContextAccessor(ConsumeContext consumeContext, ILogger<CorrelationIdConsumeContextAccessor> logger)
        {
            _consumeContext = consumeContext;
            _logger = logger;
        }

        public Task<string> GetCorrelationIdAsync()
        {
            try
            {
                if (_consumeContext != null && _consumeContext.CorrelationId.HasValue)
                {
                    return Task.FromResult(_consumeContext.CorrelationId.Value.ToString());
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Consume context correlationId bulunamadı.");
            }


            return Task.FromResult(string.Empty);
        }
    }
}
