using System.Collections;
using System.Collections.Generic;
using Lemoras.Remora.Kernel.Business.ApplicationModel;
using Lemoras.Remora.Kernel.Domain.Application;
using Lemoras.Remora.Kernel.Domain.Factory;
using Lemoras.Remora.Kernel.Domain.Role;
using OYASAR.Framework.Core.Exceptions;
using OYASAR.Framework.Core.Extensions;
using OYASAR.Framework.Core.Utils;
using Constants = Lemoras.Remora.Core.Constants;

namespace Lemoras.Remora.Kernel.Business.Base
{
    public abstract class BaseApplicationService : IBaseApplicationService
    {
        protected readonly IRepositoryFactory repositories;

        public BaseApplicationService()
        {
            repositories = Invoke<IRepositoryFactory>.Call();
        }
        
        public virtual IEnumerable GetModuleRoutes()
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual ModulePage AttachToPageAtModule(int pageId, int applicationModuleId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual Application AddNewApplication(string applicationName, int applicationTypeId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual ApplicationType AddNewApplicationType(string applicationTypeName, bool isBackoffice)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual ApplicationInstance AttachToApplicationAtCompany(ApplicationCompanyContract contract)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual Role CreateRoleToApplication(int applicationId, string roleName)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual void DeleteApplication(int applicationId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual IEnumerable GetApplications()
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual object GetApplicationsOfCompanies()
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual IEnumerable<ApplicationInstance> GetApplicationsOfCompany(int companyId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual IEnumerable<Application> GetApplicationsOfRole(int roleId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual IEnumerable<ApplicationType> GetApplicationTypes()
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual ApplicationType GetApplicationType(int applicationTypeId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual IEnumerable<Role> GetRolesOfApplication(int applicationId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual void RemoveApplicationFromCompany(int applicationInstanceId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual void RemoveRoleFromApplication(int roleId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual void SetActiveToApplication(int applicationId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual void SetPassiveToApplication(int applicationId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual object GetApplicationModules()
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        private void SetApplicationStatus(bool activeStatus, int applicationId)
        {
            var repo = repositories.GetApplicationRepository();

            var application = repo.GetApplication(applicationId).ToCheck(Constants.Message.Exception.ApplicationNotFound);

            //application.Active = activeStatus;

            repo.UpdateApplication(application);
            repo.Save();
        }

        public virtual void DeleteApplicationType(int applicationTypeId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual void DeleteApplicationModule(int applicationModuleId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual ApplicationModule AddNewApplicationModule(ApplicationModuleContract contract)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }
    }
}
