using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Kernel.Domain.Page
{
    public class PageDetail : Entity<int>, IPageModelKey
    {
        public int PageId { get; set; }
        public int LanguageId { get; set; }

        public virtual Page Page { get; set; }
    }
}