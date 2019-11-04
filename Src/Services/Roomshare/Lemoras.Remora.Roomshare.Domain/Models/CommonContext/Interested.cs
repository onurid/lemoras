using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Roomshare.Domain.Models.CommonContext
{
    public class Interested : Entity<int>
    {
        public Interested(string title, int index)
        {
            this.Title = title;
            this.Index = index;
        }

        public string Title { get; protected set; }
        public int Index { get; protected set; }
    }
}
