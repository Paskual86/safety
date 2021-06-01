using System.Collections.Generic;

namespace SafetyBP.Domain.Models.Modules.ControlObjects
{
    public class ControlObjectsHardware
    {
        public int Id { get; set; }

        public int QrId { get; set; }
        public string Name { get; set; }
        public IList<ControlObjectsSector> Sectors { get; set; }
    }
}
