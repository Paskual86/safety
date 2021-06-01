namespace SafetyBP.Domain.Models
{
    public class SafetyCheckListNegativeValue
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Value { get; set; }
        public int ValueType { get; set; }
        public virtual SafetyCheckListQuestion Question { get; set; }
    }
}
