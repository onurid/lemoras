namespace Lemoras.Remora.Kernel.Business.Helper
{
    //public static class MenuReverseHelper
    //{
    //    public static IList<MenuList> Reverse(IList<Page> pageList, IList<Menu> menuList)
    //    {
    //        var masterMenu = menuList.Where(x => x.ParentMenuId == null).ToList();

    //        var menuDtoList = masterMenu.MapTo<IList<MenuList>>();

    //        FillSubMenu(menuDtoList, menuList, pageList);

    //        return menuDtoList;
    //    }

    //    private static void FillSubMenu(IList<MenuList> menuDtoList, IList<Menu> menuList, IList<Page> pageList)
    //    {
    //        foreach (var item in menuDtoList)
    //        {
    //            var subMenu = menuList.Where(x => x.ParentMenuId == item.Id).ToList();

    //            var pageListTmp = pageList.Where(x => x.MenuId == item.Id).ToList();

    //            var pageDtoList = pageListTmp.MapTo<IList<MenuList>>();

    //            var subMenuDtoList = subMenu.MapTo<IList<MenuList>>();

    //            var itemList = subMenuDtoList.Concat(pageDtoList).ToList();

    //            item.List = itemList;

    //            FillSubMenu(subMenuDtoList, menuList, pageList);
    //        }
    //    }

    //private static IEnumerable<MenuList> Map(IList<Page> pages, IList<Menu> menus)
    //{
    //    foreach(var item in pages)
    //{
    //    var menu = menus.Where(x => x.Id == item.MenuId).SingleOrDefault();

    //    if (menu == null)
    //        continue;

    //        yield return new MenuList
    //        {
    //            Value = menu.Title,
    //            Icon = menu.Icon
    //        };
    //    }
    //}

    //private static IEnumerable<MenuList> Map(IList<Menu> menus)
    //{
    //    foreach (var item in menus)
    //    {
    //        yield return new MenuList
    //        {
    //            Value = item.Title,
    //            Icon = item.Icon
    //        };
    //    }
    //}

    //public static void Write()
    //{
    //    dynamic product = new JObject();

    //    product.Add("Entered", DateTime.Now);

    //    product.adad = "ada";
    //    product.ProductName = "Elbow Grease";
    //    product.Enabled = true;
    //    product.Price = 4.90m;
    //    product.StockCount = 9000;
    //    product.StockValue = 44100;

    //    product.Tags = new JArray("Real", "OnSale");

    //    Console.WriteLine(product.ToString());
    //    // {
    //    //   "ProductName": "Elbow Grease",
    //    //   "Enabled": true,
    //    //   "Price": 4.90,
    //    //   "StockCount": 9000,
    //    //   "StockValue": 44100,
    //    //   "Tags": [
    //    //     "Real",
    //    //     "OnSale"
    //    //   ]
    //    // }
    //}
}

