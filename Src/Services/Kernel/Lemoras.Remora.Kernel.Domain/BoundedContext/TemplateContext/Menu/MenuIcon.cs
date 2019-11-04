using System.Collections.Generic;
using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Kernel.Domain.Menu
{
    public class MenuIcon : Entity<int>, IMenuModelKey
    {
        public int TemplateId { get; set; }
        public string MenuIconValue { get; set; }

        public virtual List<Menu> Menus { get; set; }
    }
}