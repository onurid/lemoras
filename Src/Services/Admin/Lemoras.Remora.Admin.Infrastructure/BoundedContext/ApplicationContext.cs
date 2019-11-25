using Lemoras.Remora.Infrastructure.Configuration;
using Lemoras.Remora.Admin.Domain.BoundedContext;
using Microsoft.EntityFrameworkCore;
using OYASAR.Framework.Core.Exceptions;
using OYASAR.Framework.EFProvider.NetCore.PostgreSQL.Extensions;
using Constants = Lemoras.Remora.Core.Constants;

namespace Lemoras.Remora.Admin.Infrastructure.BoundedContext
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public static string ConnectionString = string.Empty;

        public ApplicationContext()
            : base()
        {
            if (ConnectionString == null)
            {
                throw new BusinessException(Constants.Message.Exception.NotAttachDatabaseToApp);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicationConf());
            modelBuilder.ApplyConfiguration(new ApplicationTypeConf());
            
            modelBuilder.ApplyConfiguration(new ApplicationInstanceConf());
            
            modelBuilder.ApplyConfiguration(new ModulePageConf());
            
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("application");
            modelBuilder.ConvertAllToSnakeCase();
        }
    }
}
