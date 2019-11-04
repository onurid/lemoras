using System.Collections.Generic;
using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Kernel.Domain.Root
{
    public class MenuList : Entity<int>
    {
        public string Value { get; set; }
		public string Label { get; set; }
		public string Icon { get; set; }
		public string Link { get; set; }
		public string Tag { get; set; }
		public int Index { get; set; }

		public List<MenuList> List { get; set; }
    }
}