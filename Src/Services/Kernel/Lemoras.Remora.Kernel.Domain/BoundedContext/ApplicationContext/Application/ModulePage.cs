using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Kernel.Domain.Application
{
    public class ModulePage : Entity<int>, IApplicationModelKey
    {
        public int ApplicationInstanceId { get; set; }
        public int ApplicationModuleId { get; set; }        
        public int PageId { get; set; }
    }
}
