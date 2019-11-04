using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Kernel.Domain.Menu
{
    public class Menu : Entity<int>, IMenuModelKey
    {
        public int RoleId { get; set; }
        public int MenuTypeId { get; set; }
        public int? ParentMenuId { get; set; }
        public int PageId { get; set; }
        public int MenuIconId { get; set; }
        public int MenuValueId { get; set; }
        public int Index { get; set; }
        public string Label { get; set; }
        public string Tag { get; set; }
        
        public virtual MenuType MenuType { get; set; }
        public virtual MenuIcon MenuIcon { get; set; }
        public virtual MenuValue MenuValue { get; set; }
    }
} 