using System.Collections.Generic;
using System.Linq;
using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Roomshare.Domain.Models.CommonContext
{
    public class City : Entity<int>
    {
        private readonly List<District> _districts;
        
        public City(string name)
        {
            this.Name = name;
            _districts = new List<District>();
        }

        public string Name { get; protected set; }

        public IReadOnlyCollection<District> Districts => _districts.OrderBy(x=> x.Name).ToList();
    }
}
