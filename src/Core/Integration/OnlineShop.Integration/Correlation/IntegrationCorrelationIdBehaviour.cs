using MassTransit;
using MassTransit.Context;
using MediatR;
using Microsoft.Extensions.Logging;
using OnlineShop.Application.Common;

namespace OnlineShop.Integration.Correlation
{
    public class IntegrationCorrelationIdBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ConsumeContext _consumeContext;
        private readonly ILogger<IntegrationCorrelationIdBehaviour<TRequest, TResponse>> _logger;
        public IntegrationCorrelationIdBehaviour(ConsumeContext consumeContext, ILogger<Correlation.IntegrationCorrelationIdBehaviour<TRequest, TResponse>> logger)
        {
            _consumeContext = consumeContext;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (request is ICorrelated correlated)
            {
                try
                {
                    if (_consumeContext is not MissingConsumeContext && _consumeContext.CorrelationId.HasValue)
                    {
                        correlated.CorrelationId = _consumeContext.CorrelationId.Value;
                    }
                }
                catch(Exception ex)
                {
                    _logger.Log(LogLevel.Error, "CorrelationId cannot set", ex);
                }
            }
            return await next();
        }

    }
}
