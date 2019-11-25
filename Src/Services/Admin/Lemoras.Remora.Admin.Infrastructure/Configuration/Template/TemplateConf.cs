using Lemoras.Remora.Admin.Domain.Template;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lemoras.Remora.Infrastructure.Configuration
{
    internal class TemplateConf : IEntityTypeConfiguration<Template>
    {
        public void Configure(EntityTypeBuilder<Template> builder)
        {
            builder.ToTable("template");

            builder.HasKey(b => b.Id);

            builder.Property(e => e.Id).HasColumnName("template_id");
            builder.Property(e => e.TemplateName).HasColumnName("template_name");
            builder.Property(e => e.TemplateUrl).HasColumnName("template_url");
        }
    }
}
