using System.Collections.Generic;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Kernel.Domain.Command
{
    public interface ICommandRepository : IBaseRepository<ICommandModelKey>, ITransientDependency
    {
        List<Command> GetCommands();
        Command GetCommand(string commandName);
        Command AddNewCommand(Command command, bool isPassive = true);
        void RowDeleteCommand(int commandId);
    }
}
