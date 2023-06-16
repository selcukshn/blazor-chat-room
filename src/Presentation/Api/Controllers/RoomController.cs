using Api.Controllers.Base;
using Application.Mediator.Commands.Room.Create;
using Application.Mediator.Queries.Room.GetRooms;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/room")]
    public class RoomController : BaseApiController
    {
        public RoomController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetRooms([FromQuery] GetRoomsQuery query)
        {
            return Ok(await base.Mediator.Send(query));
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateRoom([FromBody] CreateRoomCommand command)
        {
            return Ok(await base.Mediator.Send(command));
        }
    }
}