using System.Collections.Generic;
using System.Linq;
using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Roomshare.Domain.Models.CommonContext
{
    public class University : Entity<int>
    {
        private readonly List<Program> _programs;

        public University(string name)
        {
            this.Name = name;
            _programs = new List<Program>();
        }

        public string Name { get; protected set; }
        public IReadOnlyCollection<Program> Programs => _programs.OrderBy(x => x.Name).ToList();
    }
}
