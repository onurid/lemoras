using Lemoras.Remora.Roomshare.Domain.Interfaces;
using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Roomshare.Domain.Models.RentContext
{
    public class MemberInterested : Entity<int>, IAdvertModelKey
    {
        public MemberInterested(int advertId, int userId, string displayName)
        {
            this.AdvertId = advertId;
            this.UserId = userId;
            this.DisplayName = displayName;
        }

        public int AdvertId { get; protected set; }
        public int UserId { get; protected set; }
        public string DisplayName { get; protected set; }       
    }
}
