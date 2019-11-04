using Lemoras.Remora.Kernel.Business.Base;
using Lemoras.Remora.Kernel.Business.SystemModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Kernel.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/kernel/module-page")]
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