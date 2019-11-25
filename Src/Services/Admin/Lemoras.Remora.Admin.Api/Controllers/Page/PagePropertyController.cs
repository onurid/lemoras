using Lemoras.Remora.Admin.Business.Base;
using Lemoras.Remora.Admin.Business.SystemModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Admin.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/admin/page-property")]
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