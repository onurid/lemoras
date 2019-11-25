using Lemoras.Remora.Infrastructure.Configuration;
using Lemoras.Remora.Admin.Domain.BoundedContext;
using Microsoft.EntityFrameworkCore;
using OYASAR.Framework.Core.Exceptions;
using OYASAR.Framework.EFProvider.NetCore.PostgreSQL.Extensions;
using Constants = Lemoras.Remora.Core.Constants;

namespace Lemoras.Remora.Admin.Infrastructure.BoundedContext
{
    public class CommonContext : DbContext, ICommonContext
    {
        public static string ConnectionString = string.Empty;

        public CommonContext()
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
            modelBuilder.ApplyConfiguration(new ModuleConf());

            modelBuilder.ApplyConfiguration(new CompanyConf());

            modelBuilder.ApplyConfiguration(new MicroserviceConf());
            
            modelBuilder.ApplyConfiguration(new TemplateConf());

            modelBuilder.ApplyConfiguration(new LanguageConf());
            
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("common");
            modelBuilder.ConvertAllToSnakeCase();
        }
    }
}
