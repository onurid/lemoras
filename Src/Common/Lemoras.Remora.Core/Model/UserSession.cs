using System;
using System.Collections.Generic;

namespace Lemoras.Remora.Core.Model
{
    public class UserSession
    {
        public int ApplicationInsId { get; set; }
        public int ApplicationId { get; set; }
        public object UserId { get; set; }
        public DateTime ExprDate { get; set; }

        public string UserName { get; set; }

        public string DatabaseName { get;set; }
        public string ConnectionString { get; set; }
        
        public int RoleId { get; set; }

        public IEnumerable<int> ModuleIds { get; set; }
    }
}
