using System.Collections.Generic;
using Lemoras.Remora.Admin.Domain.Company;
using Lemoras.Remora.Admin.Domain.Factory;
using OYASAR.Framework.Core.Exceptions;
using OYASAR.Framework.Core.Extensions;
using OYASAR.Framework.Core.Utils;
using Constants = Lemoras.Remora.Core.Constants;

namespace Lemoras.Remora.Admin.Business
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepositoryFactory repositories;

        public CompanyService()
        {
            repositories = Invoke<IRepositoryFactory>.Call();
        }

        public Company AddNewCompany(string companyName)
        {
            var repo = repositories.GetCompanyRepository();

            var result = repo.AddNewCompany(
                new Company
                {
                    CompanyName = companyName
                }
            );
            repo.Save();

            return result;
        }

        public void UpdateCompany(int companyId, string companyName)
        {
            var repo = repositories.GetCompanyRepository();

            var company = repo.GetCompany(companyId)
                .ToCheck(Constants.Message.Exception.NotFound);

            company.CompanyName = companyName;

            repo.UpdateCompany(company);
            repo.Save();
        }

        public void DeleteCompany(int companyId)
        {
            var repo = repositories.GetCompanyRepository();

            if (!repo.IfExistsCompany(companyId))
                throw new BusinessException(Constants.Message.Exception.CompanyNotFound);

            repo.RowDeleteCompany(companyId);
            repo.Save();
        }

        public IEnumerable<Company> GetCompanies()
        {
            var repo = repositories.GetCompanyRepository();

            var data = repo.GetCompanies();

            return data;
        }

        public Company GetCompany(int companyId)
        {
            var repo = repositories.GetCompanyRepository();

            var data = repo.GetCompany(companyId);

            return data;
        }
    }
}
