using Lemoras.Remora.Admin.Business.Base;
using Lemoras.Remora.Admin.Business.SystemModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Admin.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/admin/module")]
    [Authorize()]
    public class ModuleController : BaseApiController<ISystemService>
    {
        [HttpPost]
        public Result Post([FromBody] ModuleContract contract)
        {
            var module = service.AddNewModule(contract.ModuleName);
            return Result.Ok(module.Id);
        }

        [HttpDelete("{moduleId}")]
        public Result Delete(int moduleId)
        {
            service.DeleteModule(moduleId);
            return Result.Ok();
        }

        [HttpGet]
        public Result Get()
        {
            var modules = service.GetModules();
            return Result.Ok(modules);
        }
    }
}