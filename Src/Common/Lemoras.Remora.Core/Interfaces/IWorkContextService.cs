using Lemoras.Remora.Core.Model;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Core.Interfaces
{
    public interface IWorkContextService : IScopedDependency
    {
        string GetBusinessLogicKeyName(string moduleKey);

        bool IsAcceptableRoleSetCommand(string roleSetCommandName);

        UserSession GetCurrentUserSession();
    }
}
