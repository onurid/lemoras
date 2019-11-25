using Lemoras.Remora.Core.Interfaces;
using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Core.Models.KernelContext
{
    public class Command : Entity<int>, IKernelModelKey
    {
        public Command(int businessServiceId, string commandName)
        {
            this.BusinessServiceId = BusinessServiceId;
            this.CommandName = commandName;
        }

        public string CommandName { get; protected set; }
        public int BusinessServiceId { get; protected set; }
    }
}