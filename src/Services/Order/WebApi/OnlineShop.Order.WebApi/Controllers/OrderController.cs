using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Wrappers;
using OnlineShop.Order.Application.Dto;
using OnlineShop.Order.Application.Features.Commands.Order;
using OnlineShop.WebApi;
using System.Net;

namespace OnlineShop.Order.WebApi.Controllers
{
    [ApiController]
    public class OrderController : BaseController
    {
        public OrderController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Route("api/[controller]/create")]
        [ProducesResponseType(typeof(ServiceResponse<Guid>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> Create(OrderCreateDto orderCreateDto)
        {
            var command = new CreateOrderCommand(orderCreateDto);
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
