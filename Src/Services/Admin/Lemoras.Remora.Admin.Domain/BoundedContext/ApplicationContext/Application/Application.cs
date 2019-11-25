﻿using System.Collections.Generic;
using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Admin.Domain.Application
{
    public class Application : Entity<int>, IApplicationModelKey
    {        
        public string ApplicationName { get; set; }
        public string ApplicationJS { get;set; }

        public int ApplicationTypeId { get; set; }
        public virtual ApplicationType ApplicationType { get; set; }

        public virtual List<ApplicationInstance> ApplicationInstances { get; set; }
    }
}