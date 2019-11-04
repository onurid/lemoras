using Lemoras.Remora.Kernel.Domain.BoundedContext;
using Lemoras.Remora.Kernel.Domain.Language;
using Lemoras.Remora.Kernel.Domain.LanguageAggregate;
using OYASAR.Framework.Core.Abstract;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Kernel.Infrastructure.Repositories.CommonContext
{
    public class LanguageRepository : BaseRepository<IEFRepository<ICommonContext>, ILanguageModelKey>, ILanguageRepository
    {
    }
}