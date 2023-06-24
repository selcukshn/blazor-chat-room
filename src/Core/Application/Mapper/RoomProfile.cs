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
        }
    }
}