using System.Collections;
using System.Collections.Generic;
using Lemoras.Remora.Admin.Business.SystemModel;
using Lemoras.Remora.Admin.Domain.Factory;
using Lemoras.Remora.Admin.Domain.Language;
using Lemoras.Remora.Admin.Domain.Microservice;
using Lemoras.Remora.Admin.Domain.Module;
using Lemoras.Remora.Admin.Domain.Page;
using Lemoras.Remora.Admin.Domain.Template;
using OYASAR.Framework.Core.Exceptions;
using OYASAR.Framework.Core.Utils;
using Constants = Lemoras.Remora.Core.Constants;

namespace Lemoras.Remora.Admin.Business.Base
{
    public abstract class BaseSystemService : IBaseSystemService
    {
        protected readonly IRepositoryFactory repositories;

        public BaseSystemService()
        {
            repositories = Invoke<IRepositoryFactory>.Call();
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

        public virtual IEnumerable<Microservice> GetMicroservices()
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }
        
        public virtual IEnumerable<Module> GetModules()
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
