using Lemoras.Remora.Core;
using Lemoras.Remora.Roomshare.Domain.Interfaces;
using Lemoras.Remora.Roomshare.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using OYASAR.Framework.Core.Exceptions;
using OYASAR.Framework.Core.Utils;
using OYASAR.Framework.EFProvider.NetCore.PostgreSQL.Extensions;
using Constants = Lemoras.Remora.Core.Constants;

namespace Lemoras.Remora.Roomshare.Infrastructre.BoundedContext
{
    public class RentContext : DbContext, IRentContext
    {
        public static string ConnectionString = string.Empty;

        public RentContext()
            : base()
        {
            var userSession = Invoke<IWorkContextService>.Call().GetCurrentUserSession();
            var databaseName = userSession.DatabaseName;

            if (userSession.ConnectionString == null)
                throw new BusinessException(Constants.Message.Exception.NotAttachDatabaseToApp);

            RentContext.ConnectionString = userSession.ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdvertConf());
            modelBuilder.ApplyConfiguration(new HouseConf());
            modelBuilder.ApplyConfiguration(new RoomConf());

            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("rent");
            modelBuilder.ConvertAllToSnakeCase();
        }
    }
}
