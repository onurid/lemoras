using System.Collections.Generic;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Admin.Domain.Company
{
    public interface ICompanyRepository : IBaseRepository<ICompanyModelKey>, ITransientDependency
    {
        Company AddNewCompany(Company company, bool isPassive = true);
        Company GetCompany(int companyId);
        Company DeleteCompany(Company company);
        void RowDeleteCompany(int companyId);
        Company UpdateCompany(Company company);
        List<Company> GetCompanies(bool isActive = true);
        bool IfExistsCompany(string companyName);
        bool IfExistsCompany(int companyId);
    }
}