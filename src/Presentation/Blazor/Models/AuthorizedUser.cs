using Application.Mediator.Queries.Auth.Login;

namespace Blazor.Models
{
    public class AuthorizedUser
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public AuthorizedUser() { }
        public AuthorizedUser(LoginViewModel model)
        {
            Id = model.Id;
            Username = model.Username;
            Email = model.Email;
        }
        public AuthorizedUser(Guid id, string username, string email)
        {
            Id = id;
            Username = username;
            Email = email;
        }
    }
}