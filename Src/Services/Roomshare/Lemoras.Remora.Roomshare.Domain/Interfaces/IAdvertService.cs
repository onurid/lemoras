using System.Collections.Generic;
using Lemoras.Remora.Core.Attribute;
using Lemoras.Remora.Core.Interfaces;
using Lemoras.Remora.Roomshare.Domain.Enums;
using Lemoras.Remora.Roomshare.Domain.Models.RentContext;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Roomshare.Domain.Interfaces
{
    public interface IAdvertService : IRoleInterceptor, ITransientDependency
    {
        [RoleSet("GetAdverts")]
        IEnumerable<Advert> GetAdverts();

        [RoleSet("Load")]
        Advert Load(int id);

        [RoleSet("AssignInterested")]
        void AssignInterested(int advertId, int userId, string displayName);

        [RoleSet("AdvertActive")]
        void AdvertActive(int advertId);

        [RoleSet("CreateAdvertExtension")]
        Advert CreateAdvert(AdvertType advertType, int houseId);

        [RoleSet("CreateAdvert")]
        Advert CreateAdvert(
            AdvertType advertType,
            string title,
            string description,
            string address,
            int countryId,
            int cityId,
            int districtId,
            HouseType houseType);

        [RoleSet("PublishAdvert")]
        void PublishAdvert(int advertId);

        [RoleSet("AddRoom")]
        Room AddRoom(
            int advertId, 
            string title, 
            string description, 
            RoomType roomType, 
            IEnumerable<string> urls,
            LeaseType leaseType,
            decimal rentalFee);
    }
}
