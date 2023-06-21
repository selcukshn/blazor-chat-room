using Blazor.Services.Authentication;
using Blazor.Services.Request.Auth;
using Blazor.Services.Request.Room;
using Microsoft.AspNetCore.Components.Authorization;

namespace Blazor.Services
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection service)
        {
            service.AddTransient<IRoomRequestService, RoomRequestService>();
            service.AddTransient<IAuthRequestService, AuthRequestService>();
            service.AddScoped<AuthenticationStateProvider, AuthenticationService>();
            return service;
        }
    }
}