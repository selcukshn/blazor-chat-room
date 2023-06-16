using System.Reflection;
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
                .AddValidatorsFromAssembly(assembly);
            return service;
        }
    }
}