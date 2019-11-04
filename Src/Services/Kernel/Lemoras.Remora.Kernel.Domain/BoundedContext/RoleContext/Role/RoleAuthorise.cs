using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Kernel.Domain.Role
{
    public class RoleAuthorise : Entity<int>, IRoleModelKey
    {
        public int CommandId { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}