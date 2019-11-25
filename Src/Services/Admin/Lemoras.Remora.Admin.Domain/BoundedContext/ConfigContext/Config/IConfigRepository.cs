using System.Collections.Generic;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Admin.Domain.Config
{
    public interface IConfigRepository : IBaseRepository<IConfigModelKey>, ITransientDependency
    {
		IEnumerable<string> GetAllConfig();
        string GetConfig(int id);
	}
}