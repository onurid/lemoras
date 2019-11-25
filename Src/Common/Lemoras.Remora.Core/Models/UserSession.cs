using System;

namespace Lemoras.Remora.Core.Model
{
    public class UserSession
    {
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public object UserId { get; set; }
        public int ApplicationInsId { get; set; }
        public int ApplicationId { get; set; }
        public DateTime ExprDate { get; set; }        
    }
}
