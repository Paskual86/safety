using Newtonsoft.Json;
using System.Collections.Generic;

namespace SafetyBP.Dtos
{
    public class TaskDetailsDto
    {
        [JsonProperty("tid")]
        public int Id { get; set; }
        [JsonProperty("codigo")]
        public string Code { get; set; }
        [JsonProperty("nombre")]
        public string Name { get; set; }
        [JsonProperty("prioridad")]
        public byte Priority { get; set; }
        [JsonProperty("comentario")]
        public string Comments { get; set; }
        [JsonProperty("inicio")]
        public string StartDateTime { get; set; }
        [JsonProperty("vencimiento")]
        public string EndDateTime { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("archivos")]
        public ICollection<string> Files { get; set; }
        [JsonProperty("checklist")]
        public ICollection<TaskCheckListDto> CheckList { get; set; }
    }
}
