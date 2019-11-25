using Lemoras.Remora.Core.Interfaces;
using Lemoras.Remora.Admin.Business.Base;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Admin.Business.Factory
{
    public interface IServiceFactory : IBaseServiceFactory, IScopedDependency
    {
        IApplicationService GetApplicationService();
        ICompanyService GetCompanyService();
        IMenuService GetMenuService();
        IPageService GetPageService();
    }
}
