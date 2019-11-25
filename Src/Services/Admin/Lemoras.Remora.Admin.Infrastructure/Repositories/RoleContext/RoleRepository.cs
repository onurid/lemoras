using System.Collections.Generic;
using System.Linq;
using Lemoras.Remora.Admin.Domain.BoundedContext;
using Lemoras.Remora.Admin.Domain.Role;
using OYASAR.Framework.Core.Abstract;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Admin.Infrastructure.Repositories.RoleContext
{
    public class RoleRepository : BaseRepository<IEFRepository<IRoleContext>, IRoleModelKey>, IRoleRepository
    {
        public Role CreateRoleToApplication(int applicationId, string roleName)
        {
            var role = new Role
            {
                ApplicationId = applicationId,
                RoleName = roleName
            };
            this.Add<Role, int>(role);

            return role;
        }

        public IQueryable<Role> GetApplicationsOfRole(int roleId)
        {
            return GetAll<Role>(x => x.Id == roleId);
        }

        public List<Role> GetRolesOfApplication(int applicationId)
        {
            return GetAll<Role>(x => x.ApplicationId == applicationId).ToList();
        }

        public void RemoveRoleFromApplication(int roleId)
        {
            this.RowDelete<Role>(roleId);
        }

        public List<Role> GetRoles()
        {
            return GetAll<Role>().ToList();
        }

        public bool GetCheckApplicatonRole(int roleId, int applicationId)
        {
            return GetAll<Role>(x => x.Id == roleId & x.ApplicationId == applicationId).Any();
        }
    }
}