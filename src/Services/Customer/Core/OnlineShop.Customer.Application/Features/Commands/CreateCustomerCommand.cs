using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OnlineShop.Application.Common;
using OnlineShop.Application.Wrappers;
using OnlineShop.Customer.Application.Dto;
using OnlineShop.Customer.Application.Repositories;

namespace OnlineShop.Customer.Application.Features.Commands
{
    public class CreateCustomerCommand : IRequest<ServiceResponse<Guid>>, ICorrelated
    {
        public CreateCustomerDto customerCreateDto { get; set; }
        public Guid CorrelationId { get; set; }

        public CreateCustomerCommand(CreateCustomerDto dto)
        {
            customerCreateDto = dto;
            CorrelationId = Guid.NewGuid();
        }
        public CreateCustomerCommand(CreateCustomerDto dto,Guid correlationId)
        {
            customerCreateDto = dto;
            CorrelationId = correlationId;
        }

        public class CreateOrderCommandHandler : IRequestHandler<CreateCustomerCommand, ServiceResponse<Guid>>
        {
            private readonly ILogger<CreateCustomerCommand> _logger;
            private readonly ICustomerRepository _customerRepository;
            private readonly IMapper _mapper;
            public CreateOrderCommandHandler(ICustomerRepository customerRepository,
                IMapper mapper,
                ILogger<CreateCustomerCommand> logger)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<ServiceResponse<Guid>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                _logger.LogInformation($"CreateCustomerCommand start with correlationId:{request.CorrelationId.ToString("N")}");

                var customer = _mapper.Map<Domain.Models.Customer>(request.customerCreateDto);
                customer = await _customerRepository.InsertAsync(customer, true);

                _logger.LogInformation($"CreateCustomerCommand ends with correlationId:{request.CorrelationId.ToString("N")}");


                return new ServiceResponse<Guid>
                {
                    IsSuccess = true,
                    Value = customer.Id
                };
            }
        }
    }
}
