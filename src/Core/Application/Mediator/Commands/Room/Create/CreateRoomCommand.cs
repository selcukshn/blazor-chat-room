using MediatR;

namespace Application.Mediator.Commands.Room.Create
{
    public class CreateRoomCommand : IRequest<bool>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public Guid UserId { get; set; }
    }
}