using AutoMapper;
using MediatR;
using OnlineShop.Application.Wrappers;
using OnlineShop.External.Order.Application.DataService;
using OnlineShop.External.Order.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.External.Order.Application.Feature.Queries
{
    public class GetAllOrdersDataByDateQuery : IRequest<PagedResponse<List<OrderData>>>
    {
        public OrderSearchDto OrderSearchDto { get; set; }

        public GetAllOrdersDataByDateQuery(OrderSearchDto orderSearchDto)
        {
            OrderSearchDto = orderSearchDto;
        }
        public class GetAllOrdersDataByDateHandler : IRequestHandler<GetAllOrdersDataByDateQuery, PagedResponse<List<OrderData>>>
        {
            private readonly IOrderDataService _orderDataService;
            private readonly IMapper _mapper;
            public GetAllOrdersDataByDateHandler(IMapper mapper,
                IOrderDataService orderDataService)
            {
                _orderDataService = orderDataService;
                _mapper = mapper;
            }
            public async Task<PagedResponse<List<OrderData>>> Handle(GetAllOrdersDataByDateQuery request, CancellationToken cancellationToken)
            {
                var orderListResponse = await _orderDataService.GetOrderDataByDate(request.OrderSearchDto.StartDate, cancellationToken);

                if(orderListResponse.IsSuccess)
                {
                    return new PagedResponse<List<OrderData>>
                    {
                        Value = orderListResponse.Value,
                        IsSuccess = true,
                        TotalCount = orderListResponse.Value.Count,
                    };
                }

                return new PagedResponse<List<OrderData>>
                {
                    Value = null,
                    IsSuccess = false
                };
            }
        }
    }
}

