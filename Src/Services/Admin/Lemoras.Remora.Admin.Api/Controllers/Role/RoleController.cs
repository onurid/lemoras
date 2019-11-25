using Lemoras.Remora.Admin.Business.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Admin.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/admin/role")]
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