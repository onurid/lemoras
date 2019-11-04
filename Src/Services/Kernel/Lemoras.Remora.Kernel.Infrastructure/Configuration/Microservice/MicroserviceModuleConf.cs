using Lemoras.Remora.Kernel.Domain.Microservice;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lemoras.Remora.Infrastructure.Configuration
{
    internal class MicroserviceModuleConf : IEntityTypeConfiguration<MicroserviceModule>
    {
        public void Configure(EntityTypeBuilder<MicroserviceModule> builder)
        {
            builder.ToTable("microservice_module");

            builder.HasKey(b => b.Id);

            builder.Property(e => e.Id).HasColumnName("microservice_module_id");
            builder.Property(e => e.MicroserviceId).HasColumnName("microservice_id");
            builder.Property(e => e.ModuleId).HasColumnName("module_id");

            builder.HasOne(x => x.Microservice)
                .WithMany(x => x.MicroserviceModules)
                .HasForeignKey(x => x.MicroserviceId);
        }
    }
}
