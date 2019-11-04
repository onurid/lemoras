using System.Collections.Generic;
using System.Linq;
using Lemoras.Remora.Kernel.Domain.BoundedContext;
using Lemoras.Remora.Kernel.Domain.Role;
using OYASAR.Framework.Core.Abstract;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Kernel.Infrastructure.Repositories.RoleContext
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

        public List<RoleAuthorise> GetRoleAuthoriseByRoleId(int roleId)
        {
            return GetAll<RoleAuthorise>(x => x.RoleId == roleId).ToList();
        }

        public RoleAuthorise AttachToCommandAtRole(int roleId, int commandId)
        {
            var roleAuthorise = new RoleAuthorise
            {
                RoleId = roleId,
                CommandId = commandId
            };

            this.Add<RoleAuthorise, int>(roleAuthorise);

            return roleAuthorise;
        }

        public List<Role> GetRoles()
        {
            return GetAll<Role>().ToList();
        }

        public List<RoleAuthorise> GetRoleAuthorises()
        {
            return GetAll<RoleAuthorise>().ToList();
        }

        public void RowDeleteRoleAuthorise(int roleAuthoriseId)
        {
            this.RowDelete<RoleAuthorise>(roleAuthoriseId);
        }

        public bool GetCheckApplicatonRole(int roleId, int applicationId)
        {
            return GetAll<Role>(x => x.Id == roleId & x.ApplicationId == applicationId).Any();
        }
    }
}