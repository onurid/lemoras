using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Admin.Domain.Language
{
    public class Language : Entity<int>, ILanguageModelKey
    {
        public string LanguageName { get; set; }
    }
}