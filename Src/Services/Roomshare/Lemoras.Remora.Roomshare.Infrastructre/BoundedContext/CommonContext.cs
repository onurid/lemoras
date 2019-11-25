using Lemoras.Remora.Roomshare.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using OYASAR.Framework.Core.Exceptions;
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
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("common");
            modelBuilder.ConvertAllToSnakeCase();
        }
    }
}
