using System.Collections.Generic;
using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Kernel.Domain.Menu
{
    public class MenuValue : Entity<int>, IMenuModelKey
    {
        public int LanguageId { get; set; }
        public string MenuValueName { get; set; }

        public virtual List<Menu> Menus { get; set; }
    }
}