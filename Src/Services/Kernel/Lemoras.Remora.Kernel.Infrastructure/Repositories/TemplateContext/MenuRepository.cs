using Lemoras.Remora.Kernel.Domain.BoundedContext;
using Lemoras.Remora.Kernel.Domain.Menu;
using Lemoras.Remora.Kernel.Domain.MenuAggregate;
using OYASAR.Framework.Core.Abstract;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Kernel.Infrastructure.Repositories.TemplateContext
{
    public class MenuRepository : BaseRepository<IEFRepository<ITemplateContext>, IMenuModelKey>, IMenuRepository
    {
    }
}