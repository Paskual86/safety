namespace SafetyBP.Domain.Models
{
    public class SafetyTaskAdditionalData
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string Photo { get; set; }
        public string Comments { get; set; }
        public virtual SafetyTask Task { get; set; }
    }
}
