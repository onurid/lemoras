using Lemoras.Remora.Kernel.Domain.Application;
using Lemoras.Remora.Kernel.Domain.BusinessLogic;
using Lemoras.Remora.Kernel.Domain.Command;
using Lemoras.Remora.Kernel.Domain.Company;
using Lemoras.Remora.Kernel.Domain.LanguageAggregate;
using Lemoras.Remora.Kernel.Domain.MenuAggregate;
using Lemoras.Remora.Kernel.Domain.Microservice;
using Lemoras.Remora.Kernel.Domain.Module;
using Lemoras.Remora.Kernel.Domain.Page;
using Lemoras.Remora.Kernel.Domain.Role;
using Lemoras.Remora.Kernel.Domain.Template;
using Lemoras.Remora.Kernel.Domain.User;
using OYASAR.Framework.Core.Utils;

namespace Lemoras.Remora.Kernel.Domain.Factory
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public IApplicationRepository GetApplicationRepository()
        {
            return Invoke<IApplicationRepository>.Call();
        }

        public IBusinessLogicRepository GetBusinessLogicRepository()
        {
            return Invoke<IBusinessLogicRepository>.Call();
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

        public IUserRepository GetUserRepository()
        {
            return Invoke<IUserRepository>.Call();
        }

        public ICommandRepository GetCommandRepository()
        {
            return Invoke<ICommandRepository>.Call();
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
    }
}
