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
    public class TemplateContext : DbContext, ITemplateContext
    {
        public static string ConnectionString = string.Empty;

        public TemplateContext()
            : base()
        {
            var userSession = Invoke<IWorkContextService>.Call().GetCurrentUserSession();
            var databaseName = userSession.DatabaseName;

            if (userSession.ConnectionString == null)
                throw new BusinessException(Constants.Message.Exception.NotAttachDatabaseToApp);

            TemplateContext.ConnectionString = userSession.ConnectionString;            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MenuConf());
            modelBuilder.ApplyConfiguration(new MenuIconConf());
            modelBuilder.ApplyConfiguration(new MenuTypeConf());
            modelBuilder.ApplyConfiguration(new MenuValueConf());

            modelBuilder.ApplyConfiguration(new PageConf());
            modelBuilder.ApplyConfiguration(new PageDetailConf());
            
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("template");
            modelBuilder.ConvertAllToSnakeCase();
        }
    }
}
