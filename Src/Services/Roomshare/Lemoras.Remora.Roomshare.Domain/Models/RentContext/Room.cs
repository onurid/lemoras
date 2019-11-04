using System.Collections.Generic;
using Lemoras.Remora.Roomshare.Domain.Interfaces;
using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Roomshare.Domain.Models.RentContext
{
    public class Room : Entity<int>, IAdvertModelKey
    {
        private readonly List<RoomImage> _roomImages;

        public Room(
            int houseId, 
            string title, 
            string description, 
            Enums.RoomType roomType,
            Enums.LeaseType leaseType,
            decimal rentalFee)
        {
            this.HouseId = houseId;
            this.Title = title;
            this.Description = description;
            this.RoomType = roomType;
            this.LeaseType = leaseType;
            this.RentalFee = rentalFee;

            _roomImages = new List<RoomImage>();
        }
        
        public int HouseId { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public Enums.RoomType RoomType { get; protected set; }
        public Enums.LeaseType LeaseType { get; protected set; }
        public decimal RentalFee { get; protected set; }

        public IReadOnlyCollection<RoomImage> RoomImages => _roomImages;

        public RoomImage AddRoomImage(string imageUrl)
        {
            var image = new RoomImage(this.Id, imageUrl);
            _roomImages.Add(image);
            return image;
        }
    }
}
