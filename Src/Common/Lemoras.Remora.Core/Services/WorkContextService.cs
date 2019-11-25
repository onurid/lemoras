using Lemoras.Remora.Core.Interfaces;
using Lemoras.Remora.Core.Model;
using OYASAR.Framework.Core.Exceptions;
using OYASAR.Framework.Core.Extensions;
using OYASAR.Framework.Core.Utils;

namespace Lemoras.Remora.Core.Services
{
    public class WorkContextService : IWorkContextService
    {
        public readonly UserSession userSession;

        private readonly IKernelRepository _repository;

        private readonly ISessionManager _sessionManager;

        public WorkContextService()
        {
            _repository = Invoke<IKernelRepository>.Call();

            _sessionManager = Invoke<ISessionManager>.Call();

            userSession = _sessionManager.GetCurrentSession();

            if (userSession == null)
            {
                throw new BusinessException(Constants.Message.Exception.KeySentNotFound);
            }
        }

        public UserSession GetCurrentUserSession()
        {
            if (userSession == null)
            { 
                return _sessionManager.GetCurrentSession();
            }
            return userSession;
        }

        public string GetBusinessLogicKeyName(string serviceKey)
        {
            var data = _repository.GetApplicationModule(userSession.ApplicationId ,serviceKey)
                .ToCheck(Constants.Message.Exception.NotFoundAppModuleOrBusinessLogic);

            return data.BusinessLogic.UniqueKey;
        }

        public bool IsAcceptableRoleSetCommand(string roleSetCommandName)
        {
            return _repository.CheckAnyRoleAuthorises(userSession.RoleId, roleSetCommandName);
        }
    }
}
