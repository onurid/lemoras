using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Admin.Domain.Config
{
    public class CrunchConfig : Entity<int>, IConfigModelKey
    {
        public string Data { get; set; }
    }
}
