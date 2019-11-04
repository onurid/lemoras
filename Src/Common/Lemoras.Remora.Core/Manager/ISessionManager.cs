using Lemoras.Remora.Core.Model;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Core.Manager
{
    public interface ISessionManager : ITransientDependency
    {
        UserSession GetCurrentSession(string token);
    }
}
