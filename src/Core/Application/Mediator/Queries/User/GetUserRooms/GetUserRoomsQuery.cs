using MediatR;

namespace Application.Mediator.Queries.User.GetUserRooms
{
    public class GetUserRoomsQuery : IRequest<List<GetUserRoomsViewModel>>
    {
        public Guid? UserId { get; set; }
    }
}