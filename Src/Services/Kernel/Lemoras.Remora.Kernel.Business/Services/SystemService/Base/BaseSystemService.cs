using System.Collections;
using System.Collections.Generic;
using Lemoras.Remora.Kernel.Business.SystemModel;
using Lemoras.Remora.Kernel.Domain.BusinessLogic;
using Lemoras.Remora.Kernel.Domain.Command;
using Lemoras.Remora.Kernel.Domain.Factory;
using Lemoras.Remora.Kernel.Domain.Language;
using Lemoras.Remora.Kernel.Domain.Microservice;
using Lemoras.Remora.Kernel.Domain.Module;
using Lemoras.Remora.Kernel.Domain.Page;
using Lemoras.Remora.Kernel.Domain.Role;
using Lemoras.Remora.Kernel.Domain.Template;
using OYASAR.Framework.Core.Exceptions;
using OYASAR.Framework.Core.Utils;
using Constants = Lemoras.Remora.Core.Constants;

namespace Lemoras.Remora.Kernel.Business.Base
{
    public abstract class BaseSystemService : IBaseSystemService
    {
        protected readonly IRepositoryFactory repositories;

        public BaseSystemService()
        {
            repositories = Invoke<IRepositoryFactory>.Call();
        }

        public virtual BusinessLogic AddNewBusinessLogic(BusinessLogicContract contract)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual BusinessService AddNewBusinessService(BusinessServiceContract contract)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual Command AddNewCommand(string commandName, int businessServiceId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual Microservice AddNewMicroservice(string microserviceName, string uniqueKey)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual Module AddNewModule(string moduleName)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual Page AddNewPage(PageContract contract)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual RoleAuthorise AttachToCommandAtRole(int roleId, int commandId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual MicroserviceModule AttachToModuleAtMicroservice(int microserviceId, int moduleId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }
        
        public virtual void DeleteBusinessLogic(int businessLogicId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual void DeleteBusinessService(int businessServiceId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual void DeleteCommand(int commandId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual void DeleteMicroservice(int microserviceId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual void DeleteModule(int moduleId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual void DeletePage(int pageId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual IEnumerable GetMicroserviceModules()
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual IEnumerable GetBusinessLogics()
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual IEnumerable<BusinessService> GetBusinessServices()
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual IEnumerable<Command> GetCommands()
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual IEnumerable<Microservice> GetMicroservices()
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }


        public virtual IEnumerable<Module> GetModules()
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual IEnumerable GetRoleAuthorises()
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual IEnumerable GetRoles()
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual IEnumerable<Page> GetRoutes()
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual void DeleteRoleAuthorise(int roleAuthoriseId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual void DeleteMicroserviceModule(int microserviceModuleId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual IEnumerable<Language> GetLanguages()
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual Language AddLanguage(string languageName)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual void DeleteLanguage(int languageId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual IEnumerable<Template> GetTemplates()
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual Template AddTemplate(string templateName, string templateUrl)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual void DeleteTemplate(int templateId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }
    }
}
