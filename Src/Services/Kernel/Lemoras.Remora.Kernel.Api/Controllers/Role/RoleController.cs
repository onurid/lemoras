using Lemoras.Remora.Kernel.Business.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Kernel.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/kernel/role")]
    [Authorize()]
    public class RoleController : BaseApiController<ISystemService>
    {
        [HttpGet]
        public Result Get()
        {
            var roles = service.GetRoles();
            return Result.Ok(roles);
        }
    }
}