using Lemoras.Remora.Admin.Business.ApplicationModel;
using Lemoras.Remora.Admin.Business.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Admin.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/admin/application-instance")]
    [Authorize()]
    public class ApplicationInstanceController : BaseApiController<IApplicationService>
    {
        [HttpGet]
        public Result Get()
        {
            var data = service.GetApplicationsOfCompanies();
            return Result.Ok(data);
        }

        [HttpGet("{companyId}")]
        public Result Get(int companyId)
        {
            var applicationInstances = service.GetApplicationsOfCompany(companyId);
            return Result.Ok(applicationInstances);
        }

        [HttpDelete("{applicationInstanceId}")]
        public Result Delete(int applicationInstanceId)
        {
            service.RemoveApplicationFromCompany(applicationInstanceId);
            return Result.Ok();
        }

        [HttpPost]
        public Result Post([FromBody] ApplicationCompanyContract contract)
        {
            var data = service.AttachToApplicationAtCompany(contract);
            return Result.Ok(null, data.Id);
        }
    }
}