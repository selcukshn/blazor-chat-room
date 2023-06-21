using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Blazor.Extensions.Blazored.LocalStorage;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace Blazor.Services.Authentication
{
    public class AuthenticationService : AuthenticationStateProvider
    {
        private readonly ILogger<AuthenticationService> Logger;
        private readonly ILocalStorageService LocalStorage;
        private AuthenticationState UnauthorizedUser;

        public AuthenticationService(ILocalStorageService localStorage, ILogger<AuthenticationService> logger)
        {
            LocalStorage = localStorage;
            UnauthorizedUser = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            Logger = logger;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await LocalStorage.GetJWTAsync();
            if (string.IsNullOrEmpty(token))
            {
                Logger.LogInformation("AuthenticationService.GetAuthenticationStateAsync: Token not founded");
                return UnauthorizedUser;
            }
            Logger.LogInformation("AuthenticationService.GetAuthenticationStateAsync: Token founded. Authorized user created");
            return GetAuthorizedUser(token);
        }

        public void NotifyLogin(string? token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                Logger.LogInformation("AuthenticationService.NotifyLogin: Token founded. User logged in");
                NotifyAuthenticationStateChanged(Task.FromResult(GetAuthorizedUser(token)));
            }
            else
                Logger.LogInformation("AuthenticationService.NotifyLogin: Token not founded");

        }

        public void NotifyLogout()
        {
            Logger.LogInformation("AuthenticationService.NotifyLogout: User logged out");
            NotifyAuthenticationStateChanged(Task.FromResult(UnauthorizedUser));
        }
        private AuthenticationState GetAuthorizedUser(string token)
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(DecodeJWT(token).Claims, "Bearer")));
        }
        private JwtSecurityToken DecodeJWT(string token) => new JwtSecurityTokenHandler().ReadJwtToken(token);
    }
}