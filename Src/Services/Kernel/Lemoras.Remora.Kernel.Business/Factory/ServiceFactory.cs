using Lemoras.Remora.Core.Factory;
using Lemoras.Remora.Kernel.Business.Base;

namespace Lemoras.Remora.Kernel.Business.Factory
{
    public class ServiceFactory : BaseServiceFactory, IServiceFactory
    {
        public IUserService GetUserService()
        {
            return GetService<IUserService>();
        }

        public IApplicationService GetApplicationService()
        {
            return GetService<IApplicationService>();
        }

        public ICompanyService GetCompanyService()
        {
            return GetService<ICompanyService>();
        }
      
        public IMenuService GetMenuService()
        {
            return GetService<IMenuService>();
        }

        public IPageService GetPageService()
        {
            return GetService<IPageService>();
        }
    }
}
