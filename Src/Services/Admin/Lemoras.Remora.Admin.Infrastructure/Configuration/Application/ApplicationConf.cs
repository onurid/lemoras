using Lemoras.Remora.Admin.Domain.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lemoras.Remora.Infrastructure.Configuration
{
    internal class ApplicationConf : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.ToTable("application");

            builder.HasKey(b => b.Id);

            builder.Property(e => e.Id).HasColumnName("application_id");
            builder.Property(e => e.ApplicationTypeId).HasColumnName("application_type_id");
            builder.Property(e => e.ApplicationName).HasColumnName("application_name");
            builder.Property(e => e.ApplicationJS).HasColumnName("application_js");

            builder.HasOne(e => e.ApplicationType)
            .WithMany(e => e.Applications)
            .HasForeignKey(e => e.ApplicationTypeId);

            builder.HasMany(e => e.ApplicationInstances)
            .WithOne(e => e.Application)
            .HasForeignKey(e => e.ApplicationId);
        }
    }
}
