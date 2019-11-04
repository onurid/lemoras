using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/ping")]
    public class PingController : Controller
    {
        [HttpGet]
        public Result Get()
        {
            return Result.Ok("Ping is okey..");
        }
    }
}