using System.Collections.Generic;
using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Roomshare.Domain.Models.CommonContext
{
    public class Question : Entity<int>
    {
        private readonly List<Option> _options;

        public Question()
        {
            _options = new List<Option>();
        }

        public string QuestionTitle { get; protected set; }
        public string QuestionDescription { get; protected set; }
        public int Factor { get; protected set; }
        public int Index { get; protected set; }

        public IReadOnlyCollection<Option> Options => _options;
        
        public Option AddOption(string optionText, int factor, int index)
        {
            var option = new Option(this.Id, optionText, factor, index);
            _options.Add(option);
            return option;
        }
    }
}
