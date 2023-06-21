using Application.Mediator.Commands.Room.Create;
using Application.Mediator.Queries.Room.GetRooms;
using Blazor.Services.Request.Base;
using Common.Response;

namespace Blazor.Services.Request.Room
{
    public class RoomRequestService : BaseRequest, IRoomRequestService
    {
        const string ApiEndpoint = "/api/room";
        public RoomRequestService(HttpClient client) : base(client) { }

        public async Task<RequestResponseData<List<GetRoomsViewModel>>> GetRoomsAsync(GetRoomsQuery query)
        {
            return await base.GetAsync<List<GetRoomsViewModel>>($"{ApiEndpoint}{query.ToString()}");
        }
        public async Task<RequestResponseData<string>> CreateRoomAsync(CreateRoomCommand command)
        {
            return await base.PostAsync<string>($"{ApiEndpoint}", command);
        }
    }
}