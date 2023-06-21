using Application.Extensions;
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
            get => skip;
            set
            {
                if (value > 0)
                    skip = value;
            }
        }
        public override string ToString()
        {
            string query = $"?take={this.take}&skip={this.skip}";
            if (UserId.NotNullAndEmpty())
                query += $"&userId={this.UserId}";
            return query;
        }
    }
}