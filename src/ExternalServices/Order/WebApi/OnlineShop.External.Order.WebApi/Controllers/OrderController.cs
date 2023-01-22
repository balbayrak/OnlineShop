using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Wrappers;
using OnlineShop.External.Order.Application.Dto;
using OnlineShop.External.Order.Application.Feature.Queries;
using OnlineShop.WebApi;
using System.Net;

namespace OnlineShop.External.Order.WebApi.Controllers
{
    [ApiController]
    public class OrderController : BaseController
    {
        public OrderController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Route("api/[controller]/getorders")]
        [ProducesResponseType(typeof(ServiceResponse<List<OrderData>>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> GetOrders(OrderSearchDto orderSearchDto)
        {
            var command = new GetAllOrdersDataByDateQuery(orderSearchDto);
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
