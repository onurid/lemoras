using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Kernel.Domain.Application
{
    public class ApplicationModule : Entity<int>, IApplicationModelKey
    {
        public int ApplicationId { get; set; }
        public int BusinessLogicId { get; set; }
        public int ModuleId { get; set; }

        public virtual Application Application { get; set; }
    }
}