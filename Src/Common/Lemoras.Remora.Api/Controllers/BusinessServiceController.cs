using Lemoras.Remora.Api.Controllers;
using Lemoras.Remora.Api.Models;
using Lemoras.Remora.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Admin.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/kernel/business-service")]
    [Authorize()]
    public class BusinessServiceController : BaseApiController<IKernelService>
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
            var businessService = service.AddNewBusinessService(contract.BusinessServiceName, contract.BusinessServiceKey);
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