using Newtonsoft.Json;
using System.Collections.Generic;

namespace SafetyBP.Dtos
{
    public class CorrectiveActionSectorDto
    {
        [JsonProperty("sid")]
        public long Id { get; set; }
        [JsonProperty("sector")]
        public string Name { get; set; }
        [JsonProperty("temas")]
        public List<CorrectiveActionTopicDto> Topics { get; set; }
    }
}
