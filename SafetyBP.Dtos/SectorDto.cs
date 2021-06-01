using Newtonsoft.Json;

namespace SafetyBP.Dtos
{
    public class SectorDto
    {
        [JsonProperty("sid")]
        public int Id { get; set; }
        [JsonProperty("sector")]
        public string Sector { get; set; }
    }
}
