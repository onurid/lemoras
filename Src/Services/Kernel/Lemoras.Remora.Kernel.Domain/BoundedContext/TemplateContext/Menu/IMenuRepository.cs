using Lemoras.Remora.Kernel.Domain.Menu;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Kernel.Domain.MenuAggregate
{
    public interface IMenuRepository : IBaseRepository<IMenuModelKey>, ITransientDependency
    {
    }
}