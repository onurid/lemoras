using System.Collections.Generic;
using Lemoras.Remora.Kernel.Domain.Factory;
using Lemoras.Remora.Kernel.Domain.Menu;
using OYASAR.Framework.Core.Exceptions;
using OYASAR.Framework.Core.Utils;
using Constants = Lemoras.Remora.Core.Constants;

namespace Lemoras.Remora.Kernel.Business.Base
{
    public abstract class BaseMenuService : IBaseMenuService
    {
        protected readonly IRepositoryFactory repositories;

        public BaseMenuService()
        {
            repositories = Invoke<IRepositoryFactory>.Call();
        }

        public virtual Menu AddMenu()
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual MenuIcon AddMenuIcon()
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual MenuType AddMenuType()
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual MenuValue AddMenuValue()
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual void DeleteMenu(int menuId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual void DeleteMenuIcon(int menuIconId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual void DeleteMenuType(int menuTypeId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual void DeleteMenuValue(int menuValueId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual IEnumerable<MenuIcon> GetMenuIcons()
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual IEnumerable<Menu> GetMenus()
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual IEnumerable<MenuType> GetMenuTypes()
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual IEnumerable<MenuValue> GetMenuValues()
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }
    }
}
