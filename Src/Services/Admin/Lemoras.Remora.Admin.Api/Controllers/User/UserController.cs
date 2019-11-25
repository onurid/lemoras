using Lemoras.Remora.Core;
using Lemoras.Remora.Admin.Business.Base;
using Lemoras.Remora.Admin.Business.UserModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Admin.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/admin/user")]
    [Authorize()]
    public class UserController : BaseApiController<IUserService>
    {
        [HttpGet]
        public Result Get()
        {
            var users = service.GetUsers();
            return Result.Ok(users);
        }

        [HttpGet("{userId}")]
        public Result Get(int userId)
        {
            var user = service.GetUser(userId);
            if (user == null)
                return Result.Error("Not Found");

            return Result.Ok(user);
        }

        [HttpPost]
        public Result Post([FromBody] AddNewUserContract contract)
        {
            var newUser = service.AddNewUser(contract);

            return Result.Ok(Constants.Message.Sucess.RegisteredUser, newUser.Id);
        }

        [HttpPut]
        public Result Put([FromBody] UpdateUserContract contract)
        {
            service.UpdateUser(contract);
            return Result.Ok();
        }

        [HttpDelete("{userId}")]
        public Result Delete(int userId)
        {
            service.DeleteUser(userId);
            return Result.Ok();
        }
    }
}