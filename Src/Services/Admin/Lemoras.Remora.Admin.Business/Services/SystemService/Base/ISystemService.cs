using System.Collections;
using System.Collections.Generic;
using Lemoras.Remora.Core.Attribute;
using Lemoras.Remora.Core.Interfaces;
using Lemoras.Remora.Admin.Business.SystemModel;
using Lemoras.Remora.Admin.Domain.Language;
using Lemoras.Remora.Admin.Domain.Microservice;
using Lemoras.Remora.Admin.Domain.Module;
using Lemoras.Remora.Admin.Domain.Page;
using Lemoras.Remora.Admin.Domain.Template;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Admin.Business.Base
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

        [RoleSet("DeleteMicroserviceModule")]
        void DeleteMicroserviceModule(int microserviceModuleId);

        [RoleSet("AddNewPage")]
        Page AddNewPage(PageContract contract);

        [RoleSet("DeletePage")]
        void DeletePage(int pageId);

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

        [RoleSet("GetRoutes")]
        IEnumerable<Page> GetRoutes();

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
