using Lemoras.Remora.Kernel.Domain.Page;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lemoras.Remora.Infrastructure.Configuration
{
    internal class PageDetailConf : IEntityTypeConfiguration<PageDetail>
    {
        public void Configure(EntityTypeBuilder<PageDetail> builder)
        {
            builder.ToTable("page_detail");

            builder.HasKey(b => b.Id);

            builder.Property(e => e.Id).HasColumnName("page_detail_id");
            builder.Property(e => e.PageId).HasColumnName("page_id");
            builder.Property(e => e.LanguageId).HasColumnName("language_id");

            builder.HasOne(e=> e.Page)
            .WithMany(e=> e.PageDetails)
            .HasForeignKey(e=> e.PageId);
        }
    }
}
