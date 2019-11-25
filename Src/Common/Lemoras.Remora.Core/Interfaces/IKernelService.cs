using System.Collections;
using System.Collections.Generic;
using Lemoras.Remora.Core.Attribute;
using Lemoras.Remora.Core.Models.KernelContext;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Core.Interfaces
{
    public interface IKernelService : IRoleInterceptor, ITransientDependency
    {
        [RoleSet("AddNewApplicationModule")]
        ApplicationModule AddNewApplicationModule(int applicationId, int moduleId, int businessLogicId);

        [RoleSet("DeleteApplicationModule")]
        void DeleteApplicationModule(int applicationModuleId);

        [RoleSet("GetApplicationModules")]
        object GetApplicationModules(int applicationId);

        [RoleSet("AttachToCommandAtRole")]
        RoleAuthorise AttachToCommandAtRole(int roleId, int commandId);

        [RoleSet("DeleteRoleAuthorise")]
        void DeleteRoleAuthorise(int roleAuthoriseId);

        [RoleSet("AddNewCommand")]
        Command AddNewCommand(string commandName, int businessServiceId);

        [RoleSet("DeleteCommand")]
        void DeleteCommand(int commandId);

        [RoleSet("AddNewBusinessLogic")]
        BusinessLogic AddNewBusinessLogic(string businessLogicName, int businessServiceId, string uniqueKey);

        [RoleSet("AddNewBusinessService")]
        BusinessService AddNewBusinessService(string businessServiceName, string businessServiceKey);

        [RoleSet("DeleteBusinessLogic")]
        void DeleteBusinessLogic(int businessLogicId);

        [RoleSet("DeleteBusinessService")]
        void DeleteBusinessService(int businessServiceId);

        [RoleSet("GetRoleAuthorises")]
        IEnumerable GetRoleAuthorises(int roleId);

        [RoleSet("GetCommands")]
        IEnumerable<Command> GetCommands();

        [RoleSet("GetBusinessLogics")]
        IEnumerable GetBusinessLogics();

        [RoleSet("GetBusinessServices")]
        IEnumerable<BusinessService> GetBusinessServices();
    }
}
