using Newtonsoft.Json;
using System.Collections.Generic;

namespace SafetyBP.Dtos
{
    public class TaskDto
    {
        [JsonProperty("sid")]
        public int Id { get; set; }
        [JsonProperty("sector")]
        public string Sector { get; set; }
        [JsonProperty("tareas")]
        public ICollection<TaskDetailsDto> Details { get; set; }
    }
}
