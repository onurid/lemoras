using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Admin.Domain.Role
{
    public class RolePage : Entity<int>, IRoleModelKey
    {
        public int RoleId { get; set; }
        public int ModulePageId { get; set; }

        public virtual Role Role { get; set; }
    }
}