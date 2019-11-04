using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Kernel.Domain.BusinessLogic
{
    public class BusinessLogic : Entity<int>, IBusinessLogicModelKey
    {        
        public string BusinessLogicName { get; set; }
        public string UniqueKey { get; set; }
        public int BusinessServiceId { get; set; }

        public virtual BusinessService BusinessService { get; set; }
    }
}