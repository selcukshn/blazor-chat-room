using MediatR;

namespace Application.Mediator.Commands.Auth.Register
{
    public class RegisterCommand : IRequest<bool>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }
}