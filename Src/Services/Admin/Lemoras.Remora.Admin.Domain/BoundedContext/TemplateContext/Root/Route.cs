using System.Collections.Generic;

namespace Lemoras.Remora.Admin.Domain.Root
{
    public class Route
    {
        public string Default { get; set; }

        public List<Page.Page> Pages { get; set; }
    }
}