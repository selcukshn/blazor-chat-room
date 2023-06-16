using Application.Extensions;
using Application.Mediator.Base;
using Application.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Mediator.Queries.User.GetUserRooms
{
    public class GetUserRoomsQueryHandler : GenericHandler<IUserRoomRepository, GetUserRoomsQuery, List<GetUserRoomsViewModel>>
    {
        public GetUserRoomsQueryHandler(IUserRoomRepository repository, IMapper mapper) : base(repository, mapper) { }

        public override async Task<List<GetUserRoomsViewModel>> Handle(GetUserRoomsQuery request, CancellationToken cancellationToken)
        {
            if (request.UserId.NullOrEmpty())
                throw new Exception("Kullanıcı id mevcut değil");

            var rooms = await base.Repository.AsQueryable()
            .Include(e => e.Room)
            .Where(e => e.UserId == request.UserId)
            .ToListAsync();

            return rooms.Select(e => new GetUserRoomsViewModel(e.Room)).ToList();
        }
    }
}