using Lemoras.Remora.Admin.Business.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Admin.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/admin/user-company")]
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