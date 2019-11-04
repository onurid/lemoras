using Lemoras.Remora.Kernel.Domain.Menu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lemoras.Remora.Infrastructure.Configuration
{
    internal class MenuIconConf : IEntityTypeConfiguration<MenuIcon>
    {
        public void Configure(EntityTypeBuilder<MenuIcon> builder)
        {
            builder.ToTable("menu_icon");

            builder.HasKey(b => b.Id);

            builder.Property(e => e.Id).HasColumnName("menu_icon_id");
            builder.Property(e => e.TemplateId).HasColumnName("template_id");
            builder.Property(e => e.MenuIconValue).HasColumnName("menu_icon_value");

            builder.HasMany(e=> e.Menus)
            .WithOne(e=> e.MenuIcon)
            .HasForeignKey(e=> e.MenuIconId);
        }
    }
}