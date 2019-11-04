﻿using Lemoras.Remora.Kernel.Business.Base;
using Lemoras.Remora.Kernel.Business.SystemModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Kernel.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/kernel/menu-icon")]
    [Authorize()]
    public class MenuIconController : BaseApiController<IMenuService>
    {
        [HttpPost]
        public Result Post([FromBody]RoleCommandContract contract)
        {
            var menuIcon = service.AddMenuIcon();
            return Result.Ok(menuIcon.Id);
        }

        [HttpGet]
        public Result Get()
        {
            var menuIcons = service.GetMenuIcons();
            return Result.Ok(menuIcons);
        }

        [HttpDelete("{menuIconId}")]
        public Result Delete(int menuIconId)
        {
            service.DeleteMenuIcon(menuIconId);
            return Result.Ok();
        }
    }
}