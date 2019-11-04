using Lemoras.Remora.Kernel.Business.Base;
using Lemoras.Remora.Kernel.Business.SystemModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Kernel.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/kernel/microservice")]
    [Authorize()]
    public class MicroserviceController : BaseApiController<ISystemService>
    {
        [HttpPost]
        public Result Post([FromBody] MicroserviceContract contract)
        {
            var microservice = service.AddNewMicroservice(contract.MicroserviceName, contract.UniqueKey);
            return Result.Ok(microservice.Id);
        }

        [HttpDelete("{microserviceId}")]
        public Result Delete(int microserviceId)
        {
            service.DeleteMicroservice(microserviceId);
            return Result.Ok();
        }

        [HttpGet]
        public Result Get()
        {
            var microservices = service.GetMicroservices();
            return Result.Ok(microservices);
        }
    }
}