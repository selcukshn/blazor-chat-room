using Application.Mediator.Base;
using Application.Repository;
using AutoMapper;

namespace Application.Mediator.Commands.Auth.Register
{
    public class RegisterCommandHandler : GenericHandler<IUserRepository, RegisterCommand, bool>
    {
        public RegisterCommandHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper) { }

        public override async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var userAlreadyExist = await base.Repository.GetOneAsync(e => e.Email == request.Email || e.Username == request.Username);
            if (userAlreadyExist != null)
            {
                if (userAlreadyExist.Email == request.Email)
                    throw new Exception("Bu e-posta adresi ile daha önce kayıt olunmuş");
                else
                    throw new Exception("Bu kullanıcı adı kullanılıyor");
            }
            return await base.Repository.CreateAsync(base.Mapper.Map<Domain.User>(request)) > 0;
        }
    }
}