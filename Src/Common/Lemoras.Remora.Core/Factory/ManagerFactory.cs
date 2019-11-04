using Lemoras.Remora.Core.Manager;
using OYASAR.Framework.Core.Interface;
using OYASAR.Framework.Core.Utils;

namespace Lemoras.Remora.Core.Factory
{
    public class ManagerFactory : IManagerFactory
    {
        public ILog GetLogManger()
        {
            return Invoke<ILog>.Call();
        }

        public ICacheManager GetCacheManager()
        {
            return Invoke<ICacheManager>.Call();
        }

        public ISessionManager GetSessionManager()
        {
            return Invoke<ISessionManager>.Call();
        }
    }
}
