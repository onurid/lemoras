using System.Collections.Generic;
using System.Linq;
using Lemoras.Remora.Kernel.Domain.BoundedContext;
using Lemoras.Remora.Kernel.Domain.Company;
using OYASAR.Framework.Core.Abstract;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Kernel.Infrastructure.Repositories.CommonContext
{
    public class CompanyRepository : BaseRepository<IEFRepository<ICommonContext>, ICompanyModelKey>, ICompanyRepository
    {
        public Company AddNewCompany(Company company, bool isPassive = true)
        {
            this.Add<Company, int>(company);
            return company;
        }

        public Company GetCompany(int companyId)
        {
            return GetByKey<Company>(companyId);
        }

        public List<Company> GetCompanies(bool isActive = true)
        {
            return GetAll<Company>().ToList();
        }

        public Company DeleteCompany(Company company)
        {
            this.Delete<Company, int>(company);
            return company;
        }

        public void RowDeleteCompany(int companyId)
        {
            this.RowDelete<Company>(companyId);
        }

        public Company UpdateCompany(Company company)
        {
            this.Edit<Company, int>(company);
            return company;
        }

        public bool IfExistsCompany(string companyName)
        {
            return GetAll<Company>(x => x.CompanyName == companyName).Any();
        }

        public bool IfExistsCompany(int companyId)
        {
            return GetAll<Company>(x => x.Id == companyId).Any();
        }
    }
}