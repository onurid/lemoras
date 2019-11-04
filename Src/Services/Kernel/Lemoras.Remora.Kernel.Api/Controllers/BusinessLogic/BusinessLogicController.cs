using Lemoras.Remora.Kernel.Business.Base;
using Lemoras.Remora.Kernel.Business.SystemModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Kernel.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/kernel/business-logic")]
    [Authorize()]
    public class BusinessLogicController : BaseApiController<ISystemService>
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
            var businessLogic = service.AddNewBusinessLogic(contract);
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