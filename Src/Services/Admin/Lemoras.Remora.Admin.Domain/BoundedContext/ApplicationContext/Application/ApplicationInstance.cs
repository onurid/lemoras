using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Admin.Domain.Application
{
    public class ApplicationInstance : Entity<int>, IApplicationModelKey
    {
        public string ApplicationTagName { get; set; }
        public int ApplicationId { get; set; }
        public int CompanyId { get; set; }
        public int TemplateId { get; set; }

        public virtual Application Application { get; set; }
    }
}