using Lemoras.Remora.Core.Model;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Core.Interfaces
{
    public interface ISessionManager : ITransientDependency
    {
        UserSession GetCurrentSession();
    }
}
