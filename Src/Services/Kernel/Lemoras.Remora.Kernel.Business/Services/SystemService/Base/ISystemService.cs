using System.Collections;
using System.Collections.Generic;
using Lemoras.Remora.Core.Attribute;
using Lemoras.Remora.Core.Interceptor;
using Lemoras.Remora.Kernel.Business.SystemModel;
using Lemoras.Remora.Kernel.Domain.BusinessLogic;
using Lemoras.Remora.Kernel.Domain.Command;
using Lemoras.Remora.Kernel.Domain.Language;
using Lemoras.Remora.Kernel.Domain.Microservice;
using Lemoras.Remora.Kernel.Domain.Module;
using Lemoras.Remora.Kernel.Domain.Page;
using Lemoras.Remora.Kernel.Domain.Role;
using Lemoras.Remora.Kernel.Domain.Template;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Kernel.Business.Base
{
    public interface ISystemService : IBaseSystemService, IRoleInterceptor, ITransientDependency
    {
    }

    public interface IBaseSystemService 
    {
        [RoleSet("AddNewModule")]
        Module AddNewModule(string moduleName);

        [RoleSet("DeleteModule")]
        void DeleteModule(int moduleId);
        
        [RoleSet("AttachToCommandAtRole")]
        RoleAuthorise AttachToCommandAtRole(int roleId, int commandId);

        [RoleSet("AttachToModuleAtMicroservice")]
        MicroserviceModule AttachToModuleAtMicroservice(int microserviceId, int moduleId);

        [RoleSet("DeleteRoleAuthorise")]
        void DeleteRoleAuthorise(int roleAuthoriseId);

        [RoleSet("DeleteMicroserviceModule")]
        void DeleteMicroserviceModule(int microserviceModuleId);

        [RoleSet("AddNewPage")]
        Page AddNewPage(PageContract contract);

        [RoleSet("DeletePage")]
        void DeletePage(int pageId);

        [RoleSet("AddNewCommand")]
        Command AddNewCommand(string commandName, int businessServiceId);

        [RoleSet("DeleteCommand")]
        void DeleteCommand(int commandId);

        [RoleSet("AddNewBusinessLogic")]
        BusinessLogic AddNewBusinessLogic(BusinessLogicContract contract);

        [RoleSet("AddNewBusinessService")]
        BusinessService AddNewBusinessService(BusinessServiceContract contract);

        [RoleSet("DeleteBusinessLogic")]
        void DeleteBusinessLogic(int businessLogicId);

        [RoleSet("DeleteBusinessService")]
        void DeleteBusinessService(int businessServiceId);

        [RoleSet("AddNewMicroservice")]
        Microservice AddNewMicroservice(string microserviceName, string uniqueKey);

        [RoleSet("DeleteMicroservice")]
        void DeleteMicroservice(int microserviceId);

        [RoleSet("GetMicroservices")]
        IEnumerable<Microservice> GetMicroservices();

        [RoleSet("GetMicroserviceModules")]
        IEnumerable GetMicroserviceModules();

        [RoleSet("GetModules")]
        IEnumerable<Module> GetModules();

        [RoleSet("GetRoles")]
        IEnumerable GetRoles();

        [RoleSet("GetRoleAuthorises")]
        IEnumerable GetRoleAuthorises();

        [RoleSet("GetRoutes")]
        IEnumerable<Page> GetRoutes();

        [RoleSet("GetCommands")]
        IEnumerable<Command> GetCommands();

        [RoleSet("GetBusinessLogics")]
        IEnumerable GetBusinessLogics();

        [RoleSet("GetBusinessServices")]
        IEnumerable<BusinessService> GetBusinessServices();

        [RoleSet("GetLanguages")]
        IEnumerable<Language> GetLanguages();

        [RoleSet("AddLanguage")]
        Language AddLanguage(string languageName);

        [RoleSet("DeleteLanguage")]
        void DeleteLanguage(int languageId);

        [RoleSet("GetTemplates")]
        IEnumerable<Template> GetTemplates();

        [RoleSet("AddTemplate")]
        Template AddTemplate(string templateName, string templateUrl);

        [RoleSet("DeleteTemplate")]
        void DeleteTemplate(int templateId);
    }
}
