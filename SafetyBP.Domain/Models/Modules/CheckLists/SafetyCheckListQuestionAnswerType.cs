using SafetyBP.Domain.Enums;

namespace SafetyBP.Domain.Models
{
    public class SafetyCheckListQuestionAnswerType
    {
        public int Value { get; set; }
        public string Description { get; set; }
        public CheckListQuestionStatus Sign { get; set; }
    }
}
