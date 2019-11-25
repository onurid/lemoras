using Lemoras.Remora.Admin.Domain.Language;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Admin.Domain.LanguageAggregate
{
    public interface ILanguageRepository : IBaseRepository<ILanguageModelKey>, ITransientDependency
    {
    }
}