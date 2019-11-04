using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Roomshare.Domain.Models.CommonContext
{
    public class Program : Entity<int>
    {
        public Program(int universityId, string name)
        {
            this.Name = name;
            this.UniversityId = universityId;

        }
        public int UniversityId { get; protected set; }
        public string Name { get; protected set; }
    }
}
