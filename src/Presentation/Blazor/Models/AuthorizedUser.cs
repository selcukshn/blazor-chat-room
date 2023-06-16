namespace Blazor.Models
{
    public class AuthorizedUser
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public AuthorizedUser() { }
        public AuthorizedUser(Guid id, string username, string email)
        {
            Id = id;
            Username = username;
            Email = email;
        }
    }
}