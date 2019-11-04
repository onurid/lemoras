using Lemoras.Remora.Kernel.Business.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Kernel.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/kernel/user-application")]
	[Authorize()]
	public class UserApplicationController : BaseApiController<IUserService>
    {
        [HttpGet("{applicationId}")]
        public Result Get(int applicationId)
        {
            var users = service.GetUsersOfApplication(applicationId);
            return Result.Ok(users);
        }     
    }
}