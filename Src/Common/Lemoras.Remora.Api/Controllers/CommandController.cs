using Lemoras.Remora.Api.Controllers;
using Lemoras.Remora.Api.Models;
using Lemoras.Remora.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Admin.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/kernel/command")]
    [Authorize()]
    public class CommandController : BaseApiController<IKernelService>
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