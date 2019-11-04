using Lemoras.Remora.Kernel.Business.Base;
using Lemoras.Remora.Kernel.Business.SystemModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Kernel.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/kernel/menu")]
    [Authorize()]
    public class MenuController : BaseApiController<IMenuService>
    {
        [HttpPost]
        public Result Post([FromBody]RoleCommandContract contract)
        {
            var menu = service.AddMenu();
            return Result.Ok(menu.Id);
        }

        [HttpGet]
        public Result Get()
        {
            var menus = service.GetMenus();
            return Result.Ok(menus);
        }

        [HttpDelete("{menuId}")]
        public Result Delete(int menuId)
        {
            service.DeleteMenu(menuId);
            return Result.Ok();
        }
    }
}