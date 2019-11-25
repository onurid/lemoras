using System.Collections.Generic;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Admin.Domain.Microservice
{
    public interface IMicroserviceRepository : IBaseRepository<IMicroserviceModelKey>, ITransientDependency
    {
        Microservice AddNewMicroservice(Microservice microservice, bool isPassive = true);
        void RowDeleteMicroservice(int microserviceId);
        List<Microservice> GetMicroservices();
    }
}