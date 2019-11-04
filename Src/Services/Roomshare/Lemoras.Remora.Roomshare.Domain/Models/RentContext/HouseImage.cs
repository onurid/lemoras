using Lemoras.Remora.Roomshare.Domain.Interfaces;
using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Roomshare.Domain.Models.RentContext
{
    public class HouseImage : Entity<int>, IAdvertModelKey
    {
        public HouseImage(int houseId, string imageUrl)
        {
            this.HouseId = houseId;
            this.ImageUrl = imageUrl;
        }

        public string ImageUrl { get; protected set; }
        public int HouseId { get; protected set; }

        public void EditImageUrl(string imageUrl)
        {
            this.ImageUrl = imageUrl;
        }
    }
}
