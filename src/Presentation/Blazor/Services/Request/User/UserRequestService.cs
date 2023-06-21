using Application.Mediator.Queries.Auth.Login;
using Blazor.Services.Request.Base;
using Common.Response;

namespace Blazor.Services.Request.User
{
    public class UserRequestService : BaseRequest, IUserRequestService
    {
        public UserRequestService(HttpClient client) : base(client) { }

    }
}