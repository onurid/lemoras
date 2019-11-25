using Lemoras.Remora.Admin.Domain.Application;
using Lemoras.Remora.Admin.Domain.Company;
using Lemoras.Remora.Admin.Domain.Config;
using Lemoras.Remora.Admin.Domain.LanguageAggregate;
using Lemoras.Remora.Admin.Domain.MenuAggregate;
using Lemoras.Remora.Admin.Domain.Microservice;
using Lemoras.Remora.Admin.Domain.Module;
using Lemoras.Remora.Admin.Domain.Page;
using Lemoras.Remora.Admin.Domain.Role;
using Lemoras.Remora.Admin.Domain.Template;
using Lemoras.Remora.Admin.Domain.User;
using OYASAR.Framework.Core.Utils;

namespace Lemoras.Remora.Admin.Domain.Factory
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public IApplicationRepository GetApplicationRepository()
        {
            return Invoke<IApplicationRepository>.Call();
        }

        public ICompanyRepository GetCompanyRepository()
        {
            return Invoke<ICompanyRepository>.Call();
        }

        public IMicroserviceRepository GetMicroserviceRepository()
        {
            return Invoke<IMicroserviceRepository>.Call();
        }

        public IModuleRepository GetModuleRepository()
        {
            return Invoke<IModuleRepository>.Call();
        }

        public IPageRepository GetPageRepository()
        {
            return Invoke<IPageRepository>.Call();
        }

        public IRoleRepository GetRoleRepository()
        {
            return Invoke<IRoleRepository>.Call();
        }

        public IMenuRepository GetMenuRepository()
        {
            return Invoke<IMenuRepository>.Call();
        }

        public ITemplateRepository GetTemplateRepository()
        {
            return Invoke<ITemplateRepository>.Call();
        }

        public ILanguageRepository GetLanguageRepository()
        {
            return Invoke<ILanguageRepository>.Call();
        }

        public IUserRepository GetUserRepository()
        {
            return Invoke<IUserRepository>.Call();
        }

        public IConfigRepository GetConfigRepository()
        {
            return Invoke<IConfigRepository>.Call();
        }
    }
}
