using AutoMapper;
using Microsoft.Extensions.Logging;
using OnlineShop.Application.Common;
using OnlineShop.Application.Features.Commands;
using OnlineShop.Product.Application.Dto.Product;
using OnlineShop.Product.Application.Repositories;

namespace OnlineShop.Product.Application.Features.Commands
{
    public class CreateProductCommand : CreateCommand<CreateProductDto>
    {

        public CreateProductCommand(CreateProductDto dto) : base(dto)
        {
        }

        public class CreateProductCommandHandler : CreateCommandHandler<Domain.Models.Product, CreateProductDto, CreateProductCommand, IProductCommandRepository>
        {
            public CreateProductCommandHandler(IProductCommandRepository repository,
                IMapper mapper,
                ILogger<CreateProductCommand> logger) : base(repository, mapper, logger)
            {
            }
        }
    }
}
