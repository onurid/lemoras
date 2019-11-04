using Lemoras.Remora.Core;
using Lemoras.Remora.Roomshare.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using OYASAR.Framework.Core.Exceptions;
using OYASAR.Framework.Core.Utils;
using OYASAR.Framework.EFProvider.NetCore.PostgreSQL.Extensions;
using Constants = Lemoras.Remora.Core.Constants;

namespace Lemoras.Remora.Roomshare.Infrastructre.BoundedContext
{
    public class CommonContext : DbContext, ICommonContext
    {
        public static string ConnectionString = string.Empty;

        public CommonContext()
            : base()
        {
            var userSession = Invoke<IWorkContextService>.Call().GetCurrentUserSession();
            var databaseName = userSession.DatabaseName;

            if (userSession.ConnectionString == null)
                throw new BusinessException(Constants.Message.Exception.NotAttachDatabaseToApp);

            CommonContext.ConnectionString = userSession.ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("common");
            modelBuilder.ConvertAllToSnakeCase();
        }
    }
}
