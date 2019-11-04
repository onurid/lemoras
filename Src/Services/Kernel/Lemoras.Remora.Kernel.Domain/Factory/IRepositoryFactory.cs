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
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Kernel.Domain.Factory
{
    public interface IRepositoryFactory : IScopedDependency
    {
        IUserRepository GetUserRepository();
        IModuleRepository GetModuleRepository();
        IApplicationRepository GetApplicationRepository();
        ICompanyRepository GetCompanyRepository();
        IPageRepository GetPageRepository();
        IRoleRepository GetRoleRepository();
        IBusinessLogicRepository GetBusinessLogicRepository();
        IMicroserviceRepository GetMicroserviceRepository();
        ICommandRepository GetCommandRepository();
        IMenuRepository GetMenuRepository();
        ITemplateRepository GetTemplateRepository();
        ILanguageRepository GetLanguageRepository();
    }
}
