using System.Collections.Generic;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Kernel.Domain.Microservice
{
    public interface IMicroserviceRepository : IBaseRepository<IMicroserviceModelKey>, ITransientDependency
    {
        List<int> GetMicroserviceModules(string uniqueKey);
        Microservice AddNewMicroservice(Microservice microservice, bool isPassive = true);
        MicroserviceModule AttachToModuleAtMicroservice(int microserviceId, int moduleId);
        void RowDeleteMicroservice(int microserviceId);
        List<MicroserviceModule> GetMicroserviceModules();
        List<Microservice> GetMicroservices();
        void RowDeleteMicroserviceModule(int microserviceModuleId);
    }
}