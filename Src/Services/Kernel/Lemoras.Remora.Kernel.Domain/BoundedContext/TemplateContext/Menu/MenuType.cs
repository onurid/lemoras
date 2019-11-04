using System.Collections.Generic;
using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Kernel.Domain.Menu
{
    public class MenuType : Entity<int>, IMenuModelKey
    {
        public int ApplicationId { get; set; }
        public string MenuTypeName { get; set; }

        public virtual List<Menu> Menus { get; set; }
    }
}