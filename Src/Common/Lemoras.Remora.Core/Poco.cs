using OYASAR.Framework.Core.Entity;
using static OYASAR.Framework.Core.Utils.Constants;

namespace Lemoras.Remora.Core
{
    public class Poco<TId> : Entity<TId>
    {
        public BusinessObjectState State { get; set; }
    }
}