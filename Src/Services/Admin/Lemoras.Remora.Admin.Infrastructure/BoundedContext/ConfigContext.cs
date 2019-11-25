using Lemoras.Remora.Core;
using Lemoras.Remora.Infrastructure.Configuration;
using Lemoras.Remora.Admin.Domain.BoundedContext;
using Microsoft.EntityFrameworkCore;
using OYASAR.Framework.Core.Exceptions;
using OYASAR.Framework.EFProvider.NetCore.PostgreSQL.Extensions;

namespace Lemoras.Remora.Admin.Infrastructure.BoundedContext
{
    public class ConfigContext : DbContext, IConfigContext
    {
        public static string ConnectionString = string.Empty;

        public ConfigContext()
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
            modelBuilder.ApplyConfiguration(new ConfigConf());

            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("config");
            modelBuilder.ConvertAllToSnakeCase();
        }
    }
}
