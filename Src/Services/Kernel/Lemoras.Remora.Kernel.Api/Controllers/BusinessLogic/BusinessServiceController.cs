using Lemoras.Remora.Kernel.Business.Base;
using Lemoras.Remora.Kernel.Business.SystemModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Kernel.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/kernel/business-service")]
    [Authorize()]
    public class BusinessServiceController : BaseApiController<ISystemService>
    {
        [HttpGet]
        public Result Get()
        {
            var businessServices = service.GetBusinessServices();
            return Result.Ok(businessServices);
        }

        [HttpPost]
        public Result Post([FromBody] BusinessServiceContract contract)
        {
            var businessService = service.AddNewBusinessService(contract);
            return Result.Ok(businessService.Id);
        }

        [HttpDelete("{businessServiceId}")]
        public Result Delete(int businessServiceId)
        {
            service.DeleteBusinessService(businessServiceId);
            return Result.Ok();
        }
    }
}