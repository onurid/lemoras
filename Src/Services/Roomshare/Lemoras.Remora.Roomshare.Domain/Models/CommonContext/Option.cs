using OYASAR.Framework.Core.Entity;

namespace Lemoras.Remora.Roomshare.Domain.Models.CommonContext
{
    public class Option : Entity<int>
    {
        public Option(int questionId, string optionText, int factor, int index)
        {
            this.QuestionId = questionId;
            this.OptionText = optionText;
            this.Factor = factor;
            this.Index = index;
        }

        public int QuestionId { get; protected set; }
        public string OptionText { get; protected set; }
        public int Factor { get; protected set; }
        public int Index { get; protected set; }

        public void EditOptionText(string optiontext)
        {
            this.OptionText = optiontext;
        }

        public void EditFactor(int factor)
        {
            this.Factor = factor;
        }
    }
}
