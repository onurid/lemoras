using System.Collections.Generic;
using Lemoras.Remora.Core.Interceptor;
using Lemoras.Remora.Roomshare.Domain.Enums;
using Lemoras.Remora.Roomshare.Domain.Models.RentContext;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Roomshare.Domain.Interfaces
{
    public interface IAdvertService : IRoleInterceptor, ITransientDependency
    {
        IEnumerable<Advert> GetAdverts();
        Advert Load(int id);
        void AssignInterested(int advertId, int userId, string displayName);
        void AdvertActive(int advertId);
        Advert CreateAdvert(AdvertType advertType, int houseId);
        Advert CreateAdvert(
            AdvertType advertType,
            string title,
            string description,
            string address,
            int countryId,
            int cityId,
            int districtId,
            HouseType houseType);
        void PublishAdvert(int advertId);
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
