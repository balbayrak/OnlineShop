﻿using OnlineShop.Application.Tracing;

namespace OnlineShop.Integration.Correlation
{
    public class CorrelationIdProvider : ICorrelationIdProvider
    {
        private readonly Lazy<ICorrelationIdConsumeContextAccessor> _consumeContextAccessor;
        private readonly Lazy<ICorrelationIdHttpContextAccessor> _httpContextAccessor;

        public CorrelationIdProvider(Lazy<ICorrelationIdHttpContextAccessor> httpContextAccessor,
            Lazy<ICorrelationIdConsumeContextAccessor> consumeContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _consumeContextAccessor = consumeContextAccessor;
        }

        public async ValueTask<Guid?> GetCorrelationIdAsync()
        {
            var correlationIdStr = await _httpContextAccessor.Value.GetCorrelationIdAsync();

            if (string.IsNullOrEmpty(correlationIdStr))
            {
                correlationIdStr = await _consumeContextAccessor.Value.GetCorrelationIdAsync();
            }

            if (!string.IsNullOrEmpty(correlationIdStr))
            {
                return new Guid(correlationIdStr);
            }

            return null;
        }
    }
}
