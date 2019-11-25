using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lemoras.Remora.Admin.Business.Base;
using Lemoras.Remora.Admin.Business.SystemModel;
using Lemoras.Remora.Admin.Domain.Application;
using Lemoras.Remora.Admin.Domain.Language;
using Lemoras.Remora.Admin.Domain.Microservice;
using Lemoras.Remora.Admin.Domain.Module;
using Lemoras.Remora.Admin.Domain.Page;
using Lemoras.Remora.Admin.Domain.Role;
using Lemoras.Remora.Admin.Domain.Template;
using OYASAR.Framework.Core.Extensions;

namespace Lemoras.Remora.Admin.Business
{
    public class SystemService : BaseSystemService, ISystemService
    {
        public override Microservice AddNewMicroservice(string microserviceName, string uniqueKey)
        {
            var repo = repositories.GetMicroserviceRepository();

            var result = repo.AddNewMicroservice(new Microservice
            {
                MicroserviceName = microserviceName,
                UniqueKey = uniqueKey
            });

            repo.Save();

            return result;
        }

        public override Module AddNewModule(string moduleName)
        {
            var repo = repositories.GetModuleRepository();

            var result = repo.AddNewModule(new Module
            {
                ModuleName = moduleName
            });
            repo.Save();

            return result;
        }

        public override Page AddNewPage(PageContract contract)
        {
            var repo = repositories.GetPageRepository();

            var result = repo.AddNewPage(new Page
            {
                RouteName = contract.RouteName,
                ControllerName = contract.ControllerName,
                ControllerAsName = contract.ControllerAsName,
                ControllerUrl = contract.ControllerUrl,
                TemplateUrl = contract.TemplateUrl
            });
            repo.Save();

            return result;
        }
        
        public override void DeleteMicroservice(int microserviceId)
        {
            var repo = repositories.GetMicroserviceRepository();

            repo.RowDeleteMicroservice(microserviceId);
            repo.Save();
        }

        public override void DeleteModule(int moduleId)
        {
            var repo = repositories.GetModuleRepository();

            repo.RowDeleteModule(moduleId);
            repo.Save();
        }

        public override void DeletePage(int pageId)
        {
            var repo = repositories.GetPageRepository();

            repo.RowDeletePage(pageId);
            repo.Save();
        }
        
        public override IEnumerable<Module> GetModules()
        {
            var repo = repositories.GetModuleRepository();

            var data = repo.GetModules();

            return data;
        }
        
        public override IEnumerable GetRoles()
        {
            var role = repositories.GetRoleRepository().GetAll<Role>();

            var app = repositories.GetApplicationRepository().GetAll<Application>();

            var query = (from a in app
                         join r in role on a.Id equals r.ApplicationId
                         select new {
                             Id = r.Id,
                             ApplicationName = a.ApplicationName,
                             RoleName = r.RoleName
                         }).ToList();
            
            return query;
        }

        public override IEnumerable<Page> GetRoutes()
        {
            var repo = repositories.GetPageRepository();

            var data = repo.GetPages();

            return data;
        }
        
        public override IEnumerable<Language> GetLanguages()
        {
            var data = repositories.GetLanguageRepository().GetAll<Language>().ToList().ToCheck("Not found");
            return data;
        }

        public override Language AddLanguage(string languageName)
        {
            var language = new Language { LanguageName = languageName };
            repositories.GetLanguageRepository().Add<Language, int>(language);
            return language;
        }

        public override void DeleteLanguage(int languageId)
        {
            repositories.GetLanguageRepository().RowDelete<Language>(languageId);
        }

        public override IEnumerable<Template> GetTemplates()
        {
            var data = repositories.GetTemplateRepository().GetAll<Template>().ToList().ToCheck("Not found");
            return data;
        }

        public override Template AddTemplate(string templateName, string templateUrl)
        {
            var template = new Template { TemplateName = templateName , TemplateUrl = templateUrl };
            repositories.GetTemplateRepository().Add<Template, int>(template);
            return template;
        }

        public override void DeleteTemplate(int templateId)
        {
            repositories.GetTemplateRepository().RowDelete<Template>(templateId);
        }
    }
}
