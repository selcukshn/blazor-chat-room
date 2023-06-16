using System.Reflection;
using Application.Services;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection ApplicationRegister(this IServiceCollection service)
        {
            var assembly = Assembly.GetExecutingAssembly();
            service
                .AddMediatR(assembly)
                .AddAutoMapper(assembly)
                .AddValidatorsFromAssembly(assembly)
                .AddScoped<JWTService>();
            return service;
        }
    }
}