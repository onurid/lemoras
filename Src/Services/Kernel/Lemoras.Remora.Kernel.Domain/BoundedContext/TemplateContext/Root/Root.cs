using System.Collections.Generic;

namespace Lemoras.Remora.Kernel.Domain.Root
{
    public class Root
    {
        public string TitleName { get; set; }
		public string CompanyName { get; set; }

        public MenuList SearchBox { get; set; }
        public List<MenuList> NavList { get; set; }
        public List<MenuList> UserNavList { get; set; }
        public List<MenuList> FooterMenuList { get; set; }

        public Route Route { get; set; }
    }
}