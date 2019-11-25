using System.Collections.Generic;
using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Admin.Domain.Microservice
{
    public class Microservice : Entity<int>, IMicroserviceModelKey
    {        
        public string MicroserviceName { get; set; }
        public string UniqueKey { get; set; }
    }
}