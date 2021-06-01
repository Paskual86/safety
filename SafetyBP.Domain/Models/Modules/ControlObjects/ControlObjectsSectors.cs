using System.Collections.Generic;

namespace SafetyBP.Domain.Models.Modules.ControlObjects
{
    public class ControlObjectsSector
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public int HardwareQrId { get; set; }
        public int HardwareId { get; set; }
        public virtual ControlObjectsHardware Hardware { get; set; }
        public string HardwareName { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public IList<ControlObjectsSurvey> Surveys { get; set; }
    }
}
