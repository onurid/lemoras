using Lemoras.Remora.Kernel.Business.Base;
using Lemoras.Remora.Kernel.Business.SystemModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Kernel.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/kernel/page-property")]
    [Authorize()]
    public class PagePropertyController : BaseApiController<IPageService>
    {
        [HttpGet]
        public Result Get()
        {
            var pageProperties = service.GetPageProperties();
            return Result.Ok(pageProperties);
        }

        [HttpPost]
        public Result Post([FromBody] PageContract contract)
        {
            var pageProperty = service.AddPageProperty();
            return Result.Ok(pageProperty);
        }

        [HttpDelete("{pagePropertyId}")]
        public Result Delete(int pagePropertyId)
        {
            service.DeletePageProperty(pagePropertyId);
            return Result.Ok();
        }
    }
}