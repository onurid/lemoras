using Lemoras.Remora.Kernel.Business.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Kernel.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/kernel/role-application")]
    [Authorize()]
    public class RoleApplicationController : BaseApiController<IApplicationService>
    {
        [HttpGet("{roleId}")]
        public Result Get(int roleId)
        {
            var data = service.GetApplicationsOfRole(roleId);
            return Result.Ok(data);
        }
    }
}