using Lemoras.Remora.Kernel.Domain.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lemoras.Remora.Infrastructure.Configuration
{
    internal class ApplicationTypeConf : IEntityTypeConfiguration<ApplicationType>
    {
        public void Configure(EntityTypeBuilder<ApplicationType> builder)
        {
            builder.ToTable("application_type");

            builder.HasKey(b => b.Id);

            builder.Property(e => e.Id).HasColumnName("application_type_id");
            builder.Property(e => e.ApplicationTypeName).HasColumnName("application_type_name");
            builder.Property(e => e.IsBackOffice).HasColumnName("isbackoffice");

            builder.HasMany(e => e.Applications)
                .WithOne(e => e.ApplicationType);
        }
    }
}

