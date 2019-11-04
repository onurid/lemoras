using Lemoras.Remora.Kernel.Domain.Page;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lemoras.Remora.Infrastructure.Configuration
{
    internal class PageConf : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.ToTable("page");

            builder.HasKey(b => b.Id);

            builder.Property(e => e.Id).HasColumnName("page_id");
            builder.Property(e => e.TemplateId).HasColumnName("template_id");
            builder.Property(e => e.RouteName).HasColumnName("route_name");
            builder.Property(e => e.TemplateUrl).HasColumnName("template_url");
            builder.Property(e => e.ControllerUrl).HasColumnName("controller_url");
            builder.Property(e => e.ControllerName).HasColumnName("controller_name");
            builder.Property(e => e.ControllerAsName).HasColumnName("controller_as_name");

            builder.HasMany(e=> e.PageDetails)
            .WithOne(e=> e.Page)
            .HasForeignKey(e=> e.PageId);
        }
    }
}
