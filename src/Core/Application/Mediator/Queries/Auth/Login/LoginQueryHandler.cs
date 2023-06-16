using Application.Mediator.Base;
using Application.Repository;
using Application.Services;
using AutoMapper;

namespace Application.Mediator.Queries.Auth.Login
{
    public class LoginQueryHandler : GenericHandler<IUserRepository, LoginQuery, bool>
    {
        public LoginQueryHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper) { }

        public override async Task<bool> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await base.Repository.GetOneAsync(e => e.Password == PasswordService.ToPassword(request.Password) && e.Email == request.Email);
            if (user == null)
                throw new Exception("Bu e-posta adresi ve şifre ile eşleşen bir kullanıcı yok");

            return true;
        }
    }
}