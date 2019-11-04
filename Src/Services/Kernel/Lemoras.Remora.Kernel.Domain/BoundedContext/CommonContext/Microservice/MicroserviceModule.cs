using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Kernel.Domain.Microservice
{
    public class MicroserviceModule : Entity<int>, IMicroserviceModelKey
    {
        public int MicroserviceId { get; set; }
        public int ModuleId { get; set; }

        public virtual Microservice Microservice { get; set; }
    }
}