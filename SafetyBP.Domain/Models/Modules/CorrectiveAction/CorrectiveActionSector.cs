using System.Collections.Generic;

namespace SafetyBP.Domain.Models.Modules.CorrectiveAction
{
    public class CorrectiveActionSector
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<CorrectiveActionTopic> Topics { get; set; }
    }
}
