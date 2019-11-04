using Lemoras.Remora.Roomshare.Domain.Models.RentContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lemoras.Remora.Roomshare.Infrastructure.Configuration
{
    internal class RoomConf : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasOne(e => e.RoomImages).WithMany();
        }
    }
}
