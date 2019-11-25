using System.Collections.Generic;
using Lemoras.Remora.Core.Attribute;
using Lemoras.Remora.Core.Interfaces;
using Lemoras.Remora.Admin.Domain.Company;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Admin.Business
{
    public interface ICompanyService : IRoleInterceptor, ITransientDependency
    {
        [RoleSet("AddNewCompany")]
        Company AddNewCompany(string companyName);

        [RoleSet("DeleteCompany")]
        void DeleteCompany(int companyId);

        [RoleSet("UpdateCompany")]
        void UpdateCompany(int companyId, string companyName);

        [RoleSet("GetCompanies")]
        IEnumerable<Company> GetCompanies();

        [RoleSet("GetCompany")]
        Company GetCompany(int companyId);
    }
}
