using System.Collections.Generic;
using Lemoras.Remora.Core.Models.KernelContext;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Core.Interfaces
{
    public interface IKernelRepository : IBaseRepository<IKernelModelKey>, ITransientDependency
    {
        IEnumerable<ApplicationModule> LoadAllApplicationModule(int applicationId);
        IEnumerable<BusinessService> LoadAllBusinessService();
        IEnumerable<RoleAuthorise> LoadAllRoleAuthorise(int roleId);

        ApplicationModule GetApplicationModule(int applicationId, string serviceKey);
        bool CheckAnyRoleAuthorises(int roleId, string commandName);
    }
}
