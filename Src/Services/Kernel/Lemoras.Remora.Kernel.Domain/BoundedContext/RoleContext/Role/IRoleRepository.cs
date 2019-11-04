using System.Collections.Generic;
using System.Linq;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Kernel.Domain.Role
{
    public interface IRoleRepository : IBaseRepository<IRoleModelKey>, ITransientDependency
    {
        Role CreateRoleToApplication(int applicationId, string roleName);
        IQueryable<Role> GetApplicationsOfRole(int roleId);
        List<Role> GetRolesOfApplication(int applicationId);
        void RemoveRoleFromApplication(int roleId);
        List<RoleAuthorise> GetRoleAuthoriseByRoleId(int roleId);
        RoleAuthorise AttachToCommandAtRole(int roleId, int commandId);
        List<Role> GetRoles();
        List<RoleAuthorise> GetRoleAuthorises();
        void RowDeleteRoleAuthorise(int roleAuthoriseId);
        bool GetCheckApplicatonRole(int roleId, int applicationId);
    }
}
