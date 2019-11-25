using Lemoras.Remora.Api.Controllers;
using Lemoras.Remora.Api.Models;
using Lemoras.Remora.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Admin.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/kernel/business-logic")]
    [Authorize()]
    public class BusinessLogicController : BaseApiController<IKernelService>
    {
        [HttpGet]
        public Result Get()
        {
            var businessLogics = service.GetBusinessLogics();
            return Result.Ok(businessLogics);
        }

        [HttpPost]
        public Result Post([FromBody] BusinessLogicContract contract)
        {
            var businessLogic = service.AddNewBusinessLogic(contract.BusinessLogicName, 
                contract.BusinessServiceId, contract.UniqueKey);
            return Result.Ok(businessLogic.Id);
        }

        [HttpDelete("{businessLogicId}")]
        public Result Delete(int businessLogicId)
        {
            service.DeleteBusinessLogic(businessLogicId);
            return Result.Ok();
        }
    }
}