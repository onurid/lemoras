using System;
using Lemoras.Remora.Api;
using Lemoras.Remora.Roomshare.Domain.Interfaces;
using Lemoras.Remora.Roomshare.Infrastructre.BoundedContext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OYASAR.Framework.Core.Interface;
using OYASAR.Framework.Core.Manager;
using OYASAR.Framework.EFProvider.NetCore.PostgreSQL;

namespace Lemoras.Remora.Roomshare.Api
{
    public class RoomshareStartup : Startup
    {
        public RoomshareStartup(IConfiguration configuration)
            : base(configuration)
        {
        }

        public override void CustomConfigure()
        {
            RentContext.ConnectionString = _serviceDbConnection;
            CommonContext.ConnectionString = _serviceDbConnection;
            MemberContext.ConnectionString = _serviceDbConnection;
            base.CustomConfigure();
        }

        public override void CustomServiceRegister()
        {
            base.CustomServiceRegister();

            IocManager.Instance.RegisterScoped(typeof(ICommonContext), typeof(CommonContext));
            IocManager.Instance.RegisterScoped(typeof(IRentContext), typeof(RentContext));
            IocManager.Instance.RegisterScoped(typeof(IMemberContext), typeof(MemberContext));

            var commonContext = new Func<IServiceProvider, EFRepository<ICommonContext>>(
                provider => new EFRepository<ICommonContext>(provider.GetService<CommonContext>()));
            IocManager.Instance.Register<IEFRepository<ICommonContext>, EFRepository<ICommonContext>>(commonContext);

            var rentContext = new Func<IServiceProvider, EFRepository<IRentContext>>(
                provider => new EFRepository<IRentContext>(provider.GetService<RentContext>()));
            IocManager.Instance.Register<IEFRepository<IRentContext>, EFRepository<IRentContext>>(rentContext);

            var roleContext = new Func<IServiceProvider, EFRepository<IMemberContext>>(
                provider => new EFRepository<IMemberContext>(provider.GetService<MemberContext>()));
            IocManager.Instance.Register<IEFRepository<IMemberContext>, EFRepository<IMemberContext>>(roleContext);
        }
    }
}
