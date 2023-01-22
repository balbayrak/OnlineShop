using AutoMapper;
using Microsoft.Extensions.Logging;
using OnlineShop.Application.Dto;
using OnlineShop.Application.Repositories;
using OnlineShop.Application.Wrappers;
using OnlineShop.Domain;

namespace OnlineShop.Application.Features.Commands
{
    public class CreateCommandHandler<TEntity, TDto, TCreateCommand, TRepository> : BaseCommandHandler<TEntity, TDto, TCreateCommand, TRepository>
        where TEntity : class, IEntity
        where TDto : class
        where TRepository : ICommandRepository<TEntity>
        where TCreateCommand : CreateCommand<TDto>
    {
        protected ILogger<TCreateCommand> _logger { get; private set; }

        public CreateCommandHandler(TRepository repository, IMapper mapper,ILogger<TCreateCommand> logger) : base(repository, mapper)
        {
            _logger = logger;
        }

        public async override Task<ServiceResponse<TDto>> HandleCommand(TCreateCommand request, CancellationToken cancellationToken)
        {
            var commandTypeName = typeof(TCreateCommand).Name;
            _logger.LogInformation($"Create {commandTypeName} start with correlationId:{request.CorrelationId.ToString("N")}");
           
            var entity = Mapper.Map<TDto, TEntity>(request.Dto);
            entity = await Repository.InsertAsync(entity,true, cancellationToken);

            var dto = Mapper.Map<TEntity, TDto>(entity);

            _logger.LogInformation($"Create {commandTypeName} ends with correlationId:{request.CorrelationId.ToString("N")}");


            return new ServiceResponse<TDto>(dto);
        }
    }
}
