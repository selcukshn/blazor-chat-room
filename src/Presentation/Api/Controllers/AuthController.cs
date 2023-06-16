using Api.Controllers.Base;
using Application.Mediator.Queries.Auth.Login;
using Application.Mediator.Queries.Auth.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : BaseApiController
    {
        public AuthController(IMediator mediator) : base(mediator) { }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginQuery query)
        {
            return Ok(await base.Mediator.Send(query));
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command)
        {
            return Ok(await base.Mediator.Send(command));
        }
    }
}