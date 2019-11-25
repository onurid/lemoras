using System.Collections.Generic;
using System.Linq;
using Lemoras.Remora.Admin.Domain.BoundedContext;
using Lemoras.Remora.Admin.Domain.Microservice;
using OYASAR.Framework.Core.Abstract;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Admin.Infrastructure.Repositories.CommonContext
{
    public class MicroserviceRepository : BaseRepository<IEFRepository<ICommonContext>, IMicroserviceModelKey>, IMicroserviceRepository
    {
        public Microservice AddNewMicroservice(Microservice microservice, bool isPassive = true)
        {
            this.Add<Microservice, int>(microservice);
            return microservice;
        }
        
        public List<Microservice> GetMicroservices()
        {
            return GetAll<Microservice>().ToList();
        }

        public void RowDeleteMicroservice(int microserviceId)
        {
            this.RowDelete<Microservice>(microserviceId);
        }
    }
}