using Lemoras.Remora.Kernel.Domain.Role;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lemoras.Remora.Infrastructure.Configuration
{
    internal class RoleConf : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("role");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("role_id");

            builder.Property(u => u.ApplicationId)
                .HasColumnName("application_id");

            builder.Property(u => u.RoleName)
                .HasColumnName("role_name");

            builder.HasMany(e=> e.RoleAuthorises)
                .WithOne(e=> e.Role);

            builder.HasMany(e=> e.RolePages)
            .WithOne(e=> e.Role)
            .HasForeignKey(e=> e.RoleId);
        }
    }
}
