using Api.Controllers.Base;
using Application.Mediator.Queries.User.GetUserRooms;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : BaseApiController
    {
        public UserController(IMediator mediator) : base(mediator) { }

        [HttpPost]
        [Route("rooms")]
        public async Task<IActionResult> GetUserRooms([FromBody] GetUserRoomsQuery query)
        {
            return Ok(await base.Mediator.Send(query));
        }
    }
}