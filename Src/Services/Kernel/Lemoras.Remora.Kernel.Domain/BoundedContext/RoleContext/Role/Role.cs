using System.Collections.Generic;
using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Kernel.Domain.Role
{
    public class Role : Entity<int>, IRoleModelKey
    {
        public string RoleName { get; set; }
        public int ApplicationId { get; set; }

        public virtual List<RoleAuthorise> RoleAuthorises { get; set; }
        public virtual List<RolePage> RolePages { get; set; }
    }
}