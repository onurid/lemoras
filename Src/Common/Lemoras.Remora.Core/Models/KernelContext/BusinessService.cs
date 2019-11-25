using System.Collections.Generic;
using Lemoras.Remora.Core.Interfaces;
using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Core.Models.KernelContext
{
    public class BusinessService : Entity<int>, IKernelModelKey
    {
        private readonly List<BusinessLogic> _businessLogics;
        private readonly List<Command> _commands;

        public BusinessService(string businessServiceName, string businessServiceKey)
        {
            this.BusinessServiceName = BusinessServiceName;
            this.BusinessServiceKey = businessServiceKey;
            _businessLogics = new List<BusinessLogic>();
            _commands = new List<Command>();
        }

        public string BusinessServiceName { get; protected set; }
        public string BusinessServiceKey { get; protected set; }

        public IReadOnlyCollection<BusinessLogic> BusinessLogics => _businessLogics;
        public IReadOnlyCollection<Command> Commands => _commands;

        public BusinessLogic AddBusinessLogic(string businessLogicName, string uniqueKey)
        {
            var businessLogic = new BusinessLogic(this.Id, businessLogicName, uniqueKey);
            _businessLogics.Add(businessLogic);
            return businessLogic;
        }

        public Command AddCommand(string commandName)
        {
            var command = new Command(this.Id, commandName);
            _commands.Add(command);
            return command;
        }
    }
}