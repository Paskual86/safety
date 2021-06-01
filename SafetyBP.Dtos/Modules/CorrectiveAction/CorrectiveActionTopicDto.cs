using Newtonsoft.Json;
using System.Collections.Generic;

namespace SafetyBP.Dtos
{
    public class CorrectiveActionTopicDto
    {
        [JsonProperty("rid")]
        public long Id { get; set; }
        [JsonProperty("sid")]
        public long SectorId { get; set; }
        [JsonProperty("numero")]
        public int Number { get; set; }
        [JsonProperty("motivo")]
        public string Reason { get; set; }
        [JsonProperty("vencimiento")]
        public string DueDate { get; set; }
        [JsonProperty("tareas")]
        public List<CorrectiveActionTaskDto> Tasks { get; set; }
    }
}
