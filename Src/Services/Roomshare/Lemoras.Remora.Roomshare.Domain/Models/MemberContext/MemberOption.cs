namespace Lemoras.Remora.Roomshare.Domain.Models.MemberContext
{
    public class MemberOption
    {
        public MemberOption(int optionId, int questionId)
        {
            this.OptionId = optionId;
            this.QuestionId = questionId;
        }

        public int OptionId { get; protected set; }
        public int QuestionId { get; protected set; }
    }
}
