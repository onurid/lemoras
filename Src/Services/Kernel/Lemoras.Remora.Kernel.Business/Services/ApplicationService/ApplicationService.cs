using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lemoras.Remora.Kernel.Business.ApplicationModel;
using Lemoras.Remora.Kernel.Business.Base;
using Lemoras.Remora.Kernel.Domain.Application;
using Lemoras.Remora.Kernel.Domain.BusinessLogic;
using Lemoras.Remora.Kernel.Domain.Company;
using Lemoras.Remora.Kernel.Domain.Module;
using Lemoras.Remora.Kernel.Domain.Page;
using Lemoras.Remora.Kernel.Domain.Role;
using OYASAR.Framework.Core.Exceptions;
using OYASAR.Framework.Core.Extensions;
using Constants = Lemoras.Remora.Core.Constants;

namespace Lemoras.Remora.Kernel.Business
{
    public class ApplicationService : BaseApplicationService, IApplicationService
    {
        public override ModulePage AttachToPageAtModule(int pageId, int applicationModuleId)
        {
            var repo = repositories.GetApplicationRepository();

            var result = repo.AttachToPageAtModule(pageId, applicationModuleId);
            repo.Save();

            return result;
        }

        public override IEnumerable GetModuleRoutes()
        {
            var repo = repositories.GetApplicationRepository();
            var repoModule = repositories.GetModuleRepository();

            var data = repo.GetAll<ModulePage>();

            var module = repoModule.GetAll<Module>();

            var appModuleData = repositories.GetApplicationRepository().GetAll<ApplicationModule>();

            var page = repositories.GetPageRepository().GetAll<Page>();

            var query = (from d in data
                         join a in appModuleData on d.ApplicationModuleId equals a.Id
                         join m in module on a.ModuleId equals m.Id
                         join p in page on d.PageId equals p.Id
                         select new
                         {
                             Id = d.Id,
                             ModuleName = m.ModuleName,
                             RouteName = p.RouteName
                         }).ToList();

            return query;
        }

        public override Application AddNewApplication(string applicationName, int applicationTypeId)
        {
            var repo = repositories.GetApplicationRepository();

            var newApp = new Application
            {
                ApplicationName = applicationName,
                ApplicationTypeId = applicationTypeId
            };

            repo.AddNewApplication(newApp);
            repo.Save();

            return newApp;
        }

        public override ApplicationType AddNewApplicationType(string applicationTypeName, bool isBackoffice)
        {
            var repo = repositories.GetApplicationRepository();

            var newAppType = new ApplicationType
            {
                ApplicationTypeName = applicationTypeName,
                IsBackOffice = isBackoffice
            };

            repo.AddNewApplicationType(newAppType);
            repo.Save();

            return newAppType;
        }

        public override ApplicationInstance AttachToApplicationAtCompany(ApplicationCompanyContract contract)
        {
            var repo = repositories.GetApplicationRepository();

            var result = repo.AttachToApplicationAtCompany(contract.CompanyId, contract.ApplicationId, contract.ApplicationTagName);
            repo.Save();

            return result;
        }

        public  override Role CreateRoleToApplication(int applicationId, string roleName)
        {
            var repo = repositories.GetRoleRepository();

            var result = repo.CreateRoleToApplication(applicationId, roleName);
            repo.Save();

            return result;
        }

        public override void DeleteApplication(int applicationId)
        {
            var repo = repositories.GetApplicationRepository();
        
            if (!repo.IfExistsApplication(applicationId))
                throw new BusinessException(Constants.Message.Exception.ApplicationNotFound);

            repo.RowDeleteApplication(applicationId);
            repo.Save();
        }

        public override IEnumerable GetApplications()
        {
            var repo = repositories.GetApplicationRepository();

            var data = repo.GetApplicationsWithType();          
            
            return data;
        }

        public override object GetApplicationsOfCompanies()
        {
            var repoCompany = repositories.GetCompanyRepository();

            var repoApp = repositories.GetApplicationRepository();

            var company = repoCompany.GetAll<Company>();

            var applicationInstance = repoApp.GetAll<ApplicationInstance>();

            var application = repoApp.GetAll<Application>();

            var data = (from ca in applicationInstance
                        join c in company on ca.CompanyId equals c.Id
                         join a in application on ca.ApplicationId equals a.Id
                         select new {
                             Id = ca.Id,
                             CompanyName = c.CompanyName,
                             ApplicationName = a.ApplicationName,
                             ApplicationTagName = ca.ApplicationTagName,
                             ConnectionString = "####-#########-######-##########"
                         }).ToList();

            return data;
        }

