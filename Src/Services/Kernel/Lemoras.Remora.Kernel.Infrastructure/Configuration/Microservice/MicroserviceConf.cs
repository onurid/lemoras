using Lemoras.Remora.Kernel.Domain.Microservice;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lemoras.Remora.Infrastructure.Configuration
{
    internal class MicroserviceConf : IEntityTypeConfiguration<Microservice>
    {
        public void Configure(EntityTypeBuilder<Microservice> builder)
        {
            builder.ToTable("microservice");

            builder.HasKey(b => b.Id);

            builder.Property(e => e.Id).HasColumnName("microservice_id");
            builder.Property(e => e.UniqueKey).HasColumnType("Binary(36)").HasColumnName("unique_key");
            builder.Property(e => e.MicroserviceName).HasColumnName("microservice_name");

            builder.HasMany(x => x.MicroserviceModules)
                .WithOne(x => x.Microservice)
                .HasForeignKey(x => x.MicroserviceId);
        }
    }
}
