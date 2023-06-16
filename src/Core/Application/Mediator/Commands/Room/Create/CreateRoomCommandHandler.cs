using Application.Mediator.Base;
using Application.Repository;
using AutoMapper;

namespace Application.Mediator.Commands.Room.Create
{
    public class CreateRoomCommandHandler : GenericHandler<IRoomRepository, CreateRoomCommand, bool>
    {
        public CreateRoomCommandHandler(IRoomRepository repository, IMapper mapper) : base(repository, mapper) { }

        public override async Task<bool> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            return await base.Repository.CreateAsync(base.Mapper.Map<Domain.Room>(request)) > 0;
        }
    }
}