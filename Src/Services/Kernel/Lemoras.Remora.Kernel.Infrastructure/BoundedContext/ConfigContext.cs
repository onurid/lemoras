using Lemoras.Remora.Infrastructure.Configuration;
using Lemoras.Remora.Kernel.Domain.BoundedContext;
using Microsoft.EntityFrameworkCore;
using OYASAR.Framework.EFProvider.NetCore.PostgreSQL.Extensions;

namespace Lemoras.Remora.Kernel.Infrastructure.BoundedContext
{
    public class ConfigContext : DbContext, IConfigContext
    {
        public static string ConnectionString = string.Empty;

        public ConfigContext()
            : base()
        {
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
