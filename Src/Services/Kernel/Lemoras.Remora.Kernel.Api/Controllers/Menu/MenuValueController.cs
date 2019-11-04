using Lemoras.Remora.Kernel.Business.Base;
using Lemoras.Remora.Kernel.Business.SystemModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Kernel.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/kernel/menu-value")]
    [Authorize()]
    public class MenuValueController : BaseApiController<IMenuService>
    {
        [HttpPost]
        public Result Post([FromBody]RoleCommandContract contract)
        {
            var menuValue = service.AddMenuValue();
            return Result.Ok(menuValue.Id);
        }

        [HttpGet]
        public Result Get()
        {
            var menuValues = service.GetMenuValues();
            return Result.Ok(menuValues);
        }

        [HttpDelete("{menuValueId}")]
        public Result Delete(int menuValueId)
        {
            service.DeleteMenuValue(menuValueId);
            return Result.Ok();
        }
    }
}