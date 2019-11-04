using Lemoras.Remora.Roomshare.Domain.Models.RentContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lemoras.Remora.Roomshare.Infrastructure.Configuration
{
    internal class HouseConf : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
            builder.HasOne(e => e.Rooms).WithMany();
            builder.HasOne(e => e.HouseImages).WithMany();
        }
    }
}
