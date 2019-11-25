using Lemoras.Remora.Core.Interfaces;
using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Core.Models.KernelContext
{
    public class BusinessLogic : Entity<int>, IKernelModelKey
    {
        public BusinessLogic(int businessServiceId, string businessLogicName, string uniqueKey)
        {
            this.BusinessServiceId = businessServiceId;
            this.BusinessLogicName = businessLogicName;
            this.UniqueKey = uniqueKey;
        }

        public string BusinessLogicName { get; protected set; }
        public string UniqueKey { get; protected set; }
        public int BusinessServiceId { get; protected set; }

        public BusinessService BusinessService { get; protected set; }
    }
}