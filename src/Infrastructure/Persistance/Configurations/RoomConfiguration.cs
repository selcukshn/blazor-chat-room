using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Configurations.Base;

namespace Persistance.Configurations
{
    public class RoomConfiguration : BaseConfiguration<Room>
    {
        public override void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.Property(e => e.Title).IsRequired().HasMaxLength(60);
            builder.Property(e => e.Description).IsRequired().HasMaxLength(200);
            builder.Property(e => e.CreatedDate).HasDefaultValueSql("getdate()");

            builder.HasOne(e => e.User).WithMany(e => e.Rooms).HasForeignKey(e => e.UserId);
        }
    }
}