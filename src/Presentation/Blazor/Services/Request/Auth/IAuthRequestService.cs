using Application.Mediator.Commands.Auth.Register;
using Application.Mediator.Queries.Auth.Login;
using Common.Response;

namespace Blazor.Services.Request.Auth
{
    public interface IAuthRequestService
    {
        Task<RequestResponseData<LoginViewModel>> LoginAsync(LoginQuery query);
        Task<RequestResponseData<bool>> RegisterAsync(RegisterCommand command);
        Task LogoutAsync();
    }
}