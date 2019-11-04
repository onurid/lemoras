using Lemoras.Remora.Api.Controllers;
using Lemoras.Remora.Kernel.Business.Factory;

namespace Lemoras.Remora.Kernel.Api.Controllers
{
    public abstract class BaseApiController<TService> : BaseApiController<TService, IServiceFactory> where TService : class
    {
    }
}