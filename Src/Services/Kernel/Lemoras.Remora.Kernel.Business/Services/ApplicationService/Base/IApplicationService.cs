using System.Collections;
using System.Collections.Generic;
using Lemoras.Remora.Core.Attribute;
using Lemoras.Remora.Core.Interceptor;
using Lemoras.Remora.Kernel.Business.ApplicationModel;
using Lemoras.Remora.Kernel.Domain.Application;
using Lemoras.Remora.Kernel.Domain.Role;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Kernel.Business.Base
{
    public interface IApplicationService : IBaseApplicationService, IRoleInterceptor, ITransientDependency
    {
    }

    public interface IBaseApplicationService
    {
        [RoleSet("GetModuleRoutes")]
        IEnumerable GetModuleRoutes();

        [RoleSet("AttachToPageAtModule")]
        ModulePage AttachToPageAtModule(int pageId, int applicationModuleId);

        [RoleSet("AddNewApplication")]
        Application AddNewApplication(string applicationName, int applicationTypeId);

        [RoleSet("DeleteApplication")]
        void DeleteApplication(int applicationId);

        [RoleSet("RemoveApplicationFromCompany")]
        void RemoveApplicationFromCompany(int applicationInstanceId);

        [RoleSet("AddNewApplicationModule")]
        ApplicationModule AddNewApplicationModule(ApplicationModuleContract contract);

        [RoleSet("DeleteApplicationModule")]
        void DeleteApplicationModule(int applicationModuleId);

        [RoleSet("AttachToApplicationAtCompany")]
        ApplicationInstance AttachToApplicationAtCompany(ApplicationCompanyContract contract);

        [RoleSet("SetActiveToApplication")]
        void SetActiveToApplication(int applicationId);

        [RoleSet("SetPassiveToApplication")]
        void SetPassiveToApplication(int applicationId);

        [RoleSet("GetApplicationsOfCompany")]
        IEnumerable<ApplicationInstance> GetApplicationsOfCompany(int companyId);

        [RoleSet("GetApplications")]
        IEnumerable GetApplications();

        [RoleSet("GetApplicationTypes")]
        IEnumerable<ApplicationType> GetApplicationTypes();

        [RoleSet("GetApplicationType")]
        ApplicationType GetApplicationType(int applicationTypeId);

        [RoleSet("CreateRoleToApplication")]
        Role CreateRoleToApplication(int applicationId, string roleName);

        [RoleSet("RemoveRoleFromApplication")]
        void RemoveRoleFromApplication(int roleId);

        [RoleSet("GetRolesOfApplication")]
        IEnumerable<Role> GetRolesOfApplication(int applicationId);

        [RoleSet("GetApplicationsOfRole")]
        IEnumerable<Application> GetApplicationsOfRole(int roleId);

        [RoleSet("GetApplicationModules")]
        object GetApplicationModules();

        [RoleSet("AddNewApplicationType")]
        ApplicationType AddNewApplicationType(string applicationTypeName, bool isBackoffice);

        [RoleSet("GetApplicationsOfCompanies")]
        object GetApplicationsOfCompanies();

        [RoleSet("DeleteApplicationType")]
        void DeleteApplicationType(int applicationTypeId);
    }
}
