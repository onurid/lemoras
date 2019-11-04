using System.Collections.Generic;
using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Kernel.Domain.Application
{
    public class ApplicationType : Entity<int>, IApplicationModelKey
    {
        public string ApplicationTypeName { get; set; }
        public bool IsBackOffice { get; set; }

        public virtual List<Application> Applications { get; set; }
    }
}