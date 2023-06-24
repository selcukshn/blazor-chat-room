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
            .Take(request.Take);

            if (request.UserId.NotNullAndEmpty())
                roomsQuery = roomsQuery.Where(e => e.IsPublic || (!e.IsPublic && e.UserRooms.Any(r => r.UserId == request.UserId)));
            else
                roomsQuery = roomsQuery.Where(e => e.IsPublic);

            var rooms = await roomsQuery.ToListAsync();

            return rooms.Select(e => new GetRoomsViewModel()
            {
                AlreadyJoined = request.UserId.NotNullAndEmpty() ? e.UserRooms.Any(a => a.UserId == request.UserId) : false,
                CreatedDate = e.CreatedDate,
                Description = e.Description,
                Id = e.Id,
                IsPublic = e.IsPublic,
                Title = e.Title,
                UserCount = e.UserRooms.Count,
                Username = e.User.Username
            }).ToList();
        }
    }
}