        public override IEnumerable<ApplicationInstance> GetApplicationsOfCompany(int companyId)
        {
            var repo = repositories.GetApplicationRepository();

            var data = repo.GetApplicationsOfCompany(companyId);

            return data;
        }

        public override IEnumerable<Application> GetApplicationsOfRole(int roleId)
        {
            var roleRepo = repositories.GetRoleRepository();

            var applicatinRepo = repositories.GetApplicationRepository();

            var roleQuery = roleRepo.GetApplicationsOfRole(roleId);

            var query = (from a in applicatinRepo.GetAll<Application>()
                         join r in roleQuery on a.Id equals r.ApplicationId
                         select a);

            var data = query.ToList().ToCheck(Constants.Message.Exception.NotFound);

            return data;
        }

        public override IEnumerable<ApplicationType> GetApplicationTypes()
        {
            var repo = repositories.GetApplicationRepository();

            var data = repo.GetApplicationTypes();

            return data;
        }

        public override ApplicationType GetApplicationType(int applicationTypeId)
        {
            var repo = repositories.GetApplicationRepository();

            var data = repo.GetApplicationType(applicationTypeId);

            return data;
        }

        public override IEnumerable<Role> GetRolesOfApplication(int applicationId)
        {
            var repo = repositories.GetRoleRepository();

            var appRepo = repositories.GetApplicationRepository();

            var applicationInstance = appRepo.GetAll<ApplicationInstance>(x=> x.Id == applicationId)
                .SingleOrDefault();

            var data = repo.GetRolesOfApplication(applicationInstance.ApplicationId);

            foreach (var item in data)
            {
                item.RoleAuthorises = null;
            }

            return data;
        }

        public override void RemoveApplicationFromCompany(int applicationInstanceId)
        {
            var repo = repositories.GetApplicationRepository();

            repo.RemoveApplicationFromCompany(applicationInstanceId);
            repo.Save();
        }

        public override void RemoveRoleFromApplication(int roleId)
        {
            var repo = repositories.GetRoleRepository();

            repo.RemoveRoleFromApplication(roleId);
            repo.Save();
        }

        public override void SetActiveToApplication(int applicationId)
        {
            SetApplicationStatus(false, applicationId);
        }

        public override void SetPassiveToApplication(int applicationId)
        {
            SetApplicationStatus(false, applicationId);
        }

        public override object GetApplicationModules()
        {
            var repo = repositories.GetApplicationRepository();

            var application = repo.GetAll<Application>();
            var applicationModule = repo.GetAll<ApplicationModule>();

            var module = repositories.GetModuleRepository().GetAll<Module>();
            var businessLogic = repositories.GetBusinessLogicRepository().GetAll<BusinessLogic>();

            var data = from a in application
                       join am in applicationModule on a.Id equals am.ApplicationId
                       join m in module on am.ModuleId equals m.Id
                       join b in businessLogic on am.BusinessLogicId equals b.Id
                       select new {
                           Id = am.Id,
                           ApplicationName = a.ApplicationName,
                           ModuleName = m.ModuleName,
                           BusinessLogicName = b.BusinessLogicName
                       };

            return data;
        }

        private void SetApplicationStatus(bool activeStatus, int applicationId)
        {
            var repo = repositories.GetApplicationRepository();

            var application = repo.GetApplication(applicationId).ToCheck(Constants.Message.Exception.ApplicationNotFound);

            //application.Active = activeStatus;

            repo.UpdateApplication(application);
            repo.Save();
        }

        public override void DeleteApplicationType(int applicationTypeId)
        {
            var repo = repositories.GetApplicationRepository();
            
            repo.RowDeleteApplicationType(applicationTypeId);
            repo.Save();
        }

        public override void DeleteApplicationModule(int applicationModuleId)
        {
            var repo = repositories.GetApplicationRepository();

            repo.RowDeleteApplicationModule(applicationModuleId);
            repo.Save();
        }

        public override ApplicationModule AddNewApplicationModule(ApplicationModuleContract contract)
        {
            var repo = repositories.GetApplicationRepository();

            var newAppModule = new ApplicationModule
            {
                ApplicationId = contract.ApplicationId,
                ModuleId = contract.ModuleId,
                BusinessLogicId = contract.BusinessLogicId
            };

            repo.AddNewApplicationModule(newAppModule);
            repo.Save();

            return newAppModule;
        }
    }
}
