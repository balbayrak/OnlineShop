using MediatR;
using OnlineShop.Application.Common;
using OnlineShop.Application.Wrappers;

namespace OnlineShop.Application.Features.Commands
{
    public class BaseCommand<TDto> : IRequest<ServiceResponse<TDto>>, ICorrelated
        where TDto : class

    {
        public Guid CorrelationId { get; set; }
        public TDto Dto { get; set; }
        public BaseCommand(TDto dto)
        {
            Dto = dto;
            CorrelationId = Guid.NewGuid();
        }

        public BaseCommand(TDto dto,Guid correlationId)
        {
            Dto = dto;
            CorrelationId = correlationId;
        }
    }

}
