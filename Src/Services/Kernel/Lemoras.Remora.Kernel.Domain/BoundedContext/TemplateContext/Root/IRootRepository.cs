using System.Collections.Generic;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Kernel.Domain.Root
{
    public interface IRootRepository : ITransientDependency
    {
		IEnumerable<Root> GetAllRoot();
		Root GetRoot(int id);
	}
}