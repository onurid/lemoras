using Lemoras.Remora.Kernel.Business.Base;
using Lemoras.Remora.Kernel.Business.SystemModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Kernel.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/kernel/command")]
    [Authorize()]
    public class CommandController : BaseApiController<ISystemService>
    {
        [HttpGet]
        public Result Get()
        {
            var commands = service.GetCommands();
            return Result.Ok(commands);
        }

        [HttpPost]
        public Result Post([FromBody] CommandContract contract)
        {
            var command = service.AddNewCommand(contract.CommandName, contract.BusinessServiceId);
            return Result.Ok(command.Id);
        }

        [HttpDelete("{commandId}")]
        public Result Delete(int commandId)
        {
            service.DeleteCommand(commandId);
            return Result.Ok();
        }
    }
}