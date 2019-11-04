using System.Collections.Generic;
using System.Linq;
using Lemoras.Remora.Kernel.Domain.BoundedContext;
using Lemoras.Remora.Kernel.Domain.BusinessLogic;
using OYASAR.Framework.Core.Abstract;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Kernel.Infrastructure.Repositories.ApplicationContext
{
    public class BusinessLogicRepository : BaseRepository<IEFRepository<IApplicationContext>, IBusinessLogicModelKey>, IBusinessLogicRepository
    {
        public BusinessLogic AddNewBusinessLogic(BusinessLogic businessLogic, bool isPassive = true)
        {
            this.Add<BusinessLogic, int>(businessLogic);
            return businessLogic;
        }

        public IQueryable<BusinessService> GetBusinessServicesbyServiceKey(string serviceKey)
        {
            return GetAll<BusinessService>(x => x.BusinessServiceKey == serviceKey);
        }

        public void RowDeleteBusinessLogic(int businessLogicId)
        {
            this.RowDelete<BusinessLogic>(businessLogicId);
        }

        public List<BusinessLogic> GetBusinessLogics()
        {
            return GetAll<BusinessLogic>().ToList();
        }
    }
}