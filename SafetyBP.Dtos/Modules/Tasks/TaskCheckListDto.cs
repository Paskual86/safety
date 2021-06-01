using Newtonsoft.Json;

namespace SafetyBP.Dtos
{
    public class TaskCheckListDto
    {
        [JsonProperty("cid")]
        public int Id { get; set; }
        [JsonProperty("estado")]
        public int Status { get; set; }
        [JsonProperty("tarea")]
        public string Name { get; set; }
    }
}
