using System.Linq;
using Lemoras.Remora.Core;
using Lemoras.Remora.Core.Factory;
using Lemoras.Remora.Core.Model;
using Lemoras.Remora.Kernel.Domain.BusinessLogic;
using Lemoras.Remora.Kernel.Domain.Factory;
using OYASAR.Framework.Core.Exceptions;
using OYASAR.Framework.Core.Extensions;
using OYASAR.Framework.Core.Utils;
using Constants = Lemoras.Remora.Core.Constants;

namespace Lemoras.Remora.Kernel.Business
{
    public class WorkContextService : IWorkContextService
    {
        public readonly int ApplicationId;

        public readonly UserSession userSession;

        private readonly IRepositoryFactory repositories;

        private readonly IManagerFactory managers;

        public WorkContextService()
        {
            repositories = Invoke<IRepositoryFactory>.Call();

            managers = Invoke<IManagerFactory>.Call();

            if (TokenContextService.Token == null)
                throw new BusinessException(Constants.Message.Exception.KeySentNotFound);

            userSession = managers.GetSessionManager().GetCurrentSession(TokenContextService.Token);
        }

        public UserSession GetCurrentUserSession()
        {
            if (userSession == null)
                return managers.GetSessionManager().GetCurrentSession(TokenContextService.Token);
            
            return userSession;
        }

        public string GetBusinessLogicKeyName(string serviceKey)
        {
            var appModule = repositories.GetApplicationRepository()
                .GetUniqueKeyNamebyServiceKey(userSession.ApplicationId);

            var businessRepo = repositories.GetBusinessLogicRepository();

            var businessLogics = businessRepo.GetAll<BusinessLogic>();

            var businessServices = businessRepo.GetBusinessServicesbyServiceKey(serviceKey);
                       
            var query = (from a in appModule
                         join b in businessLogics on a.BusinessLogicId equals b.Id
                         join s in businessServices on b.BusinessServiceId equals s.Id
                         select b.UniqueKey).FirstOrDefault()
                         .ToCheck(Constants.Message.Exception.NotFoundAppModuleOrBusinessLogic);
            return query;
        }

        public bool HasMicroserviceAccess()
        {
            var microserviceModules = repositories.GetMicroserviceRepository()
                .GetMicroserviceModules(Constants.System.Microservice.Application);

            var result = microserviceModules.Intersect(userSession.ModuleIds);

            return result.Any();
        }

        public bool IsAcceptableRoleSetCommand(string roleSetCommandName)
        {
            var roleAuthorises = repositories.GetRoleRepository().GetRoleAuthoriseByRoleId(userSession.RoleId);

            var repo = repositories.GetCommandRepository();

            var command = repo.GetCommand(roleSetCommandName);

            var query = roleAuthorises.Where(x => x.CommandId == command.Id);

            return query.Any();
        }
    }
}
