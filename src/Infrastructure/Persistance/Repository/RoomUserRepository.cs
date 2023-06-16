using Application.Repository;
using Domain;
using Persistance.Context;
using Persistance.Repository.Base;

namespace Persistance.Repository
{
    public class RoomUserRepository : Repository<RoomUser>, IRoomUserRepository
    {
        public RoomUserRepository(ChatRoomContext context) : base(context) { }
    }
}