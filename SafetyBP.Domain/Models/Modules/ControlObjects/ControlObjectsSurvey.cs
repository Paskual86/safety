using System.Collections.Generic;

namespace SafetyBP.Domain.Models.Modules.ControlObjects
{
    public class ControlObjectsSurvey
    {
        public int Id { get; set; }
        public int SectorId { get; set; }
        public virtual ControlObjectsSector Sector { get; set; }
        public int HardwareQrId { get; set; }
        public int HardwareId { get; set; }
        public string HardwareName { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public int ObjectId { get; set; }
        public string ObjectName { get; set; }
        public byte IsVisible { get; set; }
        public bool IsActive { get; set; }
        public bool IsFinalize { get; set; }
        public bool Result { get; set; }
        public IList<ControlObjectsQuestion> Questions { get; set; }
        public IList<ControlObjectsCheckList> CheckLists { get; set; }
    }
}
