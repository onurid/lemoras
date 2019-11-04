using System.Collections.Generic;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Kernel.Domain.Template
{
    public interface ITemplateRepository : IBaseRepository<ITemplateModelKey>, ITransientDependency
    {
        Template GetTemplate(int templateId);
        Template AddNewTemplate(Template template);
        List<Template> GetAllTemplates();

        void RemoveTemplate(int templateId);
    }
}