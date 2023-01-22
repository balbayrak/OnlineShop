using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace OnlineShop.WebApi
{
    public class BaseController : ControllerBase
    {
        protected IMediator Mediator { get; private set; }

        public BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
