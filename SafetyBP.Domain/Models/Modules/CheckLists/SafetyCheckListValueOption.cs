using SafetyBP.Domain.Enums;

namespace SafetyBP.Domain.Models
{
    public class SafetyCheckListValueOption
    {
        public CheckListQuestionTypes Type { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public CheckListQuestionStatus Status { get; set; }
    }
}
