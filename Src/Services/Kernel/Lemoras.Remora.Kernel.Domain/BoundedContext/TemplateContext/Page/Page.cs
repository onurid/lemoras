using System.Collections.Generic;
using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Kernel.Domain.Page
{
    public class Page : Entity<int>, IPageModelKey
    {
        public int TemplateId { get; set; }
        public string RouteName { get; set; }
        public string TemplateUrl { get; set; }
        public string ControllerUrl { get; set; }
        public string ControllerName { get; set; }
        public string ControllerAsName { get; set; }

        public virtual List<PageDetail> PageDetails { get; set; }
    }
}