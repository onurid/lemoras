using System;
using Lemoras.Remora.Api.Manager;
using Lemoras.Remora.Api.Utils;
using Lemoras.Remora.Core.Interfaces;
using Lemoras.Remora.Infrastructre;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using OYASAR.Framework.CastleWindsor;
using OYASAR.Framework.Core.Helper;
using OYASAR.Framework.Core.Interface;
using OYASAR.Framework.Core.Manager;
using OYASAR.Framework.EFProvider.NetCore.PostgreSQL;
using OYASAR.Framework.Log4Net;
using static OYASAR.Framework.Core.Helper.IocHelper;

namespace Lemoras.Remora.Api
{
    public class Startup
    {
        internal protected string _serviceDbConnection;
        private static bool _isRegister = false;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _serviceDbConnection = Configuration.GetConnectionString("ServiceDbConnection");
        }

        public void SetKernelForWeb(string connectionString)
        {
            _serviceDbConnection = connectionString;
        }

        public IConfiguration Configuration { get; }

        public virtual void AddMvc(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(opt =>
            {
                opt.SerializerSettings.ContractResolver = new CustomResolver { NamingStrategy = new CamelCaseNamingStrategy() };
            }); ;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual void ConfigureServices(IServiceCollection services)
        {
            SessionManager.SetSessionAsManager(services);

            AddMvc(services);

            ServicesRegister(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }

            CustomConfigure();

            SessionManager.SetAuthAndPolicy(app);

            app.UseMiddleware<Middleware>();

            app.UseMvc();
        }

        public virtual void CustomConfigure()
        {
            KernelContext.ConnectionString = _serviceDbConnection;
        }

        public virtual void CustomServiceRegister()
        {
            if (!_isRegister)
            {
                IocManager.Instance.RegisterScoped(typeof(IKernelContext), typeof(KernelContext));

                var kernelContext = new Func<IServiceProvider, EFRepository<IKernelContext>>(
                    provider => new EFRepository<IKernelContext>(provider.GetService<KernelContext>()));
                IocManager.Instance.Register<IEFRepository<IKernelContext>, EFRepository<IKernelContext>>(kernelContext);
                _isRegister = true;
            }
        }

        public void ServicesRegister(IServiceCollection services)
        {
            WindsorIocManager.Instance.Initialize();

            IocHelper.RegisterIntefaceBasedTypes(RegisterType.AsFullName, true);

            IocManager.Instance.Register<ILog, Log>();

            CustomServiceRegister();
        }
    }
}
