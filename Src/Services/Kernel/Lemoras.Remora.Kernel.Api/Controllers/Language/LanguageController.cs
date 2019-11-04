using Lemoras.Remora.Kernel.Business.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Kernel.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/kernel/language")]
    [Authorize()]
    public class LanguageController : BaseApiController<ISystemService>
    {
        [HttpGet]
        public Result Get()
        {
            var languages = service.GetLanguages();
            return Result.Ok(languages);
        }

        [HttpPost]
        public Result Post([FromBody] string languageName)
        {
            var language = service.AddLanguage(languageName);
            return Result.Ok(language.Id);
        }

        [HttpDelete("{languageId}")]
        public Result Delete(int languageId)
        {
            service.DeleteLanguage(languageId);
            return Result.Ok();
        }
    }
}