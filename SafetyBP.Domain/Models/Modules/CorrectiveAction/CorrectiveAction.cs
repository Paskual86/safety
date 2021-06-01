using System.Collections.Generic;

namespace SafetyBP.Domain.Models.Modules.CorrectiveAction
{
    public class CorrectiveAction
    { 
        public IList<CorrectiveActionSector> Sectors { get; set; }
    }
}
