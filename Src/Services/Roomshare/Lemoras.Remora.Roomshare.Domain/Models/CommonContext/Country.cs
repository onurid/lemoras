using System.Collections.Generic;
using System.Linq;
using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Roomshare.Domain.Models.CommonContext
{
    public class Country : Entity<int>
    {
        private readonly List<City> _cities;

        public Country(string name)
        {
            this.Name = name;
            _cities = new List<City>();
        }

        public string Name { get; protected set; }
        public IReadOnlyCollection<City> Cities => _cities.OrderBy(x=> x.Name).ToList();
    }
}
