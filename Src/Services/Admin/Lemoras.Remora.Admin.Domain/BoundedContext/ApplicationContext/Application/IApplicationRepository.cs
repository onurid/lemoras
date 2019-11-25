using System.Collections;
using System.Collections.Generic;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Admin.Domain.Application
{
    public interface IApplicationRepository : IBaseRepository<IApplicationModelKey>, ITransientDependency
    {
        ApplicationType AddNewApplicationType(ApplicationType applicationType, bool isPassive = true);
        Application AddNewApplication(Application application, bool isPassive = true);
        Application GetApplication(int applicationId);
        Application DeleteApplication(Application application);
        void RowDeleteApplication(int applicationId);
        void RowDeleteApplicationType(int applicationTypeId);
        Application UpdateApplication(Application application);
        List<Application> GetApplications(bool isActive = true);
        bool IfExistsApplication(string applicationName);
        bool IfExistsApplication(int applicationId);
        ApplicationType GetApplicationType(int applicationTypeId);
        List<ApplicationType> GetApplicationTypes();
        IList GetApplicationsWithType();
        ApplicationInstance AttachToApplicationAtCompany(int companyId, int applicationId, string applicationTagName);
        List<ApplicationInstance> GetApplicationsOfCompany(int companyId, bool isActive = true);
        void RemoveApplicationFromCompany(int applicationInstanceId);
        List<ApplicationInstance> GetApplicationsOfCompanies(bool isActive = true);
        ModulePage AttachToPageAtModule(int pageId, int applicationModuleId);
        List<ModulePage> GetModulePages();
    }
}