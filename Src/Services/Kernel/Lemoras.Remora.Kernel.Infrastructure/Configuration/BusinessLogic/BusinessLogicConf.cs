using Lemoras.Remora.Kernel.Domain.BusinessLogic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lemoras.Remora.Infrastructure.Configuration
{
    internal class BusinessLogicConf : IEntityTypeConfiguration<BusinessLogic>
    {
        public void Configure(EntityTypeBuilder<BusinessLogic> builder)
        {
            builder.ToTable("business_logic");

            builder.HasKey(b => b.Id);

            builder.Property(e => e.Id).HasColumnName("business_logic_id");
            builder.Property(e => e.BusinessServiceId).HasColumnName("business_service_id");
            builder.Property(e => e.BusinessLogicName).HasColumnName("business_logic_name");
            builder.Property(e => e.UniqueKey).HasColumnName("unique_key");

            builder.HasOne(e=> e.BusinessService)
            .WithMany(e=> e.BusinessLogics)
            .HasForeignKey(e=> e.BusinessServiceId);
        }
    }
}