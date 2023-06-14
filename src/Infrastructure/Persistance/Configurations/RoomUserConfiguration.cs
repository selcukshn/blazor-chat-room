using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Configurations.Base;

namespace Persistance.Configurations
{
    public class RoomUserConfiguration : BaseConfiguration<RoomUser>
    {
        public override void Configure(EntityTypeBuilder<RoomUser> builder)
        {
            builder.HasOne(e => e.User).WithMany(e => e.RoomUsers).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Room).WithMany(e => e.RoomUsers).HasForeignKey(e => e.RoomId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}