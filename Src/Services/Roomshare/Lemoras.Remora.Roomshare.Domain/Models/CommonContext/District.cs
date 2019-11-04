using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Roomshare.Domain.Models.CommonContext
{
    public class District : Entity<int>
    {        
        public District(int cityId, string name)
        {
            this.Name = name;
            this.CityId = cityId;
        }

        public int CityId { get; protected set; }
        public string Name { get; protected set; }   
    }
}
