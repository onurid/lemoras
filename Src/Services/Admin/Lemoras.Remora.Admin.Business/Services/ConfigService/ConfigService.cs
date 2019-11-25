using System.Linq;
using Lemoras.Remora.Core.Model;
using Lemoras.Remora.Admin.Business.ConfigModel;
using Lemoras.Remora.Admin.Business.Factory;
using Lemoras.Remora.Admin.Domain.Application;
using Lemoras.Remora.Admin.Domain.Factory;
using Lemoras.Remora.Admin.Domain.Template;
using Newtonsoft.Json;
using OYASAR.Framework.Core.Extensions;
using OYASAR.Framework.Core.Utils;

namespace Lemoras.Remora.Admin.Business
{
    public class ConfigService : IConfigService
    {
        private readonly IRepositoryFactory _repositories;
        private readonly UserSession _userSession;

        public ConfigService()
        {
            this._repositories = Invoke<IRepositoryFactory>.Call();
            _userSession = Invoke<IServiceFactory>
                .Call()
                .GetWorkContextService()
                .GetCurrentUserSession();
        }

        public ConfigContract GetConfig()
        {
            var template = GetTemplate(_userSession.ApplicationInsId);

            var config = GetConfigByRoleId(_userSession.RoleId);

            var result = new ConfigContract { Config = config, Template = template.TemplateUrl };

            return result;
        }

        private object GetConfigByRoleId(int appRoleId)
        {
            var strConfig = _repositories.GetConfigRepository().GetConfig(appRoleId);

            var config = JsonConvert.DeserializeObject(strConfig);

            return config;
        }

        private Template GetTemplate(int applicationInstanceId)
        {
            var appIns = _repositories.GetApplicationRepository().GetAll<ApplicationInstance>(x => x.Id == applicationInstanceId)
                .SingleOrDefault().ToCheck("can not be found application instances");

            return _repositories.GetTemplateRepository().GetTemplate(appIns.TemplateId).ToCheck("can not be found template");
        }
    }
}
