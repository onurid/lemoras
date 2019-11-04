using Lemoras.Remora.Kernel.Domain.Company;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lemoras.Remora.Infrastructure.Configuration
{
    internal class CompanyConf : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("company");

            builder.HasKey(b => b.Id);

            builder.Property(e => e.Id).HasColumnName("company_id");
            builder.Property(e => e.CompanyName).HasColumnName("company_name");
        }
    }
}
