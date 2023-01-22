using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OnlineShop.Application.Common;
using OnlineShop.Application.Wrappers;
using OnlineShop.Customer.Application.Dto;
using OnlineShop.Customer.Application.Exceptions;
using OnlineShop.Customer.Application.Repositories;

namespace OnlineShop.Customer.Application.Features.Commands
{
    public class UpdateCustomerCommand : IRequest<ServiceResponse<CustomerDto>>,ICorrelated
    {
        public Guid CorrelationId { get; set; }
        public UpdateCustomerDto updateCustomerDto { get; set; }

        public UpdateCustomerCommand(UpdateCustomerDto dto)
        {
            updateCustomerDto = dto;
            CorrelationId = Guid.NewGuid();
        }
        public UpdateCustomerCommand(UpdateCustomerDto dto,Guid correlationId)
        {
            updateCustomerDto = dto;
            CorrelationId= correlationId;
        }

        public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, ServiceResponse<CustomerDto>>
        {
            private readonly ILogger<UpdateCustomerCommand> _logger;
            private readonly ICustomerRepository _customerRepository;
            private readonly IMapper _mapper;

            public UpdateCustomerCommandHandler(ICustomerRepository customerRepository,
                IMapper mapper,
                ILogger<UpdateCustomerCommand> logger)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<ServiceResponse<CustomerDto>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
            {
                _logger.LogInformation($"UpdateCustomerCommand start with correlationId:{request.CorrelationId.ToString("N")}");

                var checkCustomer = await _customerRepository.GetAsync(request.updateCustomerDto.Id);
                if (checkCustomer != null)
                {
                    var customer = _mapper.Map<Domain.Models.Customer>(request.updateCustomerDto);
                    customer = await _customerRepository.UpdateAsync(customer, true);
                    var dto = _mapper.Map<CustomerDto>(customer);

                    _logger.LogInformation($"UpdateCustomerCommand ends with correlationId:{request.CorrelationId.ToString("N")}");

                    return new ServiceResponse<CustomerDto>
                    {
                        IsSuccess = true,
                        Value = dto
                    };
                }
                else
                {
                    _logger.LogInformation($"Customer not found with productId:{request.updateCustomerDto.Id}");

                    throw new CustomerNotFoundException();
                }
            }
        }
    }
}
