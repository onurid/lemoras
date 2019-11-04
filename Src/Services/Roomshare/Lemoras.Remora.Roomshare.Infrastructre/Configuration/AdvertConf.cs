using Lemoras.Remora.Roomshare.Domain.Models.RentContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lemoras.Remora.Roomshare.Infrastructure.Configuration
{
    internal class AdvertConf : IEntityTypeConfiguration<Advert>
    {
        public void Configure(EntityTypeBuilder<Advert> builder)
        {
            builder.HasOne(e => e.House).WithOne();
        }
    }
}
