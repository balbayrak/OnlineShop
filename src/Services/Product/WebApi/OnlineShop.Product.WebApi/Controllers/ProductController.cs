using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Wrappers;
using OnlineShop.Product.Application.Dto.Product;
using OnlineShop.Product.Application.Features.Commands;
using OnlineShop.Product.Application.Features.Queries.Product;
using OnlineShop.WebApi;
using System.Net;

namespace OnlineShop.Product.WebApi.Controllers
{
    [ApiController]
    public class ProductController : BaseController
    {
        public ProductController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("api/[controller]/all")]
        [ProducesResponseType(typeof(PagedResponse<List<ProductDto>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllProducts([FromQuery] ProductSearchDto productSearchDto)
        {
            var query = new GetAllProductsQuery(productSearchDto);
            return Ok(await Mediator.Send(query));
        }


        [HttpGet]
        [Route("api/[controller]/read")]
        [ProducesResponseType(typeof(ServiceResponse<ProductDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(Guid productId)
        {
            var query = new GetByIdProductQuery(productId);
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        [Route("api/[controller]/create")]
        [ProducesResponseType(typeof(ServiceResponse<Guid>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> Create(CreateProductDto createProductDto)
        {
            var command = new CreateProductCommand(createProductDto);
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        [Route("api/[controller]/update")]
        public async Task<IActionResult> Update(UpdateProductDto updateProductDto)
        {
            var query = new UpdateProductCommand(updateProductDto);
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        [Route("api/[controller]/delete")]
        public async Task<IActionResult> Delete(Guid productId)
        {
            var query = new DeleteProductCommand(productId);
            return Ok(await Mediator.Send(query));
        }
    }
}
