using System;
using Lemoras.Remora.Admin.Api.Manager;
using Lemoras.Remora.Admin.Domain.BoundedContext;
using Lemoras.Remora.Admin.Infrastructure.BoundedContext;
using Lemoras.Remora.Api;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OYASAR.Framework.Core.Interface;
using OYASAR.Framework.Core.Manager;
using OYASAR.Framework.EFProvider.NetCore.PostgreSQL;

namespace Lemoras.Remora.Admin.Api
{
    public class AdminStartup : Startup
    {
        private readonly string _redisConnection;

        public AdminStartup(IConfiguration configuration)
            : base(configuration)
        {
            _redisConnection = Configuration.GetConnectionString("RedisConnection");
        }

        public override void CustomConfigure()
        {
            CacheManager.RedisHost = _redisConnection;
            ApplicationContext.ConnectionString = _serviceDbConnection;
            CommonContext.ConnectionString = _serviceDbConnection;
            RoleContext.ConnectionString = _serviceDbConnection;
            TemplateContext.ConnectionString = _serviceDbConnection;
            ConfigContext.ConnectionString = _serviceDbConnection;
            UserContext.ConnectionString = _serviceDbConnection;
            base.CustomConfigure();
        }

        public override void CustomServiceRegister()
        {
            base.CustomServiceRegister();

            IocManager.Instance.RegisterScoped(typeof(IApplicationContext), typeof(ApplicationContext));
            IocManager.Instance.RegisterScoped(typeof(ICommonContext), typeof(CommonContext));
            IocManager.Instance.RegisterScoped(typeof(IRoleContext), typeof(RoleContext));
            IocManager.Instance.RegisterScoped(typeof(ITemplateContext), typeof(TemplateContext));
            IocManager.Instance.RegisterScoped(typeof(IUserContext), typeof(UserContext));
            IocManager.Instance.RegisterScoped(typeof(IConfigContext), typeof(ConfigContext));

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

            var configContext = new Func<IServiceProvider, EFRepository<IConfigContext>>(
                provider => new EFRepository<IConfigContext>(provider.GetService<ConfigContext>()));
            IocManager.Instance.Register<IEFRepository<IConfigContext>, EFRepository<IConfigContext>>(configContext);
        }
    }
}
