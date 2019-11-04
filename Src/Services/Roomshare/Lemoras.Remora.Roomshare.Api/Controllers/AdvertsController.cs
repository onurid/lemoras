using Lemoras.Remora.Api.Controllers;
using Lemoras.Remora.Roomshare.Api.Models;
using Lemoras.Remora.Roomshare.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Kernel.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/roomshare/[controller]")]
    [Authorize()]
    public class AdvertsController : BaseApiController<IAdvertService>
    {
        [HttpGet]
        public Result GetAdverts()
        {
            var applications = service.GetAdverts();
            return Result.Ok(applications);
        }

        [HttpPost]
        public Result PostAdverts(PostAdvertRequest request)
        {
            var applications = service.CreateAdvert(request.AdvertType, request.HouseId);
            return Result.Ok(applications);
        }
    }
}