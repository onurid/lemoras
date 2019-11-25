using Lemoras.Remora.Admin.Domain.Role;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lemoras.Remora.Infrastructure.Configuration
{
    internal class RolePageConf : IEntityTypeConfiguration<RolePage>
    {
        public void Configure(EntityTypeBuilder<RolePage> builder)
        {
           builder.ToTable("role_page");

           builder.HasKey(ur => ur.Id);

           builder.Property(u => u.Id).HasColumnName("role_page_id");

			builder.Property(u => u.ModulePageId).HasColumnName("module_page_id");

            builder.HasOne(e=> e.Role)
            .WithMany(e=> e.RolePages)
            .HasForeignKey(e=> e.RoleId);
        }
    }
}
