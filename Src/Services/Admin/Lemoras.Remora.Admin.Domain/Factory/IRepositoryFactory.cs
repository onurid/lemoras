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
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Admin.Domain.Factory
{
    public interface IRepositoryFactory : IScopedDependency
    {
        IModuleRepository GetModuleRepository();
        IApplicationRepository GetApplicationRepository();
        ICompanyRepository GetCompanyRepository();
        IPageRepository GetPageRepository();
        IRoleRepository GetRoleRepository();
        IMicroserviceRepository GetMicroserviceRepository();
        IMenuRepository GetMenuRepository();
        ITemplateRepository GetTemplateRepository();
        ILanguageRepository GetLanguageRepository();
        IUserRepository GetUserRepository();
        IConfigRepository GetConfigRepository();
    }
}
