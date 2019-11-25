using Lemoras.Remora.Admin.Domain.Menu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lemoras.Remora.Infrastructure.Configuration
{
    internal class MenuConf : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("menu");

            builder.HasKey(b => b.Id);

            builder.Property(e => e.Id).HasColumnName("menu_id");
            builder.Property(e => e.MenuTypeId).HasColumnName("menu_type_id");
            builder.Property(e => e.ParentMenuId).HasColumnName("parent_menu_id");
            builder.Property(e => e.PageId).HasColumnName("page_id");
            builder.Property(e => e.MenuIconId).HasColumnName("menu_icon_id");
            builder.Property(e => e.MenuValueId).HasColumnName("menu_value_id");
            builder.Property(e => e.Index).HasColumnName("index");
            builder.Property(e => e.Label).HasColumnName("menu_label");
            builder.Property(e => e.Tag).HasColumnName("menu_tag");

            builder.HasOne(e=> e.MenuIcon)
            .WithMany(e=> e.Menus)
            .HasForeignKey(e=> e.MenuIconId);

            builder.HasOne(e=> e.MenuType)
            .WithMany(e=> e.Menus)
            .HasForeignKey(e=> e.MenuTypeId);

            builder.HasOne(e=> e.MenuValue)
            .WithMany(e=> e.Menus)
            .HasForeignKey(e=> e.MenuValueId);

        }
    }
}