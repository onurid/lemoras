using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lemoras.Remora.Kernel.Business.Base;
using Lemoras.Remora.Kernel.Business.SystemModel;
using Lemoras.Remora.Kernel.Domain.Application;
using Lemoras.Remora.Kernel.Domain.BusinessLogic;
using Lemoras.Remora.Kernel.Domain.Command;
using Lemoras.Remora.Kernel.Domain.Language;
using Lemoras.Remora.Kernel.Domain.Microservice;
using Lemoras.Remora.Kernel.Domain.Module;
using Lemoras.Remora.Kernel.Domain.Page;
using Lemoras.Remora.Kernel.Domain.Role;
using Lemoras.Remora.Kernel.Domain.Template;
using OYASAR.Framework.Core.Extensions;

namespace Lemoras.Remora.Kernel.Business
{
    public class SystemService : BaseSystemService, ISystemService
    {
        public override BusinessLogic AddNewBusinessLogic(BusinessLogicContract contract)
        {
            var repo = repositories.GetBusinessLogicRepository();

            var result = repo.AddNewBusinessLogic(
                new BusinessLogic
                {
                    BusinessLogicName = contract.BusinessLogicName,
                    BusinessServiceId = contract.BusinessServiceId,
                    UniqueKey = contract.UniqueKey
                }
            );
            repo.Save();

            return result;
        }

        public override BusinessService AddNewBusinessService(BusinessServiceContract contract)
        {
            var repo = repositories.GetBusinessLogicRepository();

            var result = new BusinessService
            {
                BusinessServiceName = contract.BusinessServiceName,
                BusinessServiceKey = contract.BusinessServiceKey
            };

            repo.Add<BusinessService, int>(result);
            repo.Save();

            return result;
        }

        public override Command AddNewCommand(string commandName, int businessServiceId)
        {
            var repo = repositories.GetCommandRepository();

            var result = repo.AddNewCommand(new Command
            {
                CommandName = commandName,
                BusinessServiceId = businessServiceId
            });

            repo.Save();

            return result;
        }

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

        public override RoleAuthorise AttachToCommandAtRole(int roleId, int commandId)
        {
            var repo = repositories.GetRoleRepository();

            var result = repo.AttachToCommandAtRole(roleId, commandId);
            repo.Save();

            return result;
        }

        public override MicroserviceModule AttachToModuleAtMicroservice(int microserviceId, int moduleId)
        {
            var repo = repositories.GetMicroserviceRepository();

            var result = repo.AttachToModuleAtMicroservice(microserviceId, moduleId);
            repo.Save();

            return result;
        }

        

        public override void DeleteBusinessLogic(int businessLogicId)
        {
            var repo = repositories.GetBusinessLogicRepository();

            repo.RowDeleteBusinessLogic(businessLogicId);
            repo.Save();
        }

        public override void DeleteBusinessService(int businessServiceId)
        {
            var repo = repositories.GetBusinessLogicRepository();

            repo.RowDelete<BusinessService>(businessServiceId);
            repo.Save();
        }

        public override void DeleteCommand(int commandId)
        {
            var repo = repositories.GetCommandRepository();

            repo.RowDeleteCommand(commandId);
            repo.Save();
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

        public override IEnumerable GetMicroserviceModules()
        {
            var repo = repositories.GetMicroserviceRepository();

            var microserviceModule = repo.GetMicroserviceModules();

            var microservice = repo.GetMicroservices();

            var module = repositories.GetModuleRepository().GetModules();

            var query = (from mm in microserviceModule
                         join mi in microservice on mm.MicroserviceId equals mi.Id
                         join mo in module on mm.ModuleId equals mo.Id
                         select new {
                             Id = mm.Id,
                             MicroserviceName = mi.MicroserviceName,
                             ModuleName = mo.ModuleName
                         }).ToList();

            return query;
        }

        public override IEnumerable GetBusinessLogics()
        {
            var repo = repositories.GetBusinessLogicRepository();

            var data =  repo.GetAll<BusinessLogic>(); //repo.GetBusinessLogics();

            var query = (from d in data 
                        join s in repo.GetAll<BusinessService>() on d.BusinessServiceId equals s.Id
                        select new { 
                            BusinessLogicName = d.BusinessLogicName,
                            UniqueKey = d.UniqueKey,
                            ServiceKey = s.BusinessServiceKey
                        }).ToList();

            return query;
        }

        public override IEnumerable<BusinessService> GetBusinessServices()
        {
            var repo = repositories.GetBusinessLogicRepository();

            var data =  repo.GetAll<BusinessService>().ToList(); //repo.GetBusinessLogics();

            return data;
        }

        public override IEnumerable<Command> GetCommands()
        {
            var repo = repositories.GetCommandRepository();

            var data = repo.GetCommands();

            return data;
        }

        public override IEnumerable<Microservice> GetMicroservices()
        {
            var repo = repositories.GetMicroserviceRepository();

            var data = repo.GetMicroservices();

            foreach(var item in data)
            {
                item.MicroserviceModules = null;
            }

            return data;
        }

        

        public override IEnumerable<Module> GetModules()
        {
            var repo = repositories.GetModuleRepository();

            var data = repo.GetModules();

            return data;
        }

        public override IEnumerable GetRoleAuthorises()
        {
            var repo = repositories.GetRoleRepository();

            var roleAuthorise = repo.GetAll<RoleAuthorise>();
            var role = repo.GetAll<Role>();
            var command = repositories.GetCommandRepository().GetAll<Command>();

            var query = (from ra in roleAuthorise
                         join r in role on ra.RoleId equals r.Id
                         join c in command on ra.CommandId equals c.Id
                         select new {
                             Id = ra.Id,
                             RoleName = r.RoleName,
                             CommandName = c.CommandName
                         }).ToList();

            return query;
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

        public override void DeleteRoleAuthorise(int roleAuthoriseId)
        {
            var repo = repositories.GetRoleRepository();

            repo.RowDeleteRoleAuthorise(roleAuthoriseId);
            repo.Save();
        }

        public override void DeleteMicroserviceModule(int microserviceModuleId)
        {
            var repo = repositories.GetMicroserviceRepository();

            repo.RowDeleteMicroserviceModule(microserviceModuleId);
            repo.Save();
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
