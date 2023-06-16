using Application.Repository;
using Domain;
using Persistance.Context;
using Persistance.Repository.Base;

namespace Persistance.Repository
{
    public class UserRoomRepository : Repository<UserRoom>, IUserRoomRepository
    {
        public UserRoomRepository(ChatRoomContext context) : base(context) { }
    }
}