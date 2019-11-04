using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Kernel.Domain.Language
{
    public class Language : Entity<int>, ILanguageModelKey
    {
        public string LanguageName { get; set; }
    }
}