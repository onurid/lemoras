using Lemoras.Remora.Admin.Business.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Admin.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/admin/role-application")]
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