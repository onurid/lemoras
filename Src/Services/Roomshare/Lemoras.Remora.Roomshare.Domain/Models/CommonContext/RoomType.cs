using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Roomshare.Domain.Models.CommonContext
{
    public class RoomType : Entity<int>
    {
        public RoomType()
        {

        }

        public string Title { get; protected set; }
    }
}
