using MediatR;

namespace Application.Mediator.Queries.Auth.Login
{
    public class LoginQuery : IRequest<LoginViewModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}