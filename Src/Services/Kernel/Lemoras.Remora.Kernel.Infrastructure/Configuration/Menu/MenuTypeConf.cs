using Lemoras.Remora.Kernel.Domain.Menu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lemoras.Remora.Infrastructure.Configuration
{
    internal class MenuTypeConf : IEntityTypeConfiguration<MenuType>
    {
        public void Configure(EntityTypeBuilder<MenuType> builder)
        {
            builder.ToTable("menu_type");

            builder.HasKey(b => b.Id);

            builder.Property(e => e.Id).HasColumnName("menu_type_id");
            builder.Property(e => e.ApplicationId).HasColumnName("application_id");
            builder.Property(e => e.MenuTypeName).HasColumnName("menu_type_name");

            builder.HasMany(e=> e.Menus)
            .WithOne(e=> e.MenuType)
            .HasForeignKey(e=> e.MenuTypeId);
        }
    }
}