using Lemoras.Remora.Kernel.Business.Base;
using Lemoras.Remora.Kernel.Business.SystemModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Kernel.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/kernel/microservice-module")]
    [Authorize()]
    public class MicroserviceModuleController : BaseApiController<ISystemService>
    {
        [HttpGet]
        public Result Get()
        {
            var microserviceModules = service.GetMicroserviceModules();
            return Result.Ok(microserviceModules);
        }

        [HttpPost]
        public Result Post([FromBody] MicroserviceModuleContract contract)
        {
            var microserviceModule = service.AttachToModuleAtMicroservice(contract.MicroserviceId, contract.ModuleId);
            return Result.Ok(microserviceModule.Id);
        }

        [HttpDelete("{microserviceModuleId}")]
        public Result Delete(int microserviceModuleId)
        {
            service.DeleteMicroserviceModule(microserviceModuleId);
            return Result.Ok();
        }
    }
}