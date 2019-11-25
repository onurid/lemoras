using Lemoras.Remora.Api.Controllers;
using Lemoras.Remora.Api.Models;
using Lemoras.Remora.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Admin.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/kernel/application-module")]
    [Authorize()]
    public class ApplicationModuleController : BaseApiController<IKernelService>
    {
        [HttpGet("{applicationId}")]
        public Result Get(int applicationId)
        {
            var applicationModules = service.GetApplicationModules(applicationId);
            return Result.Ok(applicationModules);
        }

        [HttpPost]
        public Result Post([FromBody] ApplicationModuleContract contract)
        {
            var applicationModule = service.AddNewApplicationModule(contract.ApplicationId, 
                contract.ModuleId, contract.BusinessLogicId);
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