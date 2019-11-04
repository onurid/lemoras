using System.Collections.Generic;
using System.Linq;
using Lemoras.Remora.Roomshare.Domain.Interfaces;
using Lemoras.Remora.Roomshare.Domain.Models.RentContext;
using Microsoft.EntityFrameworkCore;
using OYASAR.Framework.Core.Abstract;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Roomshare.Infrastructure.Repositories.RentContext
{
    public class AdvertRepository : BaseRepository<IEFRepository<IRentContext>, IAdvertModelKey>, IAdvertRepository
    {
        public Advert Find(int advertId)
        {
            return base.GetAll<Advert>(x=> x.Id == advertId)
                .Include(x=> x.House)
                .ThenInclude(x=> x.HouseImages)
                .Include(x=> x.House)
                .ThenInclude(x=> x.Rooms)
                .Include(x => x.House)
                .ThenInclude(x => x.Rooms.SelectMany(y => y.RoomImages))
                .SingleOrDefault();
        }

        public new IEnumerable<Advert> GetAll()
        {
            return base.GetAll<Advert>().ToList();
        }

        public Advert Insert(Advert advert)
        {
            base.Add<Advert, int>(advert);
            return advert;
        }
    }
}