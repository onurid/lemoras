using Lemoras.Remora.Api.Controllers;
using Lemoras.Remora.Api.Models;
using Lemoras.Remora.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Admin.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/kernel/role-authorise")]
    [Authorize()]
    public class RoleAuthoriseController : BaseApiController<IKernelService>
    {
        [HttpPost]
        public Result Post([FromBody]RoleCommandContract contract)
        {
            var commandRole = service.AttachToCommandAtRole(contract.RoleId, contract.CommandId);
            return Result.Ok(commandRole.Id);
        }

        [HttpGet("{roleId}")]
        public Result Get(int roleId)
        {
            var roleAuthorises = service.GetRoleAuthorises(roleId);
            return Result.Ok(roleAuthorises);
        }

        [HttpDelete("{roleAuthoriseId}")]
        public Result Delete(int roleAuthoriseId)
        {
            service.DeleteRoleAuthorise(roleAuthoriseId);
            return Result.Ok();
        }
    }
}