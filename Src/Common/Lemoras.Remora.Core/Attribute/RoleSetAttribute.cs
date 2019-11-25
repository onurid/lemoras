using System;
using Lemoras.Remora.Core.Interfaces;
using OYASAR.Framework.Core.Interface;
using OYASAR.Framework.Core.Utils;

namespace Lemoras.Remora.Core.Attribute
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class RoleSetAttribute : System.Attribute, IRoleSetAttribute
    {
        private readonly IWorkContextService service;

        private readonly string roleSetCommandName;

        public RoleSetAttribute(string roleSetCommandName)
        {
            this.service = Invoke<IWorkContextService>.Call();
            this.roleSetCommandName = roleSetCommandName;
        }

        public bool IsAcceptable()
        {
            return service.IsAcceptableRoleSetCommand(roleSetCommandName);
        }
    }
}
