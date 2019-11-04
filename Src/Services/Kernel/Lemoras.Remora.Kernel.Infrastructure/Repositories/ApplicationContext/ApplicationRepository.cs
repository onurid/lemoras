using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lemoras.Remora.Kernel.Domain.Application;
using Lemoras.Remora.Kernel.Domain.BoundedContext;
using OYASAR.Framework.Core.Abstract;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Kernel.Infrastructure.Repositories.ApplicationContext
{
    public class ApplicationRepository : BaseRepository<IEFRepository<IApplicationContext>, IApplicationModelKey>, IApplicationRepository
    {
        public Application AddNewApplication(Application application, bool isPassive = true)
        {
            this.Add<Application, int>(application);
            return application;
        }

        public ModulePage AttachToPageAtModule(int pageId, int applicationModuleId)
        {
            var modulePage = new ModulePage
            {
                PageId = pageId,
                ApplicationModuleId = applicationModuleId
            };
            this.Add<ModulePage, int>(modulePage);

            return modulePage;
        }

        public List<ModulePage> GetModulePages()
        {
            return GetAll<ModulePage>().ToList();
        }

        public ApplicationType AddNewApplicationType(ApplicationType applicationType, bool isPassive = true)
        {
            this.Add<ApplicationType, int>(applicationType);
            return applicationType;
        }        

        public Application GetApplication(int applicationId)
        {
            return GetByKey<Application>(applicationId);
        }

        public List<Application> GetApplications(bool isActive = true)
        {
            return GetAll<Application>().ToList();
        }

        public IList GetApplicationsWithType()
        {
            return (from a in GetAll<Application>()
                        join at in GetAll<ApplicationType>() on a.ApplicationTypeId equals at.Id
                        select new {
                            Id = a.Id,
                            ApplicationName = a.ApplicationName,
                            ApplicationTypeName = at.ApplicationTypeName
                        }).ToList();
        }

        public ApplicationType GetApplicationType(int applicationTypeId)
        {
            return GetByKey<ApplicationType>(applicationTypeId);
        }

        public List<ApplicationType> GetApplicationTypes()
        {
            return GetAll<ApplicationType>().ToList();
        }

        public Application DeleteApplication(Application application)
        {
            this.Delete<Application, int>(application);
            return application;
        }

        public void RowDeleteApplication(int applicationId)
        {
            this.RowDelete<Application>(applicationId);
        }

        public Application UpdateApplication(Application application)
        {
            this.Edit<Application, int>(application);
            return application;
        }

        public bool IfExistsApplication(string applicationName)
        {
            return GetAll<Application>(x => x.ApplicationName == applicationName).Any();
        }

        public bool IfExistsApplication(int applicationId)
        {
            return GetAll<Application>(x => x.Id == applicationId).Any();
        }

        public IQueryable<ApplicationModule> GetUniqueKeyNamebyServiceKey(int applicationId)
        {
            return GetAll<ApplicationModule>(x => x.ApplicationId == applicationId);
        }

        public List<ApplicationModule> GetApplicationModules()
        {
            return GetAll<ApplicationModule>().ToList();
        }

        public void RowDeleteApplicationType(int applicationTypeId)
        {
            this.RowDelete<ApplicationType>(applicationTypeId);
        }

        public void RowDeleteApplicationModule(int applicationModuleId)
        {
            this.RowDelete<ApplicationModule>(applicationModuleId);
        }

        public ApplicationModule AddNewApplicationModule(ApplicationModule newAppModule)
        {
            this.Add<ApplicationModule, int>(newAppModule);
            return newAppModule;
        }

        public ApplicationInstance AttachToApplicationAtCompany(int companyId, int applicationId, string applicationTagName)
        {
            var applicationInstance = new ApplicationInstance
            {
                CompanyId = companyId,
                ApplicationId = applicationId,
                ApplicationTagName = applicationTagName
            };

            this.Add<ApplicationInstance, int>(applicationInstance);

            return applicationInstance;
        } 
        
        public List<ApplicationInstance> GetApplicationsOfCompany(int companyId, bool isActive = true)
        {
            return GetAll<ApplicationInstance>(x => x.CompanyId == companyId).ToList();
        }

        public List<ApplicationInstance> GetApplicationsOfCompanies(bool isActive = true)
        {
            return GetAll<ApplicationInstance>().ToList();
        }

        public void RemoveApplicationFromCompany(int applicationInstanceId)
        {
            this.RowDelete<ApplicationInstance>(applicationInstanceId);
        }
    }
}