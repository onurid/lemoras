using Lemoras.Remora.Admin.Domain.Menu;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Admin.Domain.MenuAggregate
{
    public interface IMenuRepository : IBaseRepository<IMenuModelKey>, ITransientDependency
    {
    }
}