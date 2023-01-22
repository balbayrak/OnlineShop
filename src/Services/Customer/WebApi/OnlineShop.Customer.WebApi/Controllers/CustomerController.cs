using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Wrappers;
using OnlineShop.Customer.Application.Dto;
using OnlineShop.Customer.Application.Features.Commands;
using OnlineShop.Customer.Application.Features.Queries;
using OnlineShop.WebApi;
using System.Net;

namespace OnlineShop.Customer.WebApi.Controllers
{
    [ApiController]
    public class CustomerController : BaseController
    {
        public CustomerController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("api/[controller]/all")]
        [ProducesResponseType(typeof(PagedResponse<List<CustomerDto>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllCustomers([FromQuery] CustomerSearchDto CustomerSearchDto)
        {
            var query = new GetAllCustomersQuery(CustomerSearchDto);
            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("api/[controller]/read")]
        [ProducesResponseType(typeof(ServiceResponse<CustomerDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(Guid CustomerId)
        {
            var query = new GetByIdCustomerQuery(CustomerId);
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        [Route("api/[controller]/create")]
        [ProducesResponseType(typeof(ServiceResponse<Guid>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> Create(CreateCustomerDto createCustomerDto)
        {
            var command = new CreateCustomerCommand(createCustomerDto);
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        [Route("api/[controller]/update")]
        public async Task<IActionResult> Update(UpdateCustomerDto updateCustomerDto)
        {
            var query = new UpdateCustomerCommand(updateCustomerDto);
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        [Route("api/[controller]/delete")]
        public async Task<IActionResult> Delete(Guid CustomerId)
        {
            var query = new DeleteCustomerCommand(CustomerId);
            return Ok(await Mediator.Send(query));
        }
    }
}
