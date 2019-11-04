using System.Collections.Generic;
using System.Linq;
using Lemoras.Remora.Core;
using Lemoras.Remora.Kernel.Domain.BoundedContext;
using Lemoras.Remora.Kernel.Domain.Command;
using OYASAR.Framework.Core.Abstract;
using OYASAR.Framework.Core.Extensions;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Kernel.Infrastructure.Repositories.RoleContext
{
    public class CommandRepository : BaseRepository<IEFRepository<IRoleContext>, ICommandModelKey>, ICommandRepository
    {
        public Command AddNewCommand(Command command, bool isPassive = true)
        {
            this.Add<Command, int>(command);
            return command;
        }

        public Command GetCommand(string commandName)
        {
            return GetAll<Command>(x => x.CommandName == commandName).SingleOrDefault()
                .ToCheck(Constants.Message.Exception.NotFound);
        }

        public List<Command> GetCommands()
        {
            return GetAll<Command>().ToList()
                .ToCheck(Constants.Message.Exception.NotFound);
        }

        public void RowDeleteCommand(int commandId)
        {
            this.RowDelete<Command>(commandId);
        }
    }
}