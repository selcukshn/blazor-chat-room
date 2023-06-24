using Application.Mediator.Base;
using Application.Repository;
using AutoMapper;

namespace Application.Mediator.Commands.Room.Create
{
    public class CreateRoomCommandHandler : GenericHandler<IRoomRepository, CreateRoomCommand, bool>
    {
        private readonly IUserRepository UserRepository;
        private readonly IUserRoomRepository UserRoomRepository;
        public CreateRoomCommandHandler(IRoomRepository repository, IMapper mapper, IUserRepository userRepository = null, IUserRoomRepository userRoomRepository = null) : base(repository, mapper)
        {
            UserRepository = userRepository;
            UserRoomRepository = userRoomRepository;
        }

        public override async Task<bool> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var haveUser = await UserRepository.HaveAsync(e => e.Id == request.UserId);
            if (!haveUser)
                throw new Exception("Kullanıcı bulunamadı");

            var newRoom = new Domain.Room();
            base.Mapper.Map(request, newRoom);

            var createRoomResult = await base.Repository.CreateAsync(newRoom);
            if (createRoomResult == 0)
                throw new Exception("Oda oluşturulurken bir sorun oluştu");

            var createUserRoomResult = await UserRoomRepository.CreateAsync(new Domain.UserRoom() { RoomId = newRoom.Id, UserId = newRoom.UserId });
            if (createRoomResult == 0)
            {
                await base.Repository.DeleteAsync(newRoom.Id);
                throw new Exception("Oda oluşturulurken bir sorun oluştu");
            }

            return true;
        }
    }
}