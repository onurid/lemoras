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
    public class UserContext : DbContext, IUserContext
    {
        public static string ConnectionString = string.Empty;

        public UserContext()
            : base()
        {
            var userSession = Invoke<IWorkContextService>.Call().GetCurrentUserSession();
            var databaseName = userSession.DatabaseName;

            if (userSession.ConnectionString == null)
                throw new BusinessException(Constants.Message.Exception.NotAttachDatabaseToApp);

            UserContext.ConnectionString = userSession.ConnectionString;            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConf());
            modelBuilder.ApplyConfiguration(new UserRoleConf());
            
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("security");
            modelBuilder.ConvertAllToSnakeCase();
        }
    }
}
