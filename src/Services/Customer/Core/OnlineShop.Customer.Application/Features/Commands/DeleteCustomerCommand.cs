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
    public class DeleteCustomerCommand : IRequest<ServiceResponse<bool>>, ICorrelated
    {
        public Guid CorrelationId { get; set; }
        public Guid CustomerId { get; set; }

        public DeleteCustomerCommand(Guid customerId)
        {
            CustomerId = customerId;
            CorrelationId = Guid.NewGuid();
        }
        public DeleteCustomerCommand(Guid customerId, Guid correlationId)
        {
            CustomerId = customerId;
            CorrelationId = correlationId;
        }



        public class DeleteProductCommandHandler : IRequestHandler<DeleteCustomerCommand, ServiceResponse<bool>>
        {
            private readonly ILogger<DeleteCustomerCommand> _logger;
            private readonly ICustomerRepository _customerRepository;

            public DeleteProductCommandHandler(ICustomerRepository customerRepository, ILogger<DeleteCustomerCommand> logger)
            {
                _customerRepository = customerRepository;
                _logger = logger;
            }

            public async Task<ServiceResponse<bool>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
            {
                _logger.LogInformation($"DeleteCustomerCommand start with correlationId:{request.CorrelationId.ToString("N")}");

                var checkCustomer = await _customerRepository.GetAsync(request.CustomerId);
                if (checkCustomer != null)
                {
                    await _customerRepository.DeleteAsync(request.CustomerId, true);

                    _logger.LogInformation($"DeleteCustomerCommand ends with correlationId:{request.CorrelationId.ToString("N")}");

                    return new ServiceResponse<bool>
                    {
                        IsSuccess = true,
                        Value = true
                    };
                }
                else
                {
                    _logger.LogInformation($"Customer not found with productId:{request.CustomerId}");

                    throw new CustomerNotFoundException();
                }
            }
        }
    }
}
