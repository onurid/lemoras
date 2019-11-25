using Lemoras.Remora.Core.Interfaces;
using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Core.Models.KernelContext
{
    public class RoleAuthorise : Entity<int>, IKernelModelKey
    {
        public RoleAuthorise()
        {
                
        }

        public RoleAuthorise(int commandId, int roleId)
        {
            this.CommandId = commandId;
            this.RoleId = roleId;
        }

        public int CommandId { get; protected set; }
        public int RoleId { get; protected set; }

        public Command Command { get; protected set; }
    }
}