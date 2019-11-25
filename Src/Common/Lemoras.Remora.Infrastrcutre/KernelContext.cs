using Lemoras.Remora.Core;
using Lemoras.Remora.Core.Interfaces;
using Lemoras.Remora.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using OYASAR.Framework.Core.Exceptions;
using OYASAR.Framework.EFProvider.NetCore.PostgreSQL.Extensions;

namespace Lemoras.Remora.Infrastructre
{
    public class KernelContext : DbContext, IKernelContext
    {
        public static string ConnectionString = string.Empty;

        public KernelContext()
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
            modelBuilder.ApplyConfiguration(new ApplicationModuleConf());
            modelBuilder.ApplyConfiguration(new BusinessServiceConf());
            modelBuilder.ApplyConfiguration(new BusinessLogicConf());
            modelBuilder.ApplyConfiguration(new CommandConf());
            modelBuilder.ApplyConfiguration(new RoleAuthoriseConf());

            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("kernel");
            modelBuilder.ConvertAllToSnakeCase();
        }
    }
}
