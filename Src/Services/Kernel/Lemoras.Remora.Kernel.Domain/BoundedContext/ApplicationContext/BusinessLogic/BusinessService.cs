using System.Collections.Generic;
using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Kernel.Domain.BusinessLogic
{
    public class BusinessService : Entity<int>, IBusinessLogicModelKey
    {        
        public string BusinessServiceName { get; set; }
        public string BusinessServiceKey { get; set; }

        public virtual List<BusinessLogic> BusinessLogics { get; set; }
    }
}