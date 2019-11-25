using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lemoras.Remora.Admin.Business.ApplicationModel;
using Lemoras.Remora.Admin.Business.Base;
using Lemoras.Remora.Admin.Domain.Application;
using Lemoras.Remora.Admin.Domain.Company;
using Lemoras.Remora.Admin.Domain.Role;
using OYASAR.Framework.Core.Exceptions;
using OYASAR.Framework.Core.Extensions;
using Constants = Lemoras.Remora.Core.Constants;

namespace Lemoras.Remora.Admin.Business
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

        public override IEnumerable<Role> GetRolesOfApplication(int applicationId)
        {
            var repo = repositories.GetRoleRepository();

            var appRepo = repositories.GetApplicationRepository();

            var applicationInstance = appRepo.GetAll<ApplicationInstance>(x => x.Id == applicationId)
                .SingleOrDefault();

            var data = repo.GetRolesOfApplication(applicationInstance.ApplicationId);

            return data;
        }
    }
}
