using Lemoras.Remora.Kernel.Domain.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lemoras.Remora.Infrastructure.Configuration
{
    internal class ApplicationInstanceConf : IEntityTypeConfiguration<ApplicationInstance>
    {
        public void Configure(EntityTypeBuilder<ApplicationInstance> builder)
        {
            builder.ToTable("application_instance");

            builder.HasKey(b => b.Id);

            builder.Property(e => e.Id).HasColumnName("application_instance_id");
            builder.Property(e => e.ApplicationId).HasColumnName("application_id");
            builder.Property(e => e.CompanyId).HasColumnName("company_id");
            builder.Property(e => e.TemplateId).HasColumnName("template_id");
            builder.Property(e => e.ApplicationTagName).HasColumnName("application_tag_name");
            builder.Property(e => e.DatabaseName).HasColumnName("database_name");
            builder.Property(e => e.ConnectionString).HasColumnName("connection_string");

            builder.HasOne(e => e.Application)
            .WithMany(e => e.ApplicationInstances)
            .HasForeignKey(e => e.ApplicationId);
        }
    }
}
