using System.Collections.Generic;
using System.Linq;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Kernel.Domain.BusinessLogic
{
    public interface IBusinessLogicRepository : IBaseRepository<IBusinessLogicModelKey>, ITransientDependency
    {
        IQueryable<BusinessService> GetBusinessServicesbyServiceKey(string serviceKey);
        BusinessLogic AddNewBusinessLogic(BusinessLogic businessLogic, bool isPassive = true);
        void RowDeleteBusinessLogic(int businessLogicId);
        List<BusinessLogic> GetBusinessLogics();
    }
}