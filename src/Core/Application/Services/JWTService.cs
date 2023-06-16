using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Application.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Application.Services
{
    public class JWTService
    {
        private readonly IConfiguration Configuration;
        private string JWTKey => Configuration["JWT:Key"];
        private string JWTIssuer => Configuration["JWT:Key"];
        private string JWTAudience => Configuration["JWT:Key"];
        private string JWTDay => Configuration["JWT:ValidDay"];
        public JWTService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string GenerateToken(JWTClaimsModel model)
        {
            try
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTKey));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expiry = DateTime.Now.AddDays(Convert.ToDouble(JWTDay));
                var token = new JwtSecurityToken(JWTIssuer, JWTAudience, model.ToClaimsArray(), null, expiry, credentials);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception exception)
            {
                return JsonConvert.SerializeObject(exception);
            }
        }
    }
}