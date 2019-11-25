using Lemoras.Remora.Admin.Business;
using Lemoras.Remora.Admin.Business.SystemModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core;

namespace Lemoras.Remora.Admin.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/admin/company")]
	[Authorize()]
	public class CompanyController : BaseApiController<ICompanyService>
    {
        [HttpGet]
        public Result Get()
        {
            var companies = service.GetCompanies();
            return Result.Ok(companies);
        }

        [HttpGet("{companyId}")]
        public Result Get(int companyId)
        {
            var company = service.GetCompany(companyId);
            return Result.Ok(company);
        }

        [HttpPost]
        public Result Post([FromBody] CompanyContract contract)
        {
            var company = service.AddNewCompany(contract.CompanyName);
            return Result.Ok(company.Id);
        }

        [HttpPut("{companyId}")]
        public Result Put(int companyId, [FromBody] CompanyContract contract)
        {
            service.UpdateCompany(companyId, contract.CompanyName);
            return Result.Ok();
        }

        [HttpDelete("{companyId}")]
        public Result Delete(int companyId)
        {
            service.DeleteCompany(companyId);
            return Result.Ok();
        }
    }
}