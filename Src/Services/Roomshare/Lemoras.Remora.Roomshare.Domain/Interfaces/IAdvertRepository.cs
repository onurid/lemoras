using System.Collections.Generic;
using Lemoras.Remora.Roomshare.Domain.Models.RentContext;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Roomshare.Domain.Interfaces
{
    public interface IAdvertRepository : ITransientDependency
    {
        IEnumerable<Advert> GetAll();
        Advert Find(int advertId);
        Advert Insert(Advert advert);
    }
}
