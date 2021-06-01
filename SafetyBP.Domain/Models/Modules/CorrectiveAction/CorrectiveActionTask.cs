namespace SafetyBP.Domain.Models.Modules.CorrectiveAction
{
    public class CorrectiveActionTask
    {
        public long Id { get; set; }
        public long TopicId { get; set; }
        public virtual CorrectiveActionTopic Topic { get;set;}
        public string Name { get; set; }
        public short Status { get; set; }
    }
}
