using Lemoras.Remora.Kernel.Business.Base;
using Lemoras.Remora.Kernel.Business.SystemModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Kernel.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/kernel/template")]
    [Authorize()]
    public class TemplateController : BaseApiController<ISystemService>
    {
        [HttpGet]
        public Result Get()
        {
            var templates = service.GetTemplates();
            return Result.Ok(templates);
        }

        [HttpPost]
        public Result Post([FromBody] TemplateContract contract)
        {
            var template = service.AddTemplate(contract.TemplateName, contract.TemplateUrl);
            return Result.Ok(template.Id);
        }

        [HttpDelete("{templateId}")]
        public Result Delete(int templateId)
        {
            service.DeleteTemplate(templateId);
            return Result.Ok();
        }
    }
}