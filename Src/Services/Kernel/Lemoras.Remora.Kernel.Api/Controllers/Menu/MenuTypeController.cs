using Lemoras.Remora.Kernel.Business.Base;
using Lemoras.Remora.Kernel.Business.SystemModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Kernel.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/kernel/menu-type")]
    [Authorize()]
    public class MenuTypeController : BaseApiController<IMenuService>
    {
        [HttpPost]
        public Result Post([FromBody]RoleCommandContract contract)
        {
            var menuType = service.AddMenuType();
            return Result.Ok(menuType.Id);
        }

        [HttpGet]
        public Result Get()
        {
            var menuTypes = service.GetMenuTypes();
            return Result.Ok(menuTypes);
        }

        [HttpDelete("{menuTypeId}")]
        public Result Delete(int menuTypeId)
        {
            service.DeleteMenuType(menuTypeId);
            return Result.Ok();
        }
    }
}