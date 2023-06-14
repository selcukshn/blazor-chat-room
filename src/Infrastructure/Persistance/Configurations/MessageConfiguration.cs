using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Configurations.Base;

namespace Persistance.Configurations
{
    public class MessageConfiguration : BaseConfiguration<Message>
    {
        public override void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.Property(e => e.Text).IsRequired().HasMaxLength(200);
            builder.Property(e => e.MessageDate).HasDefaultValueSql("getdate()");

            builder.HasOne(e => e.User).WithMany(e => e.Messages).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Room).WithMany(e => e.Messages).HasForeignKey(e => e.RoomId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}