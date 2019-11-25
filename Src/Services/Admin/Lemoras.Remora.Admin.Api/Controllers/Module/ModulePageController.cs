using Lemoras.Remora.Admin.Business.Base;
using Lemoras.Remora.Admin.Business.SystemModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Admin.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/admin/module-page")]
    [Authorize()]
    public class ModulePageController : BaseApiController<IApplicationService>
    {
        [HttpPost]
        public Result Post([FromBody] ModulePageContract contract)
        {
            var modulePage = service.AttachToPageAtModule(contract.PageId, contract.ApplicationModuleId);
            return Result.Ok(modulePage.Id);
        }

        [HttpGet]
        public Result Get()
        {
            var moduleRoutes = service.GetModuleRoutes();
            return Result.Ok(moduleRoutes);
        }
    }
}