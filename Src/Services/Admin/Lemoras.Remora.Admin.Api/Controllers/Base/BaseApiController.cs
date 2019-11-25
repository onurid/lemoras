using Lemoras.Remora.Api.Controllers;
using Lemoras.Remora.Admin.Business.Factory;

namespace Lemoras.Remora.Admin.Api.Controllers
{
    public abstract class BaseApiController<TService> : BaseApiController<TService, IServiceFactory> where TService : class
    {
    }
}