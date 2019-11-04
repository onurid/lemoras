using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Kernel.Domain.Command
{
    public class Command : Entity<int>, ICommandModelKey
    {
        public string CommandName { get; set; }
        public int BusinessServiceId { get; set; }
    }
}