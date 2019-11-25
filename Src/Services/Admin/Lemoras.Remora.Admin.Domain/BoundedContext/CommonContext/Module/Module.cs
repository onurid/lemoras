using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Admin.Domain.Module
{
    public class Module : Entity<int>, IModuleModelKey
    {
        public string ModuleName { get; set; }
    }
}
