using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lemoras.Remora.Core.Interfaces;
using Lemoras.Remora.Core.Models.KernelContext;
using OYASAR.Framework.Core.Utils;

namespace Lemoras.Remora.Core.Services
{
    public class KernelService : IKernelService
    {
        private readonly IKernelRepository _repository;
        private readonly ISessionManager _session;

        public KernelService()
        {
            _repository = Invoke<IKernelRepository>.Call();
            _session = Invoke<ISessionManager>.Call();
        }

        public ApplicationModule AddNewApplicationModule(int applicationId, int moduleId, int businessLogicId)
        {
            var model = new ApplicationModule(applicationId, moduleId, businessLogicId);

            _repository.Add<ApplicationModule, int>(model);
            _repository.Save();

            return model;
        }

        public BusinessLogic AddNewBusinessLogic(string businessLogicName, int businessServiceId, string uniqueKey)
        {
            var model = new BusinessLogic(businessServiceId, businessLogicName, uniqueKey);

            _repository.Add<BusinessLogic, int>(model);
            _repository.Save();

            return model;
        }

        public BusinessService AddNewBusinessService(string businessServiceName, string businessServiceKey)
        {
            var model = new BusinessService(businessServiceName, businessServiceKey);

            _repository.Add<BusinessService, int>(model);
            _repository.Save();

            return model;
        }

        public Command AddNewCommand(string commandName, int businessServiceId)
        {
            var model = new Command(businessServiceId, commandName);

            _repository.Add<Command, int>(model);
            _repository.Save();

            return model;
        }

        public RoleAuthorise AttachToCommandAtRole(int roleId, int commandId)
        {
            var model = new RoleAuthorise(roleId, commandId);

            _repository.Add<RoleAuthorise, int>(model);
            _repository.Save();

            return model;
        }

        public void DeleteApplicationModule(int applicationModuleId)
        {
            _repository.RowDelete<ApplicationModule>(applicationModuleId);
            _repository.Save();
        }

        public void DeleteBusinessLogic(int businessLogicId)
        {
            _repository.RowDelete<BusinessLogic>(businessLogicId);
            _repository.Save();
        }

        public void DeleteBusinessService(int businessServiceId)
        {
            _repository.RowDelete<BusinessService>(businessServiceId);
            _repository.Save();
        }

        public void DeleteCommand(int commandId)
        {
            _repository.RowDelete<Command>(commandId);
            _repository.Save();
        }

        public void DeleteRoleAuthorise(int roleAuthoriseId)
        {
            _repository.RowDelete<RoleAuthorise>(roleAuthoriseId);
            _repository.Save();
        }

        public object GetApplicationModules(int applicationId)
        {
            var applicationModules = _repository.LoadAllApplicationModule(applicationId);
            //   ApplicationName = "App Name",  angular tekrar istek atacak yada 
            //      zaten specific olarak bu objetyi isteidği için zaten elinde mevcut
            //   ModuleName = m.ModuleName,   angular tekrar istek atacak
            //   BusinessLogicName = b.BusinessLogicName   buradan dönecek 

            //var data = Mapping.Map();
            var data = applicationModules;

            return data;
        }

        public IEnumerable GetBusinessLogics()
        {
            var businessServices = _repository.LoadAllBusinessService();

            //BusinessLogicName 
            //UniqueKey 
            //ServiceKey 
            // mapping 
            var data = businessServices;

            return data;
        }

        public IEnumerable<BusinessService> GetBusinessServices()
        {
            return _repository.GetAll<BusinessService>().ToList();
        }

        public IEnumerable<Command> GetCommands()
        {
            return _repository.GetAll<Command>().ToList();
        }

        public IEnumerable GetRoleAuthorises(int roleId)
        {
            var roleAuthorises = _repository.LoadAllRoleAuthorise(roleId);

            //RoleName
            //CommandName
            //mapping 

            var data = roleAuthorises;

            return data;
        }
    }
}
