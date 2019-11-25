using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Admin.Domain.Page
{
    public class PageDetail : Entity<int>, IPageModelKey
    {
        public int PageId { get; set; }
        public int LanguageId { get; set; }

        public virtual Page Page { get; set; }
    }
}