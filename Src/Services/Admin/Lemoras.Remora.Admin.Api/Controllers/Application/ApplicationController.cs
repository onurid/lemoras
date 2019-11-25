﻿using Lemoras.Remora.Admin.Business.ApplicationModel;
using Lemoras.Remora.Admin.Business.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Admin.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/admin/application")]
    [Authorize()]
    public class ApplicationController : BaseApiController<IApplicationService>
    {
        [HttpGet]
        public Result Get()
        {
            var applications = service.GetApplications();
            return Result.Ok(applications);
        }

        [HttpPost]
        public Result Post([FromBody] AddNewApplicationContract contract)
        {
            var data = service.AddNewApplication(contract.ApplicationName, contract.ApplicationTypeId);
            return Result.Ok("success", data.Id);
        }

        [HttpDelete("{applicationId}")]
        public Result Delete(int applicationId)
        {
            service.DeleteApplication(applicationId);
            return Result.Ok();
        }
    }
}