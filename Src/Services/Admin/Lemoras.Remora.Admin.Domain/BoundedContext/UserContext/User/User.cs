using System;
using System.Collections.Generic;
using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Admin.Domain.User
{
    public class User : Entity<int>, IUserModelKey
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool? Active { get; set; }
        public DateTime? LastLogindate { get; set; }

        public virtual List<UserRole> UserRoles { get; set; }
    }
}
