using Application.Mediator.Base;
using Application.Models;
using Application.Repository;
using Application.Services;
using AutoMapper;

namespace Application.Mediator.Queries.Auth.Login
{
    public class LoginQueryHandler : GenericHandler<IUserRepository, LoginQuery, LoginViewModel>
    {
        private readonly JWTService JWTService;
        public LoginQueryHandler(IUserRepository repository, IMapper mapper, JWTService jwtService) : base(repository, mapper)
        {
            JWTService = jwtService;
        }

        public override async Task<LoginViewModel> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await base.Repository.GetOneAsync(e => e.Password == PasswordService.ToPassword(request.Password) && e.Email == request.Email);
            if (user == null)
                throw new Exception("Bu e-posta adresi ve şifre ile eşleşen bir kullanıcı yok");

            return new LoginViewModel()
            {
                Token = JWTService.GenerateToken(new JWTClaimsModel(user))
            };
        }
    }
}