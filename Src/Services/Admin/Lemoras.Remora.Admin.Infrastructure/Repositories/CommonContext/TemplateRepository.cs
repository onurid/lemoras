using System.Collections.Generic;
using System.Linq;
using Lemoras.Remora.Admin.Domain.BoundedContext;
using Lemoras.Remora.Admin.Domain.Template;
using OYASAR.Framework.Core.Abstract;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Admin.Infrastructure.Repositories.CommonContext
{
    public class TemplateRepository : BaseRepository<IEFRepository<ICommonContext>, ITemplateModelKey>, ITemplateRepository
    {
        public Template GetTemplate(int templateId)
        {
            return GetByKey<Template>(templateId);
        }
        public Template AddNewTemplate(Template template)
        {
            this.Add<Template, int>(template);
            return template;
        }
        public List<Template> GetAllTemplates()
        {
            return GetAll<Template>().ToList();
        }
        public void RemoveTemplate(int templateId)
        {
            this.RowDelete<Template>(templateId);
        }
    }
}