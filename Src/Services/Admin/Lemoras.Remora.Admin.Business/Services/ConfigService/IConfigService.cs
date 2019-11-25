using Lemoras.Remora.Admin.Business.ConfigModel;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Admin.Business
{
    public interface IConfigService : ITransientDependency
    {
        ConfigContract GetConfig();
    }
}
