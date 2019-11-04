﻿using Lemoras.Remora.Kernel.Business.Base;
using Lemoras.Remora.Kernel.Business.UserModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Kernel.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/kernel/myprofile")]
	[Authorize()]
	public class MyProfileController : BaseApiController<IUserService>
    {
        [HttpGet]
        public Result Get()
        { 
            var data = service.GetMyProfile();
            if (data == null)
            {
                return Result.Error("Not Found");
            }

            return Result.Ok(data);
        }

        [HttpPut]
        public Result Put([FromBody] UpdateProfileContract contract)
        {
            service.UpdateProfile(contract);
            return Result.Ok();
        }
    }
}