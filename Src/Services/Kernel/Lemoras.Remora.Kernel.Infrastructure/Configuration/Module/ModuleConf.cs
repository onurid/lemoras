using Lemoras.Remora.Kernel.Domain.Module;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lemoras.Remora.Infrastructure.Configuration
{
    internal class ModuleConf : IEntityTypeConfiguration<Module>
    {
        public void Configure(EntityTypeBuilder<Module> builder)
        {
            builder.ToTable("module");

            builder.HasKey(b => b.Id);

            builder.Property(e => e.Id).HasColumnName("module_id");
            builder.Property(e => e.ModuleName).HasColumnName("module_name");
        }
    }
}
