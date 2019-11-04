using Lemoras.Remora.Core.Factory;
using Lemoras.Remora.Kernel.Business.Base;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Kernel.Business.Factory
{
    public interface IServiceFactory : IBaseServiceFactory, IScopedDependency
    {
        IUserService GetUserService();
        IApplicationService GetApplicationService();
        ICompanyService GetCompanyService();
        IMenuService GetMenuService();
        IPageService GetPageService();
    }
}
