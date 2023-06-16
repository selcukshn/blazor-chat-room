using MediatR;

namespace Application.Mediator.Queries.Room.GetRooms
{
    public class GetRoomsQuery : IRequest<List<GetRoomsViewModel>>
    {
        public Guid? UserId { get; set; }
        private int take = 20;
        public int Take
        {
            get => take;
            set
            {
                if (value > 0)
                    take = value;
            }
        }

        private int skip;
        public int Skip
        {
            get => skip; set
            {
                if (value > 0)
                    skip = value;
            }
        }
    }
}