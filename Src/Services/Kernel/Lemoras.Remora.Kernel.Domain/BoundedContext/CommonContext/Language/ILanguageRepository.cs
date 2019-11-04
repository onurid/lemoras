using Lemoras.Remora.Kernel.Domain.Language;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Kernel.Domain.LanguageAggregate
{
    public interface ILanguageRepository : IBaseRepository<ILanguageModelKey>, ITransientDependency
    {
    }
}