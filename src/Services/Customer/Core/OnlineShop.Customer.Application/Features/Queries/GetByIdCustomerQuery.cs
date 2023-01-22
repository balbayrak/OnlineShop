using AutoMapper;
using MediatR;
using OnlineShop.Application.Wrappers;
using OnlineShop.Customer.Application.Dto;
using OnlineShop.Customer.Application.Repositories;

namespace OnlineShop.Customer.Application.Features.Queries
{
    public class GetByIdCustomerQuery : IRequest<ServiceResponse<CustomerDto>>
    {
        public Guid CustomerId { get; set; }

        public GetByIdCustomerQuery(Guid CustomerId)
        {
            CustomerId = CustomerId;
        }
        public class GetByIdCustomerHandler : IRequestHandler<GetByIdCustomerQuery, ServiceResponse<CustomerDto>>
        {
            private readonly ICustomerReadOnlyRepository _customerRepository;
            private readonly IMapper _mapper;
            public GetByIdCustomerHandler(IMapper mapper,
                ICustomerReadOnlyRepository customerRepository)
            {
                _mapper = mapper;
                _customerRepository = customerRepository;
            }
            public async Task<ServiceResponse<CustomerDto>> Handle(GetByIdCustomerQuery request, CancellationToken cancellationToken)
            {
                var Customer = await _customerRepository.GetAsync(request.CustomerId, cancellationToken);
                var CustomerDto = _mapper.Map<CustomerDto>(Customer);

                return new ServiceResponse<CustomerDto>
                {
                    Value = CustomerDto,
                    IsSuccess = true
                };
            }
        }
    }
}
