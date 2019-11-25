using Lemoras.Remora.Admin.Domain.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lemoras.Remora.Infrastructure.Configuration
{
    internal class ModulePageConf : IEntityTypeConfiguration<ModulePage>
    {
        public void Configure(EntityTypeBuilder<ModulePage> builder)
        {
            builder.ToTable("module_page");

            builder.HasKey(b => b.Id);

            builder.Property(e => e.Id).HasColumnName("module_page_id");
            builder.Property(e => e.ApplicationInstanceId).HasColumnName("application_instance_id");
            builder.Property(e => e.ApplicationModuleId).HasColumnName("application_module_id");
            builder.Property(e => e.PageId).HasColumnName("page_id");
        }
    }
}
