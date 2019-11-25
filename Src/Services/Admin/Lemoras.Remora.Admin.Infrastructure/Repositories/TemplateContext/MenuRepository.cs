using Lemoras.Remora.Admin.Domain.BoundedContext;
using Lemoras.Remora.Admin.Domain.Menu;
using Lemoras.Remora.Admin.Domain.MenuAggregate;
using OYASAR.Framework.Core.Abstract;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Admin.Infrastructure.Repositories.TemplateContext
{
    public class MenuRepository : BaseRepository<IEFRepository<ITemplateContext>, IMenuModelKey>, IMenuRepository
    {
    }
}