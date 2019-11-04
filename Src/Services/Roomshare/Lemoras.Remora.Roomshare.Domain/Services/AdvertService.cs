using System.Collections.Generic;
using Lemoras.Remora.Roomshare.Domain.Enums;
using Lemoras.Remora.Roomshare.Domain.Interfaces;
using Lemoras.Remora.Roomshare.Domain.Models.RentContext;
using OYASAR.Framework.Core.Exceptions;
using OYASAR.Framework.Core.Utils;

namespace Lemoras.Remora.Roomshare.Domain.Services
{
    public class AdvertService : IAdvertService
    {
        private readonly IAdvertRepository _repository;

        public AdvertService()
        {
            _repository = Invoke<IAdvertRepository>.Call();
        }

        public Advert Load(int id)
        {
            var advert = _repository.Find(id);
            if (advert == null)
            {
                throw new BusinessException($"{nameof(Advert)} not found by {id}");
            }
            return advert;
        }

        public void AssignInterested(int advertId, int userId, string displayName)
        {
            var advert = Load(advertId);

            advert.AddMemberInterested(userId, displayName);
        }

        public IEnumerable<Advert> GetAdverts()
        {
            return _repository.GetAll();
        }

        public void AdvertActive(int advertId)
        {
            var advert = Load(advertId);
            advert.EditIsActive(true);
        }

        public Advert CreateAdvert(
            AdvertType advertType,
            string title,
            string description,
            string address,
            int countryId,
            int cityId,
            int districtId,
            HouseType houseType)
        {
            var userId = 1;
            var advert = new Advert(
                userId, 
                advertType,
                title,
                description,
                address,
                countryId,
                cityId,
                districtId,
                houseType);

            _repository.Insert(advert);
            return advert;
        }

        public Advert CreateAdvert(AdvertType advertType, int houseId)
        {
            var userId = 1;
            var advert = new Advert(userId, advertType, houseId);

            _repository.Insert(advert);
            return advert;
        }

        public void PublishAdvert(int advertId)
        {
            var advert = Load(advertId);
            advert.EditIsPublic(true);
        }

        public Room AddRoom(
            int advertId, 
            string title, 
            string description, 
            RoomType roomType, 
            IEnumerable<string> urls,
            LeaseType leaseType,
            decimal rentalFee)
        {
            var advert = Load(advertId);
            var room = advert.House.AddRoom(title, description, roomType, leaseType, rentalFee);

            foreach(var url in urls)
            {
                room.AddRoomImage(url);
            }

            return room;
        }
    }
}
