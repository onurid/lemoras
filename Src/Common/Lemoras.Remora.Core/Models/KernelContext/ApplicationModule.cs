using Lemoras.Remora.Core.Interfaces;
using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Core.Models.KernelContext
{
    public class ApplicationModule : Entity<int>, IKernelModelKey
    {
        public ApplicationModule(int applicationId, int businessLogicId, int moduleId)
        {
            this.ApplicationId = applicationId;
            this.BusinessLogicId = businessLogicId;
            this.ModuleId = moduleId;
        }

        public int ApplicationId { get; protected set; }
        public int BusinessLogicId { get; protected set; }
        public int ModuleId { get; protected set; }

        public BusinessLogic BusinessLogic { get; protected set; }
    }
}
