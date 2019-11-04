using Lemoras.Remora.Kernel.Domain.BusinessLogic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lemoras.Remora.Infrastructure.Configuration
{
    internal class BusinessServiceConf : IEntityTypeConfiguration<BusinessService>
    {
        public void Configure(EntityTypeBuilder<BusinessService> builder)
        {
            builder.ToTable("business_service");

            builder.HasKey(b => b.Id);

            builder.Property(e => e.Id).HasColumnName("business_service_id");
            builder.Property(e => e.BusinessServiceName).HasColumnName("business_service_name");
            builder.Property(e => e.BusinessServiceKey).HasColumnName("business_service_key");
            
            builder.HasMany(e=> e.BusinessLogics)
            .WithOne(e=> e.BusinessService)
            .HasForeignKey(e=> e.BusinessServiceId);
        }
    }
}