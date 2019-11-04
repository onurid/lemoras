using System.Collections.Generic;
using System.Linq;
using Lemoras.Remora.Kernel.Domain.BoundedContext;
using Lemoras.Remora.Kernel.Domain.Microservice;
using OYASAR.Framework.Core.Abstract;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Kernel.Infrastructure.Repositories.CommonContext
{
    public class MicroserviceRepository : BaseRepository<IEFRepository<ICommonContext>, IMicroserviceModelKey>, IMicroserviceRepository
    {
        public MicroserviceModule AttachToModuleAtMicroservice(int microserviceId, int moduleId)
        {
            var microserviceModule = new MicroserviceModule
            {
                MicroserviceId = microserviceId,
                ModuleId = moduleId
            };
            this.Add<MicroserviceModule, int>(microserviceModule);

            return microserviceModule;
        }

        public Microservice AddNewMicroservice(Microservice microservice, bool isPassive = true)
        {
            this.Add<Microservice, int>(microservice);
            return microservice;
        }

        public List<int> GetMicroserviceModules(string uniqueKey)
        {
            return (from m in GetAll<Microservice>(x => x.UniqueKey == uniqueKey)
                    join mm in GetAll<MicroserviceModule>() on m.Id equals mm.MicroserviceId
                    select mm.ModuleId).ToList();
        }

        public List<MicroserviceModule> GetMicroserviceModules()
        {
            return GetAll<MicroserviceModule>().ToList();
        }

        public List<Microservice> GetMicroservices()
        {
            return GetAll<Microservice>().ToList();
        }

        public void RowDeleteMicroservice(int microserviceId)
        {
            this.RowDelete<Microservice>(microserviceId);
        }

        public void RowDeleteMicroserviceModule(int microserviceModuleId)
        {
            this.RowDelete<MicroserviceModule>(microserviceModuleId);
        }
    }
}