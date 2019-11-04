﻿using Lemoras.Remora.Kernel.Business.Base;
using Lemoras.Remora.Kernel.Business.SystemModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Kernel.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/kernel/page-detail")]
    [Authorize()]
    public class PageDetailController : BaseApiController<IPageService>
    {
        [HttpGet]
        public Result Get()
        {
            var pageDetails = service.GetPageDetails();
            return Result.Ok(pageDetails);
        }

        [HttpPost]
        public Result Post([FromBody] PageContract contract)
        {
            var pageDetail = service.AddPageDetail();
            return Result.Ok(pageDetail.Id);
        }

        [HttpDelete("{pageDetailId}")]
        public Result Delete(int pageDetailId)
        {
            service.DeletePageDetail(pageDetailId);
            return Result.Ok();
        }
    }
}