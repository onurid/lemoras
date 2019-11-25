using System.Collections.Generic;
using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Admin.Domain.Role
{
    public class Role : Entity<int>, IRoleModelKey
    {
        public string RoleName { get; set; }
        public int ApplicationId { get; set; }
        
        public virtual List<RolePage> RolePages { get; set; }
    }
}