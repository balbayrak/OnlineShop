using AutoMapper;
using MediatR;
using OnlineShop.Application.Wrappers;
using OnlineShop.Customer.Application.Dto;
using OnlineShop.Customer.Application.Repositories;

namespace OnlineShop.Customer.Application.Features.Queries
{
    public class GetAllCustomersQuery : IRequest<PagedResponse<List<CustomerDto>>>
    {
        public CustomerSearchDto CustomerSearchDto { get; set; }

        public GetAllCustomersQuery(CustomerSearchDto customerSearchDto)
        {
            CustomerSearchDto = customerSearchDto;
        }
        public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, PagedResponse<List<CustomerDto>>>
        {
            private readonly ICustomerReadOnlyRepository _customerRepository;
            private readonly IMapper _mapper;
            public GetAllCustomersHandler(IMapper mapper,
                ICustomerReadOnlyRepository customerRepository)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
            }
            public async Task<PagedResponse<List<CustomerDto>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
            {
                var productListResponse = await _customerRepository.GetAllAsync(request.CustomerSearchDto, cancellationToken);
                var productDtos = _mapper.Map<List<CustomerDto>>(productListResponse.Value);

                return new PagedResponse<List<CustomerDto>>
                {
                    Value = productDtos,
                    IsSuccess = true,
                    TotalCount = productListResponse.TotalCount
                };
            }
        }
    }
}
