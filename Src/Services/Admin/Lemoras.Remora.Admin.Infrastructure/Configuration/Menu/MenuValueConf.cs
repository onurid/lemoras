using Lemoras.Remora.Admin.Domain.Menu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lemoras.Remora.Infrastructure.Configuration
{
    internal class MenuValueConf : IEntityTypeConfiguration<MenuValue>
    {
        public void Configure(EntityTypeBuilder<MenuValue> builder)
        {
            builder.ToTable("menu_value");

            builder.HasKey(b => b.Id);

            builder.Property(e => e.Id).HasColumnName("menu_value_id");
            builder.Property(e => e.LanguageId).HasColumnName("language_id");
            builder.Property(e => e.MenuValueName).HasColumnName("menu_value_name");

            builder.HasMany(e=> e.Menus)
            .WithOne(e=> e.MenuValue)
            .HasForeignKey(e=> e.MenuValueId);
        }
    }
}