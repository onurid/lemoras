using Lemoras.Remora.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OYASAR.Framework.Core.Utils;

namespace Lemoras.Remora.Api.Controllers
{
    public abstract class BaseApiController<TService, TServiceFactory> 
        : BaseApiController<TService> where TService : class where TServiceFactory : class, IBaseTServiceFactory
    {
        protected BaseApiController()
            : base (Invoke<TServiceFactory>.Call().GetService<TService>())
        {
        }
    }

    public abstract class BaseApiController<TService> : ControllerBase where TService : class
    {
        internal protected readonly TService service;

        protected BaseApiController()
        {
            service = Invoke<TService>.Call();
        }

        protected BaseApiController(TService service)
        {
            this.service = service;
        }
    }
}