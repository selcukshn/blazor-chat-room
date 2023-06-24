using Application.Mediator.Commands.Room.Create;
using Application.Mediator.Queries.Room.GetRooms;
using Blazor.Extensions;
using Blazor.Services.Request.Base;
using Common.Response;
using Microsoft.AspNetCore.Components.Authorization;

namespace Blazor.Services.Request.Room
{
    public class RoomRequestService : BaseRequest, IRoomRequestService
    {
        const string ApiEndpoint = "/api/room";
        public RoomRequestService(HttpClient client, AuthenticationStateProvider authenticationStateProvider) : base(client, authenticationStateProvider) { }

        public async Task<RequestResponseData<List<GetRoomsViewModel>>> GetRoomsAsync(GetRoomsQuery query)
        {
            if (await base.AuthenticationStateProvider.HaveAuthorizedUserAsync())
                query.UserId = await base.AuthenticationStateProvider.GetAuthorizedUserIdAsync();
            return await base.GetAsync<List<GetRoomsViewModel>>($"{ApiEndpoint}{query.ToString()}");
        }
        public async Task<RequestResponseData<bool>> CreateRoomAsync(CreateRoomCommand command)
        {
            command.UserId = await base.AuthenticationStateProvider.GetAuthorizedUserIdAsync();
            return await base.PostAsync<bool>($"{ApiEndpoint}/create", command);
        }
    }
}