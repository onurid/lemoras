using Lemoras.Remora.Kernel.Business.ApplicationModel;
using Lemoras.Remora.Kernel.Business.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Kernel.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/kernel/application-role")]
    [Authorize()]
    public class ApplicationRoleController : BaseApiController<IApplicationService>
    {   
        [HttpPost]
        public Result Post([FromBody] CreateRoleToApplicationContract contract)
        {
            var data = service.CreateRoleToApplication(contract.ApplicationId, contract.RoleName);
            return Result.Ok(data.Id);
        }

        [HttpDelete("{roleId}")]
        public Result Delete(int roleId)
        {
            service.RemoveRoleFromApplication(roleId);
            return Result.Ok();
        }

        [HttpGet("{applicationId}")]
        public Result Get(int applicationId)
        {
            var data = service.GetRolesOfApplication(applicationId);
            return Result.Ok(data);
        }
    }
}