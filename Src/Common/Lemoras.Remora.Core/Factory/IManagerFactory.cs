using Lemoras.Remora.Core.Manager;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Core.Factory
{
    public interface IManagerFactory : ITransientDependency
    {
        ILog GetLogManger();
        ICacheManager GetCacheManager();
        ISessionManager GetSessionManager();
    }
}
