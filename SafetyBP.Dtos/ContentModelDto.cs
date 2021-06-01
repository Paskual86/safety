using Newtonsoft.Json;
using System.Collections.Generic;

namespace SafetyBP.Dtos
{
    public class ContentModelDto
    {
        [JsonProperty("controlDeObjetos")]
        public List<ControlObjectsHardwareDto> ObjectControls { get; set; }
        [JsonProperty("accionesCorrectivas")]
        public List<CorrectiveActionSectorDto> CorrectiveActions { get; set; }
        [JsonProperty("tareas")]
        public List<TaskDto> Tasks { get; set; }
        [JsonProperty("checklist")]
        public List<CheckListDto> CheckLists { get; set; }
        [JsonProperty("sectores")]
        public List<SectorDto> Sectors { get; set; }
    }
}
