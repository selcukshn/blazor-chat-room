using Application.Extensions;
using Application.Mediator.Base;
using Application.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Mediator.Queries.Room.GetRooms
{
    public class GetRoomsQueryHandler : GenericHandler<IRoomRepository, GetRoomsQuery, List<GetRoomsViewModel>>
    {
        public GetRoomsQueryHandler(IRoomRepository repository, IMapper mapper) : base(repository, mapper) { }

        public override async Task<List<GetRoomsViewModel>> Handle(GetRoomsQuery request, CancellationToken cancellationToken)
        {
            var roomsQuery = base.Repository.AsQueryable()
            .Include(e => e.User)
            .Include(e => e.UserRooms)
            .Skip(request.Skip)
            .Take(request.Take)
            .Where(e => e.IsPublic);

            if (request.UserId.NotNullAndEmpty())
                roomsQuery = roomsQuery.Where(e => !e.IsPublic && e.UserRooms.Any(r => r.UserId == request.UserId));

            return base.Mapper.Map<List<GetRoomsViewModel>>(await roomsQuery.ToListAsync());
        }
    }
}