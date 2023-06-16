using Application.Mediator.Commands.Room.Create;
using Application.Mediator.Queries.Room.GetRooms;
using AutoMapper;
using Domain;

namespace Application.Mapper
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<CreateRoomCommand, Room>();

            CreateMap<Room, GetRoomsViewModel>()
            .ForMember(e => e.Username, e => e.MapFrom(f => f.User.Username))
            .ForMember(e => e.UserCount, e => e.MapFrom(f => f.UserRooms.Count));
        }
    }
}