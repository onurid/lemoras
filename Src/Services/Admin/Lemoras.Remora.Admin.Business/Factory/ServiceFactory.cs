using Lemoras.Remora.Core.Factory;
using Lemoras.Remora.Admin.Business.Base;

namespace Lemoras.Remora.Admin.Business.Factory
{
    public class ServiceFactory : BaseServiceFactory, IServiceFactory
    {
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
