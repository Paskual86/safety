using System.Collections.Generic;

namespace SafetyBP.Domain.Models.Modules.CorrectiveAction
{
    public class CorrectiveActionTopic
    {
        public long Id { get; set; }
        public long SectorId { get; set; }
        public virtual CorrectiveActionSector Sector { get; set; }
        public string Reason { get; set; }
        public int Number { get; set; }
        public System.DateTime? DueDate { get; set; }
        public IList<CorrectiveActionTask> Tasks { get; set; }
    }
}
