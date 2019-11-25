using System.Linq;
using Lemoras.Remora.Core.Interfaces;
using Lemoras.Remora.Admin.Business.Base;
using Lemoras.Remora.Admin.Domain.Application;
using Lemoras.Remora.Admin.Domain.Company;
using OYASAR.Framework.Core.Extensions;
using OYASAR.Framework.Core.Utils;

namespace Lemoras.Remora.Admin.Business
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
    }
}
