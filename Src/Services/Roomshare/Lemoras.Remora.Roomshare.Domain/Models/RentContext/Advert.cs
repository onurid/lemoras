using System.Collections.Generic;
using Lemoras.Remora.Roomshare.Domain.Enums;
using Lemoras.Remora.Roomshare.Domain.Interfaces;
using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Roomshare.Domain.Models.RentContext
{
    public class Advert : Entity<int>, IAdvertModelKey
    {
        private readonly List<MemberInterested> _memberInteresteds;

        public Advert()
        {

        }

        public Advert(
            int userId,
            AdvertType advertType,
            string title,
            string description,
            string address,
            int countryId,
            int cityId,
            int districtId,
            HouseType houseType)
        {
            this.UserId = userId;
            this.IsPublic = false;
            this.IsActice = false;
            this.AdvertType = advertType;

            House = new House(title, description, address, countryId, cityId, districtId, houseType);
            _memberInteresteds = new List<MemberInterested>();

            this.HouseId = House.Id;
        }

        public Advert(
            int userId,
            AdvertType advertType,
            int houseId)
        {
            this.UserId = userId;
            this.IsPublic = false;
            this.IsActice = false;
            this.AdvertType = advertType;
            this.HouseId = houseId;

            _memberInteresteds = new List<MemberInterested>();
        }

        public int UserId { get; protected set; }
        public int HouseId { get; protected set; }
        public bool IsPublic { get; protected set; }
        public bool IsActice { get; protected set; }
        public AdvertType AdvertType { get; protected set; }

        public House House { get; protected set; }
        public IReadOnlyCollection<MemberInterested> MemberInteresteds => _memberInteresteds;

        public void AddMemberInterested(int userId, string displayName)
        {
            _memberInteresteds.Add(new MemberInterested(this.Id, userId, displayName));
        }

        public void EditIsActive(bool active)
        {
            this.IsActice = active;
        }

        public void EditIsPublic(bool isPublic)
        {
            this.IsPublic = isPublic;
        }
    }
}
