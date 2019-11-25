using System.Collections.Generic;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Admin.Domain.Module
{
    public interface IModuleRepository : IBaseRepository<IModuleModelKey>, ITransientDependency
    {
        Module AddNewModule(Module module, bool isPassive = true);       
        void RowDeleteModule(int moduleId);
        List<Module> GetModules();
    }
}