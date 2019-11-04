using Lemoras.Remora.Kernel.Business.ApplicationModel;
using Lemoras.Remora.Kernel.Business.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Kernel.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/kernel/application-type")]
    [Authorize()]
    public class ApplicationTypeController : BaseApiController<IApplicationService>
    {
        [HttpPost]
        public Result Post([FromBody] AddNewApplicationTypeContract contract)
        {
            var data = service.AddNewApplicationType(contract.ApplicationTypeName, contract.IsBackoffice);
            return Result.Ok(data.Id);
        }

        [HttpGet]
        public Result Get()
        {
            var applicationService = service.GetApplicationTypes();
            return Result.Ok(applicationService);
        }

        [HttpDelete("{applicationTypeId}")]
        public Result Delete(int applicationTypeId)
        {
            service.DeleteApplicationType(applicationTypeId);
            return Result.Ok();
        }
    }
}