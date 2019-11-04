using Lemoras.Remora.Core.Model;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Core
{
    public interface IWorkContextService : IScopedDependency
    {
        bool HasMicroserviceAccess();

        string GetBusinessLogicKeyName(string moduleKey);

        bool IsAcceptableRoleSetCommand(string roleSetCommandName);

        UserSession GetCurrentUserSession();
    }
}
