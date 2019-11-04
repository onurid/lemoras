using OYASAR.Framework.Core.Helper;
using OYASAR.Framework.Core.Utils;

namespace Lemoras.Remora.Core.Factory
{
    public abstract class BaseServiceFactory : IBaseServiceFactory
    {
        public TService GetService<TService>() where TService : class
        {
            var moduleKey = typeof(TService).Name;
            var key = GetWorkContextService().GetBusinessLogicKeyName(moduleKey);
            return Invoke<TService>.Call(GenerateKey<TService>(key));
        }

        public IWorkContextService GetWorkContextService()
        {
            return Invoke<IWorkContextService>.Call();
        }

        public string GenerateKey<TService>(string realKey) where TService : class
        {
            if (IocHelper.RegisterTypeValue == IocHelper.RegisterType.AsFullName)
            {
                var serviceType = typeof(TService);
                var service = serviceType.FullName.Replace(".Base", "");
                service = service.Replace(serviceType.Name, realKey);
                return service;
            }
            return realKey;
        }
    }
}
