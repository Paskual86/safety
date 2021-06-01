using Newtonsoft.Json;
using System.Collections.Generic;

namespace SafetyBP.Dtos
{
    public class ControlObjectsSurveyDto
    {
        [JsonProperty("rid")]
        public int Id { get; set; }
        [JsonProperty("sid")]
        public int SectorId { get; set; }
        [JsonProperty("qr")]
        public int HardwareQrId { get; set; }
        [JsonProperty("eid")]
        public int HardwareId { get; set; }
        [JsonProperty("equipo")]
        public string HardwareName { get; set; }
        [JsonProperty("fecha")]
        public string Date { get; set; }
        [JsonProperty("nombre")]
        public string Name { get; set; }
        [JsonProperty("oid")]
        public int ObjectId { get; set; }
        [JsonProperty("objeto")]
        public string ObjectName { get; set; }
        [JsonProperty("visible")]
        public byte IsVisible { get; set; }

        [JsonProperty("preguntas")]
        public IList<ControlObjectsQuestionDto> Questions { get; set; }
        [JsonProperty("checklist")]
        public IList<ControlObjectsCheckListDto> CheckLists { get; set; }
    }
}
