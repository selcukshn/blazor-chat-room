using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Blazor.Extensions.Blazored.LocalStorage;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace Blazor.Services.Authentication
{
    public class AuthenticationService : AuthenticationStateProvider
    {
        private readonly ILocalStorageService LocalStorage;
        private AuthenticationState UnauthorizedUser;

        public AuthenticationService(ILocalStorageService localStorage)
        {
            LocalStorage = localStorage;
            UnauthorizedUser = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await LocalStorage.GetJWTAsync();
            if (string.IsNullOrEmpty(token))
                return UnauthorizedUser;
            return GetAuthorizedUser(token);
        }

        public void NotifyLogin(string? token)
        {
            if (!string.IsNullOrEmpty(token))
                NotifyAuthenticationStateChanged(Task.FromResult(GetAuthorizedUser(token)));
        }

        public void NotifyLogout()
        {
            NotifyAuthenticationStateChanged(Task.FromResult(UnauthorizedUser));
        }
        private AuthenticationState GetAuthorizedUser(string token)
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(DecodeJWT(token).Claims, "Bearer")));
        }
        private JwtSecurityToken DecodeJWT(string token) => new JwtSecurityTokenHandler().ReadJwtToken(token);
    }
}