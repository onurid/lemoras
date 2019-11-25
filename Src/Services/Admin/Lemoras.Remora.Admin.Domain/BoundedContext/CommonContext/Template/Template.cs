using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Admin.Domain.Template
{
    public class Template : Entity<int>, ITemplateModelKey
    {        
        public string TemplateName { get; set; }
        public string TemplateUrl { get; set; }
    }
}