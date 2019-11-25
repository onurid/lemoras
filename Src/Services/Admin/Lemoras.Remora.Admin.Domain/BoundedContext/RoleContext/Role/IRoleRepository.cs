using System.Collections.Generic;
using System.Linq;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Admin.Domain.Role
{
    public interface IRoleRepository : IBaseRepository<IRoleModelKey>, ITransientDependency
    {
        Role CreateRoleToApplication(int applicationId, string roleName);
        IQueryable<Role> GetApplicationsOfRole(int roleId);
        List<Role> GetRolesOfApplication(int applicationId);
        void RemoveRoleFromApplication(int roleId);
        List<Role> GetRoles();
        bool GetCheckApplicatonRole(int roleId, int applicationId);
    }
}
