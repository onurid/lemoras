using Lemoras.Remora.Core;
using Lemoras.Remora.Infrastructure.Configuration;
using Lemoras.Remora.Kernel.Domain.BoundedContext;
using Microsoft.EntityFrameworkCore;
using OYASAR.Framework.Core.Exceptions;
using OYASAR.Framework.Core.Utils;
using OYASAR.Framework.EFProvider.NetCore.PostgreSQL.Extensions;
using Constants = Lemoras.Remora.Core.Constants;

namespace Lemoras.Remora.Kernel.Infrastructure.BoundedContext
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public static string ConnectionString = string.Empty;

        public ApplicationContext()
            : base()
        {
            var userSession = Invoke<IWorkContextService>.Call().GetCurrentUserSession();
            var databaseName = userSession.DatabaseName;

            if (userSession.ConnectionString == null)
                throw new BusinessException(Constants.Message.Exception.NotAttachDatabaseToApp);

            ApplicationContext.ConnectionString = userSession.ConnectionString;            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicationConf());
            modelBuilder.ApplyConfiguration(new ApplicationTypeConf());
            modelBuilder.ApplyConfiguration(new ApplicationModuleConf());
            
            modelBuilder.ApplyConfiguration(new ApplicationInstanceConf());
            
            modelBuilder.ApplyConfiguration(new ModulePageConf());

            modelBuilder.ApplyConfiguration(new BusinessLogicConf());
            modelBuilder.ApplyConfiguration(new BusinessServiceConf());
            
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("application");
            modelBuilder.ConvertAllToSnakeCase();
        }
    }
}
