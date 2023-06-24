using Application.Mediator.Commands.Room.Create;
using Application.Mediator.Queries.Room.GetRooms;
using Common.Response;

namespace Blazor.Services.Request.Room
{
    public interface IRoomRequestService
    {
        Task<RequestResponseData<List<GetRoomsViewModel>>> GetRoomsAsync(GetRoomsQuery query);
        Task<RequestResponseData<bool>> CreateRoomAsync(CreateRoomCommand command);
    }
}