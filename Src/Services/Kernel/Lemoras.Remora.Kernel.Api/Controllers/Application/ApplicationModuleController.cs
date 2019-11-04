using Lemoras.Remora.Kernel.Business.ApplicationModel;
using Lemoras.Remora.Kernel.Business.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Kernel.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/kernel/application-module")]
    [Authorize()]
    public class ApplicationModuleController : BaseApiController<IApplicationService>
    {
        [HttpGet]
        public Result Get()
        {
            var applicationModules = service.GetApplicationModules();
            return Result.Ok(applicationModules);
        }

        [HttpPost]
        public Result Post([FromBody] ApplicationModuleContract contract)
        {
            var applicationModule = service.AddNewApplicationModule(contract);
            return Result.Ok(null, applicationModule.Id);
        }

        [HttpDelete("{applicationModuleId}")]
        public Result Delete(int applicationModuleId)
        {
            service.DeleteApplicationModule(applicationModuleId);
            return Result.Ok();
        }
    }
}