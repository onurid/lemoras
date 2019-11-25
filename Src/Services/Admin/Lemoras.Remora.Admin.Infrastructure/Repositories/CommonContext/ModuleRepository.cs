using System.Collections.Generic;
using System.Linq;
using Lemoras.Remora.Admin.Domain.BoundedContext;
using Lemoras.Remora.Admin.Domain.Module;
using OYASAR.Framework.Core.Abstract;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Admin.Infrastructure.Repositories.CommonContext
{
    public class ModuleRepository : BaseRepository<IEFRepository<ICommonContext>, IModuleModelKey>, IModuleRepository
    {
        public Module AddNewModule(Module module, bool isPassive = true)
        {
            this.Add<Module, int>(module);
            return module;
        }

        public List<Module> GetModules()
        {
            return GetAll<Module>().ToList();
        }
        
        public void RowDeleteModule(int moduleId)
        {
            this.RowDelete<Module>(moduleId);
        }
    }
}