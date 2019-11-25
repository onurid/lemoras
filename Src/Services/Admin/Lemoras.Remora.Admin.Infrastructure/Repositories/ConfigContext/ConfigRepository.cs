using System.Collections.Generic;
using System.Linq;
using Lemoras.Remora.Admin.Domain.BoundedContext;
using Lemoras.Remora.Admin.Domain.Config;
using OYASAR.Framework.Core.Abstract;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Admin.Infrastructure.Repositories.ConfigContext
{
    public class ConfigRepository : BaseRepository<IEFRepository<IConfigContext>, IConfigModelKey>, IConfigRepository
    {
		public IEnumerable<string> GetAllConfig()
		{
            return GetAll<CrunchConfig>().Select(x=> x.Data).ToList();
		}

		public string GetConfig(int id)
		{
			return GetByKey<CrunchConfig>(id).Data;
		}
	}
}