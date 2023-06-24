using Blazor.Services.Request.Base;
using Microsoft.AspNetCore.Components.Authorization;

namespace Blazor.Services.Request.User
{
    public class UserRequestService : BaseRequest, IUserRequestService
    {
        public UserRequestService(HttpClient client, AuthenticationStateProvider authenticationStateProvider) : base(client, authenticationStateProvider) { }
    }
}