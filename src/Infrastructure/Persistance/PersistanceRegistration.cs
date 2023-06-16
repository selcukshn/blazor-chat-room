using Application.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;
using Persistance.Repository;

namespace Persistance
{
    public static class PersistanceRegistration
    {
        public static IServiceCollection PersistanceRegister(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<ChatRoomContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("SQLServer"));
            });

            service.AddScoped<IRoomRepository, RoomRepository>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IMessageRepository, MessageRepository>();
            service.AddScoped<IRoomUserRepository, RoomUserRepository>();

            return service;
        }
    }
}