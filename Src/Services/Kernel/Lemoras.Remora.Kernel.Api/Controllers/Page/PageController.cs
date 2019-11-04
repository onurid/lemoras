using Lemoras.Remora.Kernel.Business.Base;
using Lemoras.Remora.Kernel.Business.SystemModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Kernel.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/kernel/page")]
    [Authorize()]
    public class PageController : BaseApiController<IPageService>
    {
        [HttpGet]
        public Result Get()
        {
            var pages = service.GetPages();
            return Result.Ok(pages);
        }

        [HttpPost]
        public Result Post([FromBody] PageContract contract)
        {
            var page = service.AddPage();
            return Result.Ok(page.Id);
        }

        [HttpDelete("{pageId}")]
        public Result Delete(int pageId)
        {
            service.DeletePage(pageId);
            return Result.Ok();
        }
    }
}