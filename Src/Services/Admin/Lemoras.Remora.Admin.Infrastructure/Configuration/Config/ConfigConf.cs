using Lemoras.Remora.Admin.Domain.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lemoras.Remora.Infrastructure.Configuration
{
    internal class ConfigConf : IEntityTypeConfiguration<CrunchConfig>
    {
        public void Configure(EntityTypeBuilder<CrunchConfig> builder)
        {
            builder.ToTable("config");

            builder.HasKey(b => b.Id);

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Data).HasColumnName("data");
        }
    }
}
