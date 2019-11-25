using System.Collections.Generic;
using Lemoras.Remora.Admin.Business.Base;
using Lemoras.Remora.Admin.Domain.Menu;

namespace Lemoras.Remora.Admin.Business
{
    public class MenuService : BaseMenuService, IMenuService
    {
        public override Menu AddMenu()
        {
            return default(Menu);
        }

        public override MenuIcon AddMenuIcon()
        {
            return default(MenuIcon);
        }

        public override MenuType AddMenuType()
        {
            return default(MenuType);
        }

        public override MenuValue AddMenuValue()
        {
            return default(MenuValue);
        }

        public override void DeleteMenu(int menuId)
        {
        }

        public override void DeleteMenuIcon(int menuIconId)
        {
        }

        public override void DeleteMenuType(int menuTypeId)
        {
        }

        public override void DeleteMenuValue(int menuValueId)
        {
        }

        public override IEnumerable<MenuIcon> GetMenuIcons()
        {
            return default(IEnumerable<MenuIcon>);
        }

        public override IEnumerable<Menu> GetMenus()
        {
            return default(IEnumerable<Menu>);
        }

        public override IEnumerable<MenuType> GetMenuTypes()
        {
            return default(IEnumerable<MenuType>);
        }

        public override IEnumerable<MenuValue> GetMenuValues()
        {
            return default(IEnumerable<MenuValue>);
        }
    }
}
