using System.Collections.Generic;
using System.Linq;
using Lemoras.Remora.Core;
using Lemoras.Remora.Kernel.Business.Base;
using Lemoras.Remora.Kernel.Domain.Application;
using Lemoras.Remora.Kernel.Domain.Company;
using Lemoras.Remora.Kernel.Domain.Role;
using OYASAR.Framework.Core.Extensions;
using OYASAR.Framework.Core.Utils;

namespace Lemoras.Remora.Kernel.Business
{
    public class LimitedApplicationService : BaseApplicationService, IApplicationService
    {
        private readonly int appInsId;

        public LimitedApplicationService() : base()
        {
            appInsId = Invoke<IWorkContextService>.Call().GetCurrentUserSession().ApplicationInsId;
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
                         where ca.Id == appInsId
                         select new {
                             Id = ca.Id,
                             CompanyName = c.CompanyName,
                             ApplicationName = a.ApplicationName,
                             ApplicationTagName = ca.ApplicationTagName
                         }).ToList();

            return data;
        }
        public override IEnumerable<Role> GetRolesOfApplication(int applicationId)
        {
            var repo = repositories.GetRoleRepository();

            var appRepo = repositories.GetApplicationRepository();

            var applicationInstance = appRepo.GetAll<ApplicationInstance>(x=> x.Id == appInsId)
                .SingleOrDefault();

            var data = repo.GetRolesOfApplication(applicationInstance.ApplicationId);

            foreach (var item in data)
            {
                item.RoleAuthorises = null;
            }

            return data;
        }
    }
}
