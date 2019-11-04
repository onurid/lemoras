using Lemoras.Remora.Kernel.Business.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Kernel.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/kernel/user-company")]
	[Authorize()]
	public class UserCompanyController : BaseApiController<IUserService>
    {
        [HttpGet("{companyId}")]
        public Result Get(int companyId)
        {
            var users = service.GetUsersOfCompany(companyId);
            return Result.Ok(users);
        }   
    }
}