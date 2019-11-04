using Lemoras.Remora.Kernel.Domain.Command;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lemoras.Remora.Infrastructure.Configuration
{
    internal class CommandConf : IEntityTypeConfiguration<Command>
    {
        public void Configure(EntityTypeBuilder<Command> builder)
        {
            builder.ToTable("command");

            builder.HasKey(b => b.Id);

            builder.Property(e => e.Id).HasColumnName("command_id");
            builder.Property(e => e.BusinessServiceId).HasColumnName("business_service_id");
            builder.Property(e => e.CommandName).HasColumnName("command_name");
        }
    }
}
