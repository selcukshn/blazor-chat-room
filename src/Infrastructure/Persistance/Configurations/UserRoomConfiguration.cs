using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Configurations.Base;

namespace Persistance.Configurations
{
    public class UserRoomConfiguration : BaseConfiguration<UserRoom>
    {
        public override void Configure(EntityTypeBuilder<UserRoom> builder)
        {
            builder.HasOne(e => e.User).WithMany(e => e.UserRooms).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Room).WithMany(e => e.UserRooms).HasForeignKey(e => e.RoomId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}