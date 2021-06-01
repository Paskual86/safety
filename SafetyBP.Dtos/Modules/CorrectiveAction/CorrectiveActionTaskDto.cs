using Newtonsoft.Json;

namespace SafetyBP.Dtos
{
    public class CorrectiveActionTaskDto
    {
        [JsonProperty("tid")]
        public long Id { get; set; }
        [JsonProperty("rid")]
        public long TopicId { get; set; }

        [JsonProperty("tarea")]
        public string Name { get; set; }
        [JsonProperty("estado")]
        public short Status { get; set; }
    }
}
