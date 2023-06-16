using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Base
{
    public class BaseApiController : ControllerBase
    {
        protected IMediator Mediator { get; set; }
        public BaseApiController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}