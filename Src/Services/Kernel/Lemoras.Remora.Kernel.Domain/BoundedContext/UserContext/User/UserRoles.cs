using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Kernel.Domain.User
{
    public class UserRole : Entity<int>, IUserModelKey
    {
        public int UserId { get; set; }
        public int ApplicationInstanceId { get; set; }
        public int RoleId { get; set; }

        public virtual User User { get; set; }
    }
}