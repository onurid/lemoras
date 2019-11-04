using Lemoras.Remora.Kernel.Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lemoras.Remora.Infrastructure.Configuration
{
    internal class UserRoleConf : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("user_role");

           builder.HasKey(ur => ur.Id);

           builder.Property(u => u.Id).HasColumnName("user_role_id");

			builder.Property(u => u.UserId).HasColumnName("user_id");

			builder.Property(u => u.ApplicationInstanceId).HasColumnName("application_instance_id");

			builder.Property(u => u.RoleId).HasColumnName("role_id");

			builder.HasOne(bd => bd.User)
                .WithMany(b => b.UserRoles)
                .HasForeignKey(b => b.UserId);
        }
    }
}
