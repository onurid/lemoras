using Lemoras.Remora.Admin.Business.Base;
using Lemoras.Remora.Admin.Business.UserModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Admin.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/admin/user-role")]
	[Authorize()]
	public class UserRoleController : BaseApiController<IUserService>
    {
        [HttpGet]
        public Result Get()
        {
            var dataList = service.GetUserRole();
            return Result.Ok(dataList);
        }

        [HttpPost]
        public Result Post([FromBody] UserApplicationRoleContract contract)
        {
            var data = service.AttachToUserAtApplicationAndRole(contract);
            return Result.Ok("sucess", data.Id);
        }

        [HttpDelete("{userRoleId}")]
        public Result Delete(int userRoleId)
        {
            service.RemoveUserFromApplicationAndRole(userRoleId);
            return Result.Ok();
        }
    }
}