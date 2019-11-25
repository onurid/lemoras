using Lemoras.Remora.Admin.Domain.BoundedContext;
using Lemoras.Remora.Admin.Domain.Language;
using Lemoras.Remora.Admin.Domain.LanguageAggregate;
using OYASAR.Framework.Core.Abstract;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Admin.Infrastructure.Repositories.CommonContext
{
    public class LanguageRepository : BaseRepository<IEFRepository<ICommonContext>, ILanguageModelKey>, ILanguageRepository
    {
    }
}