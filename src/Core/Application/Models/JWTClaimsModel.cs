using System.Security.Claims;
using Domain;

namespace Application.Models
{
    public class JWTClaimsModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public JWTClaimsModel() { }
        public JWTClaimsModel(User user)
        {
            Id = user.Id;
            Username = user.Username;
            Email = user.Email;
        }
        public JWTClaimsModel(Guid id, string username, string email)
        {
            Id = id;
            Username = username;
            Email = email;
        }

        public IEnumerable<Claim> ToClaimsArray()
        {
            return new Claim[]{
                new Claim("Id", Id.ToString()),
                new Claim("Username", Username),
                new Claim("Email", Email)
            };
        }
    }
}