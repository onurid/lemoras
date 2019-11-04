using Lemoras.Remora.Roomshare.Domain.Interfaces;
using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Roomshare.Domain.Models.RentContext
{
    public class RoomImage : Entity<int>, IAdvertModelKey
    {
        public RoomImage(int roomId, string imageUrl)
        {
            this.RoomId = roomId;
            this.ImageUrl = imageUrl;
        }

        public string ImageUrl { get; protected set; }
        public int RoomId { get; protected set; }

        public void EditImageUrl(string imageUrl)
        {
            this.ImageUrl = imageUrl;
        }
    }
}
