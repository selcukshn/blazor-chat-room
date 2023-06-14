using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Configurations.Base;

namespace Persistance.Configurations
{
    public class UserConfiguration : BaseConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Email).IsRequired().HasMaxLength(200);
            builder.Property(e => e.Username).IsRequired().HasMaxLength(200);
            builder.Property(e => e.Password).IsRequired().HasMaxLength(512);
            builder.Property(e => e.RegisterDate).HasDefaultValueSql("getdate()");
        }
    }
}