using Lemoras.Remora.Api.Manager;
using Lemoras.Remora.Api.Utils;
using Lemoras.Remora.Core.Manager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using OYASAR.Framework.CastleWindsor;
using OYASAR.Framework.Core.Helper;
using OYASAR.Framework.Core.Interface;
using OYASAR.Framework.Core.Manager;
using OYASAR.Framework.Log4Net;
using static OYASAR.Framework.Core.Helper.IocHelper;

namespace Lemoras.Remora.Api
{
    public class Startup
    {
        internal protected readonly string AuthDbConnection;
        internal protected readonly string RedisConnection;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            AuthDbConnection = Configuration.GetConnectionString("AuthDbConnection");
            RedisConnection = Configuration.GetConnectionString("RedisConnection");
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
            
            CacheManager.RedisHost = RedisConnection;

            CustomConfigure();

            SessionManager.SetAuthAndPolicy(app);

            app.UseMiddleware<Middleware>();

            app.UseMvc();
        }

        public virtual void CustomConfigure()
        {
            RoleManager.LockStatus = true;
        }

        public virtual void CustomServiceRegister()
        {

        }

        public void ServicesRegister(IServiceCollection services)
        {
            WindsorIocManager.Instance.Initialize();

            IocHelper.RegisterIntefaceBasedTypes(RegisterType.AsFullName ,true);

            IocManager.Instance.Register<ILog, Log>();

            CustomServiceRegister();
        }
    }
}
