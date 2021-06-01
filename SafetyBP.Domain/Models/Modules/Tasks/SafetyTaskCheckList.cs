namespace SafetyBP.Domain.Models
{
    public class SafetyTaskCheckList
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public string Name { get; set; }

        public string Photo { get; set; }
        public string Comments { get; set; }
        public bool IsPendingToSync { get; set; }
        public virtual SafetyTaskDetails TaskDetail { get; set; }
    }
}
