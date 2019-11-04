using Lemoras.Remora.Kernel.Domain.Language;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lemoras.Remora.Infrastructure.Configuration
{
    internal class LanguageConf : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("language");

            builder.HasKey(b => b.Id);

            builder.Property(e => e.Id).HasColumnName("language_id");
            builder.Property(e => e.LanguageName).HasColumnName("language_name");
        }
    }
}