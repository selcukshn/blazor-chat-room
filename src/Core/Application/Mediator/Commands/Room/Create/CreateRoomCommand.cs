using MediatR;

namespace Application.Mediator.Commands.Room.Create
{
    public class CreateRoomCommand : IRequest<bool>
    {
        public string Title { get; set; }
        public string Description { get; set; }

        private bool _isPublic = true;
        public bool IsPublic
        {
            get => _isPublic;
            set
            {
                _isPublic = Convert.ToBoolean(value);
            }
        }
        public Guid UserId { get; set; }
    }
}