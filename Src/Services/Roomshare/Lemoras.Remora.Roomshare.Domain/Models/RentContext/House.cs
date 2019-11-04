using System.Collections.Generic;
using Lemoras.Remora.Roomshare.Domain.Interfaces;
using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Roomshare.Domain.Models.RentContext
{
    public class House : Entity<int>, IAdvertModelKey
    {
        private readonly List<Room> _rooms;
        private readonly List<HouseImage> _houseImages;

        public House()
        {
            _rooms = new List<Room>();
            _houseImages = new List<HouseImage>();
        }

        public House(
            string title, 
            string description, 
            string address,
            int countryId,
            int cityId,
            int districtId,
            Enums.HouseType houseType)
        {
            this.Title = title;
            this.Description = description;
            this.Address = address;
            this.CountryId = countryId;
            this.CityId = cityId;
            this.DistrictId = districtId;
            this.HouseType = houseType;
        }

        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public string Address { get; protected set; }
        public int CountryId { get; protected set; }
        public int CityId { get; protected set; }
        public int DistrictId { get; protected set; }
        public Enums.HouseType HouseType { get; protected set; }

        public IReadOnlyCollection<Room> Rooms => _rooms;
        public IReadOnlyCollection<HouseImage> HouseImages => _houseImages;

        public Room AddRoom(
            string title, 
            string description, 
            Enums.RoomType roomType,
            Enums.LeaseType leaseType,
            decimal rentalFee)
        {
            var room = new Room(
                this.Id, 
                title, 
                description, 
                roomType,
                leaseType,
                rentalFee);
            _rooms.Add(room);
            return room;
        }
    }
}
