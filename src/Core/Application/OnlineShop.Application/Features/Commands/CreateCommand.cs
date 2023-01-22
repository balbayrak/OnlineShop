namespace OnlineShop.Application.Features.Commands
{
    public class CreateCommand<TDto> : BaseCommand<TDto>
        where TDto : class

    {
        public CreateCommand(TDto dto) : base(dto)
        {
        }

        public CreateCommand(TDto dto,Guid correlationId) : base(dto,correlationId)
        {
        }
    }

}
