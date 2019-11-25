using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Admin.Domain.Company
{
    public class Company : Entity<int>, ICompanyModelKey
    {        
        public string CompanyName { get; set; }
    }
}