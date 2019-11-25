using Lemoras.Remora.Core.Models.KernelContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lemoras.Remora.Infrastructure.Configuration
{
    internal class RoleAuthoriseConf : IEntityTypeConfiguration<RoleAuthorise>
    {
        public void Configure(EntityTypeBuilder<RoleAuthorise> builder)
        {
           builder.ToTable("role_authorise");

           builder.HasKey(ur => ur.Id);

           builder.Property(u => u.Id).HasColumnName("role_authorise_id");

			builder.Property(u => u.RoleId).HasColumnName("role_id");

			builder.Property(u => u.CommandId).HasColumnName("command_id");
        }
    }
}
