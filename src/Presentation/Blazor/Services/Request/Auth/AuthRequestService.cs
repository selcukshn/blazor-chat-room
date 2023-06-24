using System.Net.Http.Headers;
using Application.Mediator.Commands.Auth.Register;
using Application.Mediator.Queries.Auth.Login;
using Blazor.Extensions.Blazored.LocalStorage;
using Blazor.Models;
using Blazor.Services.Request.Base;
using Blazored.LocalStorage;
using Common.Response;
using Microsoft.AspNetCore.Components.Authorization;

namespace Blazor.Services.Request.Auth
{
    public class AuthRequestService : BaseRequest, IAuthRequestService
    {
        public ILocalStorageService LocalStorage { get; set; }
        public AuthRequestService(HttpClient client, AuthenticationStateProvider authenticationState, ILocalStorageService localStorage) : base(client, authenticationState)
        {
            LocalStorage = localStorage;
        }

        public async Task<RequestResponseData<LoginViewModel>> LoginAsync(LoginQuery query)
        {
            var response = await base.PostAsync<LoginViewModel>("/api/auth/login", query);
            if (response.IsSuccess && !string.IsNullOrEmpty(response.Model?.Token))
            {
                await LocalStorage.SetJWTAsync(response.Model.Token);
                await LocalStorage.SetAuthorizedUserAsync(new AuthorizedUser(response.Model));
                base.AuthenticationStateProvider.NotifyLogin(response.Model.Token);
                base.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", response.Model.Token);
            }
            return response;
        }
        public async Task<RequestResponseData<bool>> RegisterAsync(RegisterCommand command)
        {
            return await base.PostAsync<bool>("/api/auth/register", command);
        }
        public async Task LogoutAsync()
        {
            await LocalStorage.RemoveJWTAsync();
            await LocalStorage.RemoveAuthorizedUserAsync();
            base.AuthenticationStateProvider.NotifyLogout();
            base.Client.DefaultRequestHeaders.Authorization = null;
        }
    }
}