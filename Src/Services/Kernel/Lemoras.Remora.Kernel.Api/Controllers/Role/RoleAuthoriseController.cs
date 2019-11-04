using Lemoras.Remora.Kernel.Business.Base;
using Lemoras.Remora.Kernel.Business.SystemModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Kernel.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/kernel/role-authorise")]
    [Authorize()]
    public class RoleAuthoriseController : BaseApiController<ISystemService>
    {
        [HttpPost]
        public Result Post([FromBody]RoleCommandContract contract)
        {
            var commandRole = service.AttachToCommandAtRole(contract.RoleId, contract.CommandId);
            return Result.Ok(commandRole.Id);
        }

        [HttpGet]
        public Result Get()
        {
            var roleAuthorises = service.GetRoleAuthorises();
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