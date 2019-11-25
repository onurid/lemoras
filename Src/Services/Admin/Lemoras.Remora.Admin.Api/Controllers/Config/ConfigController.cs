using Lemoras.Remora.Admin.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Admin.Api.Controllers.Config
{
    [Produces("application/json")]
    [Route("api/admin/config")]
    [Authorize()]
    public class ConfigController : Remora.Api.Controllers.BaseApiController<IConfigService>
    {
        [HttpGet]
        public Result Get()
        {
            var config = service.GetConfig();
            return Result.Ok(config);
        }
    }
}