using Lemoras.Remora.Kernel.Domain.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lemoras.Remora.Infrastructure.Configuration
{
    internal class ApplicationModuleConf : IEntityTypeConfiguration<ApplicationModule>
    {
        public void Configure(EntityTypeBuilder<ApplicationModule> builder)
        {
            builder.ToTable("application_module");

            builder.HasKey(b => b.Id);

            builder.Property(e => e.Id).HasColumnName("application_module_id");
            builder.Property(e => e.ApplicationId).HasColumnName("application_id");
            builder.Property(e => e.ModuleId).HasColumnName("module_id");
            builder.Property(e => e.BusinessLogicId).HasColumnName("business_logic_id");

            builder.HasOne(e => e.Application)
            .WithMany(e => e.ApplicationModules)
            .HasForeignKey(e => e.ApplicationId);
        }
    }
}
