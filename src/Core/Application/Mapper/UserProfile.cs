using Application.Mediator.Commands.Auth.Register;
using Application.Services;
using AutoMapper;
using Domain;

namespace Application.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterCommand, User>()
            .ForMember(e => e.Password, e => e.MapFrom(f => PasswordService.ToPassword(f.Password)));
        }
    }
}