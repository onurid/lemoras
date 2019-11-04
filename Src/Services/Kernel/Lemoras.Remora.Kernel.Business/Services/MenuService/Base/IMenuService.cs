using System.Collections.Generic;
using Lemoras.Remora.Core.Attribute;
using Lemoras.Remora.Core.Interceptor;
using Lemoras.Remora.Kernel.Domain.Menu;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Kernel.Business.Base
{
    public interface IMenuService : IBaseMenuService, IRoleInterceptor, ITransientDependency
    {
    }

    public interface IBaseMenuService
    {
        [RoleSet("GetMenus")]
        IEnumerable<Menu> GetMenus();

        [RoleSet("AddMenu")]
        Menu AddMenu();

        [RoleSet("DeleteMenu")]
        void DeleteMenu(int menuId);

        [RoleSet("GetMenuIcons")]
        IEnumerable<MenuIcon> GetMenuIcons();

        [RoleSet("AddMenuIcon")]
        MenuIcon AddMenuIcon();

        [RoleSet("DeleteMenuIcon")]
        void DeleteMenuIcon(int menuIconId);

        [RoleSet("GetMenuTypes")]
        IEnumerable<MenuType> GetMenuTypes();

        [RoleSet("AddMenuType")]
        MenuType AddMenuType();

        [RoleSet("DeleteMenuType")]
        void DeleteMenuType(int menuTypeId);

        [RoleSet("GetMenuValues")]
        IEnumerable<MenuValue> GetMenuValues();

        [RoleSet("AddMenuValue")]
        MenuValue AddMenuValue();

        [RoleSet("DeleteMenuValue")]
        void DeleteMenuValue(int menuValueId);
    }
}
