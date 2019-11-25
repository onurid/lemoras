using Lemoras.Remora.Admin.Business.Base;
using Lemoras.Remora.Admin.Business.SystemModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Admin.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/admin/microservice")]
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