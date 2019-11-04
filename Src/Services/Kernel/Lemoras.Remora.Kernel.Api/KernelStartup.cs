using System;
using Lemoras.Remora.Api;
using Lemoras.Remora.Kernel.Domain.BoundedContext;
using Lemoras.Remora.Kernel.Infrastructure.BoundedContext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OYASAR.Framework.Core.Interface;
using OYASAR.Framework.Core.Manager;
using OYASAR.Framework.EFProvider.NetCore.PostgreSQL;

namespace Lemoras.Remora.Kernel.Api
{
    public class KernelStartup : Startup
    {
        public KernelStartup(IConfiguration configuration)
            : base(configuration)
        {
        }

        public override void CustomServiceRegister()
        {
            IocManager.Instance.RegisterScoped(typeof(IApplicationContext), typeof(ApplicationContext));
            IocManager.Instance.RegisterScoped(typeof(ICommonContext), typeof(CommonContext));
            IocManager.Instance.RegisterScoped(typeof(IRoleContext), typeof(RoleContext));
            IocManager.Instance.RegisterScoped(typeof(ITemplateContext), typeof(TemplateContext));
            IocManager.Instance.RegisterScoped(typeof(IUserContext), typeof(UserContext));

            var applicationContext = new Func<IServiceProvider, EFRepository<IApplicationContext>>(
                provider => new EFRepository<IApplicationContext>(provider.GetService<ApplicationContext>()));
            IocManager.Instance.Register<IEFRepository<IApplicationContext>, EFRepository<IApplicationContext>>(applicationContext);

            var CommonContext = new Func<IServiceProvider, EFRepository<ICommonContext>>(
                provider => new EFRepository<ICommonContext>(provider.GetService<CommonContext>()));
            IocManager.Instance.Register<IEFRepository<ICommonContext>, EFRepository<ICommonContext>>(CommonContext);

            var roleContext = new Func<IServiceProvider, EFRepository<IRoleContext>>(
                provider => new EFRepository<IRoleContext>(provider.GetService<RoleContext>()));
            IocManager.Instance.Register<IEFRepository<IRoleContext>, EFRepository<IRoleContext>>(roleContext);

            var templateContext = new Func<IServiceProvider, EFRepository<ITemplateContext>>(
                provider => new EFRepository<ITemplateContext>(provider.GetService<TemplateContext>()));
            IocManager.Instance.Register<IEFRepository<ITemplateContext>, EFRepository<ITemplateContext>>(templateContext);

            var userContext = new Func<IServiceProvider, EFRepository<IUserContext>>(
                provider => new EFRepository<IUserContext>(provider.GetService<UserContext>()));
            IocManager.Instance.Register<IEFRepository<IUserContext>, EFRepository<IUserContext>>(userContext);
        }
    }
}
